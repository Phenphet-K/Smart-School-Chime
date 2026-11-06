from html.parser import HTMLParser
import json
import shutil
import subprocess
import pytest
from broadcast_server import HTML_CLIENT_TEMPLATE


def test_mobile_markup_has_native_button_and_unique_ids():
    class Parser(HTMLParser):
        def __init__(self):
            super().__init__()
            self.ids = []
            self.button = False

        def handle_starttag(self, tag, attrs):
            attrs = dict(attrs)
            if 'id' in attrs:
                self.ids.append(attrs['id'])
            if attrs.get('id') == 'pttButton':
                self.button = tag == 'button'
    parser = Parser()
    parser.feed(HTML_CLIENT_TEMPLATE)
    assert parser.button and len(parser.ids) == len(set(parser.ids))
    assert 'user-scalable=no' not in HTML_CLIENT_TEMPLATE
    assert 'createScriptProcessor' not in HTML_CLIENT_TEMPLATE


def test_mobile_record_encode_upload_with_mocked_microphone(tmp_path):
    node = shutil.which('node')
    if not node:
        pytest.skip('Node is needed for client JavaScript behavior checks')
    script = HTML_CLIENT_TEMPLATE.split('<script>', 1)[1].split('</script>', 1)[0]
    harness = r'''
const vm = require('vm');
const assert = require('assert');
const elements = new Map();
let sent = null;
let stopped = 0;
function element(id) {
  if (!elements.has(id)) elements.set(id, {
    innerText: '', style: {}, checked: false, disabled: false,
    classList: {add() {}, remove() {}},
    querySelectorAll: () => [], addEventListener() {}, setPointerCapture() {}
  });
  return elements.get(id);
}
class AudioContext {
  constructor() {
    this.sampleRate = 48000; this.state = 'running'; this.destination = {};
    this.audioWorklet = {addModule: async () => {}};
  }
  createMediaStreamSource() { return {connect() {}}; }
}
const context = vm.createContext({
  console, Blob, URL, URLSearchParams, Float32Array, ArrayBuffer, DataView, Date,
  document: {getElementById: element, addEventListener() {}},
  window: {isSecureContext: true, AudioContext},
  location: {hostname: '127.0.0.1', pathname: '/', hash: '#token=test-pairing'},
  history: {replaceState() {}},
  sessionStorage: {getItem() {return null;}, setItem() {}},
  navigator: {mediaDevices: {getUserMedia: async () => ({getTracks: () => [{stop() {stopped++;}}]})}},
  AudioWorkletNode: class {constructor() {this.port = {};} connect() {} disconnect() {}},
  setTimeout: () => 1, clearTimeout() {}, setInterval: () => 1, clearInterval() {},
  AbortController,
  fetch: async (url, options) => {sent = {url, options}; return {json: async () => ({status: 'ok'})};}
});
vm.runInContext(SOURCE, context);
(async () => {
  await vm.runInContext('startRecording()', context);
  vm.runInContext('scriptProcessor.port.onmessage({data: new Float32Array([0, 0.5, -0.5])})', context);
  await vm.runInContext('stopRecording()', context);
  assert(sent);
  assert.equal(sent.options.headers.Authorization, 'Bearer test-pairing');
  assert.equal(sent.options.body.type, 'audio/wav');
  const bytes = new DataView(await sent.options.body.arrayBuffer());
  assert.equal(bytes.getUint32(24, true), 48000);
  assert.equal(bytes.getUint32(40, true), 6);
  assert.equal(bytes.getInt16(46, true), 16383);
  assert.equal(bytes.getInt16(48, true), -16384);
  assert(stopped > 0);
  assert.equal(element('pttButton').disabled, false);
  console.log('client capture/PCM encoding/authenticated upload passed');
})().catch(error => {console.error(error); process.exitCode = 1;});
'''.replace('SOURCE', json.dumps(script))
    filename = tmp_path / 'client-test.cjs'
    filename.write_text(harness, encoding='utf-8')
    result = subprocess.run([node, str(filename)], capture_output=True, text=True, timeout=10)
    assert result.returncode == 0, result.stdout + result.stderr
