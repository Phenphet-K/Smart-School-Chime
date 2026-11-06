import http.client
import io
import ssl
import time
import wave
import pytest
import broadcast_server as broadcast


def wav_bytes(frames=160):
    output = io.BytesIO()
    with wave.open(output, 'wb') as stream:
        stream.setparams((1, 2, 16000, 0, 'NONE', 'not compressed'))
        stream.writeframes(b'\x00\x00' * frames)
    return output.getvalue()


@pytest.fixture
def server(isolated):
    received = []
    instance = broadcast.BroadcastServer(0, 0, lambda *args: received.append(args), host='127.0.0.1')
    instance.start()
    assert instance.httpsd and instance.httpd
    yield instance, received
    instance.stop()


def request(server, body=None, *, secure=True, token=True, extra=None, path='/api/broadcast'):
    instance, _ = server
    if secure:
        context = ssl.create_default_context(cafile=str(broadcast.CONFIG_DIR) + '/cert.pem')
        connection = http.client.HTTPSConnection('127.0.0.1', instance.https_port, context=context, timeout=3)
    else:
        connection = http.client.HTTPConnection('127.0.0.1', instance.http_port, timeout=3)
    headers = {'Content-Type': 'audio/wav'}
    if token:
        headers['Authorization'] = 'Bearer ' + instance._token
    headers.update(extra or {})
    try:
        connection.request('POST', path, body=wav_bytes() if body is None else body, headers=headers)
        response = connection.getresponse()
        result = response.status, response.read(), response.getheaders()
        return result
    finally:
        connection.close()


def test_pairing_required_and_no_wildcard_cors(server):
    status, _, headers = request(server, token=False)
    assert status == 401
    assert not any(key.lower() == 'access-control-allow-origin' for key, value in headers)
    assert not server[1]


def test_http_cannot_upload_even_with_token(server):
    assert request(server, secure=False)[0] == 403
    assert not server[1]


@pytest.mark.parametrize('body', [b'not a WAV' * 20, wav_bytes()[:-2]])
def test_invalid_wav_rejected_and_reservation_released(server, body):
    assert request(server, body)[0] == 400
    assert not server[0]._busy
    assert not server[1]


def test_large_declared_body_rejected_without_reading(server):
    assert request(server, b'', extra={'Content-Length': str(broadcast.MAX_AUDIO_BYTES + 1)})[0] == 413


def test_cross_origin_rejected(server):
    assert request(server, extra={'Origin': 'https://untrusted.invalid'})[0] == 403


def test_upload_is_unique_and_busy_until_cleanup(server):
    instance, received = server
    assert request(server)[0] == 202
    first = received[0][1]
    assert request(server)[0] == 409
    instance.release_broadcast(first)
    assert request(server)[0] == 202
    second = received[1][1]
    assert first != second
    instance.release_broadcast(second)
    assert not instance._files


def test_expiry_and_revocation(server):
    instance, _ = server
    old = 'Bearer ' + instance._token
    assert instance.authorized(old)
    instance.rotate_token()
    assert not instance.authorized(old)
    instance._token_expires = time.monotonic() - 1
    assert request(server)[0] == 401


def test_stop_releases_ports_and_restart_works(server):
    instance, _ = server
    instance.stop()
    assert not instance.is_running and not instance._threads
    instance.start()
    assert instance.httpd and instance.httpsd
    assert request(server)[0] == 202


def test_wav_duration_limit():
    with pytest.raises(ValueError):
        broadcast.validate_wav(wav_bytes(16000 * 91))


def test_certificate_contains_ip_san(server):
    from cryptography import x509
    from pathlib import Path
    cert = x509.load_pem_x509_certificate((Path(broadcast.CONFIG_DIR) / 'cert.pem').read_bytes())
    sans = cert.extensions.get_extension_for_class(x509.SubjectAlternativeName).value
    assert '127.0.0.1' in {str(value) for value in sans.get_values_for_type(x509.IPAddress)}
