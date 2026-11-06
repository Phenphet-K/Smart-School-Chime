"""
LAN Live Broadcast Web Server for Smart School Chime
Enables teachers/staff to scan QR code and broadcast live voice announcements
via smartphone or PC browser on the same Wi-Fi / Local Area Network.
Authenticated record-and-send announcements over HTTPS.
"""

import os
import sys
import time
import socket
import threading
import ssl
import json
import logging
from http.server import ThreadingHTTPServer, BaseHTTPRequestHandler
import urllib.parse
import io
import wave
import tempfile
import secrets
import hmac
import ipaddress
import app_paths

logger = logging.getLogger("BroadcastServer")

CONFIG_DIR = str(app_paths.CONFIG_DIR)
DATA_DIR = str(app_paths.DATA_DIR)
MAX_AUDIO_BYTES = 18 * 1024 * 1024
MAX_AUDIO_SECONDS = 90

def get_local_lan_ip() -> str:
    """Detect the active local IP address in the LAN"""
    try:
        with socket.socket(socket.AF_INET, socket.SOCK_DGRAM) as connection:
            connection.settimeout(0.5)
            connection.connect(('8.8.8.8', 80))
            return connection.getsockname()[0]
    except OSError:
        return '127.0.0.1'


def ensure_ssl_certs(lan_ip=None):
    """Ensure SSL certificate and private key exist for HTTPS"""
    os.makedirs(CONFIG_DIR, exist_ok=True)
    cert_file = os.path.join(CONFIG_DIR, "cert.pem")
    key_file = os.path.join(CONFIG_DIR, "key.pem")

    try:
        from cryptography import x509
        from cryptography.x509.oid import NameOID
        from cryptography.hazmat.primitives import hashes
        from cryptography.hazmat.primitives.asymmetric import rsa
        from cryptography.hazmat.primitives import serialization
        import datetime

        now = datetime.datetime.now(datetime.timezone.utc)
        addresses = {'127.0.0.1', lan_ip or get_local_lan_ip()}
        if os.path.exists(cert_file) and os.path.exists(key_file):
            try:
                with open(cert_file, 'rb') as stream:
                    existing = x509.load_pem_x509_certificate(stream.read())
                sans = existing.extensions.get_extension_for_class(x509.SubjectAlternativeName).value
                expiry = existing.not_valid_after_utc
                if addresses.issubset({str(value) for value in sans.get_values_for_type(x509.IPAddress)}) and expiry > now + datetime.timedelta(days=7):
                    return cert_file, key_file
            except Exception:
                logger.warning('Renewing expired or incompatible certificate')
        key = rsa.generate_private_key(public_exponent=65537, key_size=2048)
        subject = issuer = x509.Name([
            x509.NameAttribute(NameOID.COMMON_NAME, "SmartSchoolChime")
        ])
        cert = (
            x509.CertificateBuilder()
            .subject_name(subject)
            .issuer_name(issuer)
            .public_key(key.public_key())
            .serial_number(x509.random_serial_number())
            .not_valid_before(now - datetime.timedelta(minutes=5))
            .not_valid_after(now + datetime.timedelta(days=365))
            .add_extension(x509.SubjectAlternativeName(
                [x509.DNSName('localhost')] + [x509.IPAddress(ipaddress.ip_address(address)) for address in sorted(addresses)]), critical=False)
            .sign(key, hashes.SHA256())
        )

        with open(key_file, "wb") as f:
            f.write(key.private_bytes(
                serialization.Encoding.PEM,
                serialization.PrivateFormat.TraditionalOpenSSL,
                serialization.NoEncryption()
            ))

        with open(cert_file, "wb") as f:
            f.write(cert.public_bytes(serialization.Encoding.PEM))

        return cert_file, key_file
    except Exception as e:
        logger.error(f"Error generating SSL cert: {e}")
        return None, None

HTML_CLIENT_TEMPLATE = """<!DOCTYPE html>
<html lang="th">
<head>
  <meta charset="UTF-8">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <link rel="icon" href="data:image/svg+xml,<svg xmlns=%22http://www.w3.org/2000/svg%22 viewBox=%220 0 100 100%22><text y=%22.9em%22 font-size=%2290%22>🔔</text></svg>">
  <title>Smart School Chime - ระบบอัดและส่งประกาศ (Push-to-Talk)</title>
  <style>
    * { box-sizing: border-box; margin: 0; padding: 0; font-family: -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, "Sarabun", sans-serif; -webkit-tap-highlight-color: transparent; }
    body {
      background: #0f172a;
      color: #f8fafc;
      min-height: 100vh;
      display: flex;
      flex-direction: column;
      align-items: center;
      justify-content: space-between;
      padding: 16px 14px;
      user-select: none;
      -webkit-user-select: none;
    }
    header { text-align: center; margin-top: 6px; }
    .badge {
      display: inline-flex;
      align-items: center;
      gap: 6px;
      padding: 5px 14px;
      border-radius: 9999px;
      background: rgba(37, 99, 235, 0.2);
      border: 1px solid #3b82f6;
      color: #93c5fd;
      font-size: 13px;
      font-weight: 600;
      margin-bottom: 8px;
    }
    .pulse-dot { width: 8px; height: 8px; border-radius: 50%; background: #22c55e; box-shadow: 0 0 10px #22c55e; }
    h1 { font-size: 22px; font-weight: 700; color: #ffffff; letter-spacing: -0.5px; }
    p.sub { font-size: 13px; color: #94a3b8; margin-top: 3px; }

    /* Notice Banner for Permissions or Insecure HTTP */
    .notice-box {
      width: 100%;
      max-width: 360px;
      margin: 10px auto 0;
      padding: 10px 14px;
      border-radius: 10px;
      font-size: 13px;
      line-height: 1.4;
      text-align: center;
      display: none;
    }
    .notice-box.warning {
      background: #451a03;
      border: 1px solid #f59e0b;
      color: #fde68a;
      display: block;
    }
    .notice-box.btn-action {
      cursor: pointer;
      font-weight: bold;
      text-decoration: underline;
    }

    .center-container {
      display: flex;
      flex-direction: column;
      align-items: center;
      justify-content: center;
      width: 100%;
      margin: 16px 0;
    }

    /* Push-to-Talk Circular Button */
    .ptt-wrapper {
      position: relative;
      width: 230px;
      height: 230px;
      display: flex;
      align-items: center;
      justify-content: center;
    }
    .ptt-halo {
      position: absolute;
      width: 100%;
      height: 100%;
      border-radius: 50%;
      background: radial-gradient(circle, rgba(37,99,235,0.3) 0%, rgba(15,23,42,0) 70%);
      transition: all 0.3s ease;
      transform: scale(0.9);
      pointer-events: none;
    }
    .ptt-button {
      position: relative;
      width: 184px;
      height: 184px;
      border-radius: 50%;
      background: linear-gradient(145deg, #2563eb, #1d4ed8);
      border: 4px solid #60a5fa;
      box-shadow: 0 12px 30px rgba(37, 99, 235, 0.4), inset 0 2px 4px rgba(255, 255, 255, 0.3);
      display: flex;
      flex-direction: column;
      align-items: center;
      justify-content: center;
      cursor: pointer;
      touch-action: none;
      transition: transform 0.12s ease, background 0.15s ease, border-color 0.15s ease, box-shadow 0.15s ease;
    }
    .ptt-button:active, .ptt-button.recording {
      transform: scale(0.94);
      background: linear-gradient(145deg, #dc2626, #b91c1c);
      border-color: #f87171;
      box-shadow: 0 0 45px rgba(220, 38, 38, 0.85), inset 0 2px 4px rgba(255, 255, 255, 0.3);
    }
    .ptt-button.recording ~ .ptt-halo {
      animation: ripple 1.2s infinite ease-out;
      background: radial-gradient(circle, rgba(220,38,38,0.5) 0%, rgba(15,23,42,0) 70%);
    }
    @keyframes ripple {
      0% { transform: scale(0.9); opacity: 1; }
      100% { transform: scale(1.6); opacity: 0; }
    }

    .mic-icon { font-size: 52px; margin-bottom: 6px; pointer-events: none; }
    .ptt-label { font-size: 15px; font-weight: 700; color: #ffffff; text-align: center; pointer-events: none; }
    .ptt-hint { font-size: 11px; color: #bfdbfe; margin-top: 2px; pointer-events: none; }

    /* Status and Meter */
    .status-card {
      margin-top: 20px;
      background: rgba(30, 41, 59, 0.8);
      border: 1px solid #334155;
      border-radius: 14px;
      padding: 12px 18px;
      text-align: center;
      width: 100%;
      max-width: 340px;
    }
    .status-text { font-size: 14px; font-weight: 600; color: #f1f5f9; min-height: 22px; word-break: break-word; }
    .timer { font-size: 26px; font-weight: 800; color: #38bdf8; font-variant-numeric: tabular-nums; margin: 3px 0; }
    .wave-bar-container {
      display: flex;
      align-items: center;
      justify-content: center;
      gap: 4px;
      height: 24px;
      margin-top: 6px;
    }
    .bar {
      width: 4px;
      height: 6px;
      background: #475569;
      border-radius: 2px;
      transition: height 0.05s ease, background-color 0.1s ease;
    }
    .bar.active { background: #38bdf8; }

    /* Features Toggles */
    .controls-card {
      background: #1e293b;
      border: 1px solid #334155;
      border-radius: 14px;
      padding: 12px 16px;
      width: 100%;
      max-width: 360px;
      font-size: 13px;
    }
    .control-row {
      display: flex;
      align-items: center;
      justify-content: space-between;
      padding: 8px 0;
      border-bottom: 1px solid #334155;
    }
    .control-row:last-child { border-bottom: none; }
    .control-title { display: flex; align-items: center; gap: 8px; font-weight: 500; }
    .switch {
      position: relative;
      display: inline-block;
      width: 44px;
      height: 24px;
    }
    .switch input { opacity: 0; width: 0; height: 0; }
    .slider {
      position: absolute; cursor: pointer; top: 0; left: 0; right: 0; bottom: 0;
      background-color: #475569; transition: .2s; border-radius: 24px;
    }
    .slider:before {
      position: absolute; content: ""; height: 18px; width: 18px; left: 3px; bottom: 3px;
      background-color: white; transition: .2s; border-radius: 50%;
    }
    input:checked + .slider { background-color: #2563eb; }
    input:checked + .slider:before { transform: translateX(20px); }

    /* Quick Mic Request Button */
    .perm-btn {
      margin-top: 10px;
      background: #2563eb;
      color: #ffffff;
      border: none;
      padding: 8px 16px;
      border-radius: 8px;
      font-size: 13px;
      font-weight: 600;
      cursor: pointer;
    }

    footer { text-align: center; font-size: 11px; color: #64748b; margin-top: 10px; }
  </style>
</head>
<body>
  <header>
    <div class="badge">
      <div class="pulse-dot"></div>
      <span>Smart School Chime LAN</span>
    </div>
    <h1>📢 ระบบอัดและส่งประกาศ</h1>
    <p class="sub">กดค้างเพื่ออัดเสียง ปล่อยเพื่อส่งเข้าคิวลำโพงโรงเรียน</p>
    <div id="httpWarning" class="notice-box warning btn-action" onclick="switchToHttps()">
      ⚠️ คุณกำลังเปิดผ่าน HTTP ซึ่งเบราว์เซอร์จะบล็อกไมโครโฟน<br><b>👉 แตะที่นี่เพื่อสลับไปใช้ HTTPS ทันที</b>
    </div>
  </header>

  <div class="center-container">
    <div class="ptt-wrapper">
      <button type="button" class="ptt-button" id="pttButton" aria-label="อัดและส่งประกาศ">
        <span class="mic-icon" id="micIcon">🎙️</span>
        <span class="ptt-label" id="btnLabel">กดค้างเพื่อพูด</span>
        <span class="ptt-hint" id="btnHint">Hold to Speak</span>
      </button>
      <div class="ptt-halo"></div>
    </div>

    <div class="status-card">
      <div class="timer" id="timer">00:00</div>
      <div class="status-text" id="statusText">พร้อมพูดประกาศ</div>
      <div class="wave-bar-container" id="waveContainer">
        <div class="bar"></div><div class="bar"></div><div class="bar"></div><div class="bar"></div>
        <div class="bar"></div><div class="bar"></div><div class="bar"></div><div class="bar"></div>
        <div class="bar"></div><div class="bar"></div><div class="bar"></div><div class="bar"></div>
      </div>
      <button id="btnGrantMic" class="perm-btn" style="display:none;" onclick="requestMicPermission()">🎤 แตะเพื่ออนุญาตไมโครโฟน</button>
    </div>
  </div>

  <div class="controls-card">
    <div class="control-row">
      <span class="control-title">🛡️ ตัดเสียงรบกวน (Noise Suppression)</span>
      <label class="switch">
        <input type="checkbox" id="chkNoise" checked>
        <span class="slider"></span>
      </label>
    </div>
    <div class="control-row">
      <span class="control-title">🔔 เล่นเสียงกริ่งเตือนสั้นๆ ก่อนพูด</span>
      <label class="switch">
        <input type="checkbox" id="chkChime" checked>
        <span class="slider"></span>
      </label>
    </div>
    <div class="control-row">
      <span class="control-title">👆 โหมดกด 1 ครั้ง เปิด/ปิด (Toggle)</span>
      <label class="switch">
        <input type="checkbox" id="chkToggle">
        <span class="slider"></span>
      </label>
    </div>
  </div>

  <footer>
    Smart School Chime • เชื่อมต่อผ่าน Wi-Fi โรงเรียนเดียวกัน
  </footer>

  <script>
    const incomingToken = new URLSearchParams(location.hash.slice(1)).get('token');
    const pairingToken = incomingToken || sessionStorage.getItem('chimeToken') || '';
    if (incomingToken) {
      sessionStorage.setItem('chimeToken', incomingToken);
      history.replaceState(null, '', location.pathname);
    }
    const pttButton = document.getElementById('pttButton');
    const btnLabel = document.getElementById('btnLabel');
    const btnHint = document.getElementById('btnHint');
    const micIcon = document.getElementById('micIcon');
    const statusText = document.getElementById('statusText');
    const timerElem = document.getElementById('timer');
    const waveContainer = document.getElementById('waveContainer');
    const bars = waveContainer.querySelectorAll('.bar');
    const chkNoise = document.getElementById('chkNoise');
    const chkChime = document.getElementById('chkChime');
    const chkToggle = document.getElementById('chkToggle');
    const httpWarning = document.getElementById('httpWarning');
    const btnGrantMic = document.getElementById('btnGrantMic');

    let audioCtx = null;
    let mediaStream = null;
    let scriptProcessor = null;
    let isRecording = false;
    let isStarting = false;
    let pendingStop = false;
    let recordingStartTime = 0;
    let timerInterval = null;
    let audioBuffers = [];
    let sampleRate = 44100;
    let pressStartTime = 0;
    let isSending = false;

    // Detect insecure HTTP origin on LAN (which browser blocks microphone for)
    if (!window.isSecureContext && location.hostname !== 'localhost' && location.hostname !== '127.0.0.1') {
      httpWarning.style.display = 'block';
      statusText.innerText = "⚠️ ต้องใช้งานผ่าน HTTPS เพื่อให้ใช้ไมค์ได้";
      statusText.style.color = "#facc15";
    }

    function switchToHttps() {
      location.href = "https://" + location.hostname + ":5443" + (pairingToken ? '#token=' + encodeURIComponent(pairingToken) : '');
    }

    function initAudioSync() {
      if (!audioCtx || audioCtx.state === 'closed') {
        const AudioCtxClass = window.AudioContext || window.webkitAudioContext;
        if (!AudioCtxClass) {
          throw new Error("เบราว์เซอร์นี้ไม่รองรับ Web Audio API");
        }
        audioCtx = new AudioCtxClass({sampleRate: 48000});
      }
      if (audioCtx.state === 'suspended') {
        audioCtx.resume();
      }
      sampleRate = audioCtx.sampleRate || 44100;
    }

    async function requestMicPermission() {
      try {
        statusText.innerText = "กำลังขออนุญาตใช้ไมโครโฟน...";
        statusText.style.color = "#38bdf8";
        initAudioSync();
        const stream = await navigator.mediaDevices.getUserMedia({ audio: true });
        stream.getTracks().forEach(t => t.stop());
        btnGrantMic.style.display = 'none';
        statusText.innerText = "✅ ได้รับอนุญาตไมโครโฟนแล้ว พร้อมพูดประกาศ!";
        statusText.style.color = "#4ade80";
      } catch (e) {
        statusText.innerText = "❌ ไมโครโฟนถูกปิดกั้น: " + e.message;
        statusText.style.color = "#f87171";
      }
    }

    async function startRecording() {
      if (isRecording || isStarting || isSending) return;
      if (!pairingToken) {
        statusText.innerText = 'กรุณาสแกน QR Code ใหม่จากโปรแกรมเพื่อรับสิทธิ์ประกาศ';
        return;
      }
      isStarting = true;
      pendingStop = false;

      // Immediate visual tactile feedback
      pttButton.classList.add('recording');
      btnLabel.innerText = "กำลังเปิดไมค์...";
      micIcon.innerText = "🔴";
      statusText.innerText = "🎙️ กำลังเชื่อมต่อไมโครโฟน...";
      statusText.style.color = "#38bdf8";

      try {
        if (!navigator.mediaDevices || !navigator.mediaDevices.getUserMedia) {
          if (!window.isSecureContext) {
            throw new Error("กรุณาเปิดผ่าน HTTPS (https://" + location.hostname + ":5443) เท่านั้น");
          }
          throw new Error("เบราว์เซอร์ไม่รองรับคำสั่งเข้าถึงไมโครโฟน");
        }

        initAudioSync();

        const useNoise = chkNoise.checked;
        const constraints = {
          audio: {
            echoCancellation: useNoise,
            noiseSuppression: useNoise,
            autoGainControl: useNoise,
            channelCount: 1
          }
        };

        mediaStream = await navigator.mediaDevices.getUserMedia(constraints);
        btnGrantMic.style.display = 'none';

        // Check if user already released while waiting for getUserMedia in Hold mode
        if (pendingStop) {
          pendingStop = false;
          isStarting = false;
          mediaStream.getTracks().forEach(t => t.stop());
          resetUI();
          return;
        }

        const source = audioCtx.createMediaStreamSource(mediaStream);
        // Capture runs on the audio rendering thread, not the UI thread.
        if (!audioCtx._chimeWorkletReady) {
          const moduleSource = `class Capture extends AudioWorkletProcessor {
            process(inputs) {
              const channel = inputs[0] && inputs[0][0];
              if (channel) this.port.postMessage(channel.slice());
              return true;
            }
          }
          registerProcessor('chime-capture', Capture);`;
          const moduleUrl = URL.createObjectURL(new Blob([moduleSource], {type: 'text/javascript'}));
          try { await audioCtx.audioWorklet.addModule(moduleUrl); }
          finally { URL.revokeObjectURL(moduleUrl); }
          audioCtx._chimeWorkletReady = true;
        }
        if (pendingStop) {
          mediaStream.getTracks().forEach(track => track.stop());
          isStarting = false;
          resetUI();
          return;
        }
        scriptProcessor = new AudioWorkletNode(audioCtx, 'chime-capture');
        audioBuffers = [];
        let bufferedSamples = 0;
        scriptProcessor.port.onmessage = event => {
          if (!isRecording) return;
          const inputData = event.data;
          if (bufferedSamples + inputData.length > sampleRate * 90) {
            stopRecording();
            return;
          }
          audioBuffers.push(inputData);
          bufferedSamples += inputData.length;
          let sum = 0;
          for (let i = 0; i < inputData.length; i += 16) sum += Math.abs(inputData[i]);
          updateVU(sum / Math.ceil(inputData.length / 16));
        };
        source.connect(scriptProcessor);
        scriptProcessor.connect(audioCtx.destination);

        isRecording = true;
        isStarting = false;
        recordingStartTime = Date.now();
        btnLabel.innerText = "กำลังประกาศ...";
        btnHint.innerText = chkToggle.checked ? "แตะเพื่อสิ้นสุด" : "ปล่อยเมื่อพูดจบ (หรือแตะอีกครั้ง)";
        statusText.innerText = "🎙️ กำลังอัดเสียง ปล่อยปุ่มเพื่อส่งประกาศ";
        statusText.style.color = "#f87171";

        if (navigator.vibrate) {
          try { navigator.vibrate(60); } catch(vErr) {}
        }

        timerInterval = setInterval(() => {
          const elapsed = Math.floor((Date.now() - recordingStartTime) / 1000);
          const m = String(Math.floor(elapsed / 60)).padStart(2, '0');
          const s = String(elapsed % 60).padStart(2, '0');
          timerElem.innerText = `${m}:${s}`;
          if (elapsed >= 90) {
            stopRecording();
          }
        }, 200);

      } catch (err) {
        if (mediaStream) mediaStream.getTracks().forEach(track => track.stop());
        if (scriptProcessor) { try { scriptProcessor.disconnect(); } catch (_) {} }
        console.error("Mic error:", err);
        isRecording = false;
        isStarting = false;
        pendingStop = false;
        let errMsg = err.message || "ไม่สามารถเปิดไมค์ได้";
        if (err.name === 'NotAllowedError' || err.name === 'PermissionDeniedError') {
          errMsg = "ไมโครโฟนถูกบล็อก: กดรูปแม่กุญแจ 🔒 ที่แถบ URL ด้านบนเพื่อเปิดอนุญาตไมค์";
        } else if (!window.isSecureContext) {
          errMsg = "กรุณาเข้าผ่าน HTTPS (https://" + location.hostname + ":5443) เท่านั้น";
        }
        statusText.innerText = "❌ " + errMsg;
        statusText.style.color = "#f87171";
        pttButton.classList.remove('recording');
        btnLabel.innerText = "แตะเพื่อลองใหม่";
        btnHint.innerText = "Tap to retry";
        micIcon.innerText = "⚠️";
        btnGrantMic.style.display = 'inline-block';
      }
    }

    async function stopRecording() {
      if (isStarting) {
        pendingStop = true;
        return;
      }
      if (!isRecording) return;
      isRecording = false;
      clearInterval(timerInterval);

      if (navigator.vibrate) {
        try { navigator.vibrate(40); } catch(vErr) {}
      }

      btnLabel.innerText = "กำลังส่ง...";
      btnHint.innerText = "Sending Audio";
      statusText.innerText = "⏳ กำลังส่งเสียงไปยังลำโพงโรงเรียน...";
      statusText.style.color = "#38bdf8";

      if (mediaStream) {
        mediaStream.getTracks().forEach(t => t.stop());
      }
      if (scriptProcessor) {
        try { scriptProcessor.disconnect(); } catch(sErr) {}
      }

      resetVU();

      if (audioBuffers.length === 0) {
        statusText.innerText = "⚠️ เสียงสั้นเกินไป ไม่สามารถส่งได้";
        statusText.style.color = "#facc15";
        setTimeout(resetUI, 1800);
        return;
      }

      isSending = true;
      pttButton.disabled = true;
      const controller = new AbortController();
      const uploadTimeout = setTimeout(() => controller.abort(), 20000);
      try {
        const wavBlob = encodeWAV(audioBuffers, sampleRate);
        audioBuffers = [];
        const playChime = chkChime.checked ? "1" : "0";
        const res = await fetch(`/api/broadcast?chime=${playChime}`, {
          method: 'POST',
          headers: { 'Content-Type': 'audio/wav', 'Authorization': 'Bearer ' + pairingToken },
          signal: controller.signal,
          body: wavBlob
        });
        const result = await res.json();
        if (result.status === 'ok') {
          statusText.innerText = "✅ รับเสียงเข้าคิวแล้ว ตรวจผลเล่นที่คอมพิวเตอร์";
          statusText.style.color = "#4ade80";
        } else {
          statusText.innerText = "⚠️ ข้อผิดพลาด: " + (result.message || "ไม่สามารถเล่นเสียงได้");
          statusText.style.color = "#facc15";
        }
      } catch (e) {
        statusText.innerText = "❌ ส่งเสียงไม่สำเร็จ: " + e.message;
        statusText.style.color = "#f87171";
      }

      finally {
        clearTimeout(uploadTimeout);
        isSending = false;
        pttButton.disabled = false;
      }
      setTimeout(resetUI, 2500);
    }

    function resetUI() {
      pttButton.classList.remove('recording');
      btnLabel.innerText = "กดค้างเพื่อพูด";
      btnHint.innerText = chkToggle.checked ? "Tap to Speak" : "Hold or Tap to Speak";
      micIcon.innerText = "🎙️";
      timerElem.innerText = "00:00";
      if (!statusText.innerText.startsWith("❌") && !statusText.innerText.startsWith("⚠️")) {
        statusText.innerText = "พร้อมพูดประกาศ";
        statusText.style.color = "#f1f5f9";
      }
      resetVU();
    }

    function updateVU(val) {
      const scaled = Math.min(1.0, val * 6);
      bars.forEach((b, i) => {
        const factor = 1 - Math.abs(i - 5.5) / 6;
        const h = Math.max(4, Math.floor(scaled * 24 * factor * (0.8 + Math.random() * 0.4)));
        b.style.height = `${h}px`;
        if (h > 6) {
          b.classList.add('active');
        } else {
          b.classList.remove('active');
        }
      });
    }

    function resetVU() {
      bars.forEach(b => {
        b.style.height = '6px';
        b.classList.remove('active');
      });
    }

    // Pure JavaScript WAV Encoder (RIFF + PCM 16-bit Mono)
    function encodeWAV(buffers, rate) {
      let totalLength = 0;
      for (let i = 0; i < buffers.length; i++) {
        totalLength += buffers[i].length;
      }
      const merged = new Float32Array(totalLength);
      let offset = 0;
      for (let i = 0; i < buffers.length; i++) {
        merged.set(buffers[i], offset);
        offset += buffers[i].length;
      }

      const buffer = new ArrayBuffer(44 + merged.length * 2);
      const view = new DataView(buffer);

      writeString(view, 0, 'RIFF');
      view.setUint32(4, 36 + merged.length * 2, true);
      writeString(view, 8, 'WAVE');
      writeString(view, 12, 'fmt ');
      view.setUint32(16, 16, true);
      view.setUint16(20, 1, true);
      view.setUint16(22, 1, true);
      view.setUint32(24, rate, true);
      view.setUint32(28, rate * 2, true);
      view.setUint16(32, 2, true);
      view.setUint16(34, 16, true);
      writeString(view, 36, 'data');
      view.setUint32(40, merged.length * 2, true);

      let idx = 44;
      for (let i = 0; i < merged.length; i++) {
        let s = Math.max(-1, Math.min(1, merged[i]));
        view.setInt16(idx, s < 0 ? s * 0x8000 : s * 0x7FFF, true);
        idx += 2;
      }

      return new Blob([view], { type: 'audio/wav' });
    }

    function writeString(view, offset, string) {
      for (let i = 0; i < string.length; i++) {
        view.setUint8(offset + i, string.charCodeAt(i));
      }
    }

    // Universal Dual-Mode Touch & Mouse Interaction (Supports Hold-to-Talk AND Tap-to-Talk)
    async function handlePressStart(e) {
      e.preventDefault();
      if (isSending) return;
      if (e.pointerId !== undefined) pttButton.setPointerCapture(e.pointerId);
      if (isRecording) {
        // If already recording (from earlier tap), clicking again immediately finishes and sends
        await stopRecording();
        return;
      }
      pressStartTime = Date.now();
      await startRecording();
    }

    async function handlePressEnd(e) {
      if (chkToggle.checked) return;

      if (isStarting) {
        const duration = Date.now() - pressStartTime;
        if (duration > 450) {
          pendingStop = true;
        }
        return;
      }

      if (!isRecording) return;

      const duration = Date.now() - pressStartTime;
      if (duration > 450) {
        // User held button down and just let go -> Stop and broadcast!
        await stopRecording();
      } else {
        // Quick tap (<450ms) -> Keep recording hands-free!
        btnHint.innerText = "แตะอีกครั้งเพื่อหยุดส่ง";
        statusText.innerText = "🔴 กำลังอัดเสียง (แตะปุ่มอีกครั้งเมื่อพูดจบ)";
      }
    }

    pttButton.addEventListener('pointerdown', handlePressStart);
    pttButton.addEventListener('pointerup', handlePressEnd);
    pttButton.addEventListener('pointercancel', () => stopRecording());
    pttButton.addEventListener('keydown', event => {
      if ((event.key === ' ' || event.key === 'Enter') && !event.repeat) {
        event.preventDefault();
        if (isRecording) stopRecording(); else startRecording();
      }
    });
    document.addEventListener('visibilitychange', () => {
      if (document.hidden) stopRecording();
    });

    chkToggle.addEventListener('change', () => {
      btnHint.innerText = chkToggle.checked ? "Tap to Speak" : "Hold or Tap to Speak";
    });
  </script>
</body>
</html>
"""


class LimitedHTTPServer(ThreadingHTTPServer):
    daemon_threads = True
    block_on_close = False
    allow_reuse_address = True

    def __init__(self, address, handler, owner, tls_context=None):
        self.owner = owner
        self.tls_context = tls_context
        self.slots = threading.BoundedSemaphore(8)
        super().__init__(address, handler)

    def get_request(self):
        connection, address = super().get_request()
        connection.settimeout(10)
        if self.tls_context:
            connection = self.tls_context.wrap_socket(connection, server_side=True, do_handshake_on_connect=False)
        return connection, address

    def process_request(self, request, client_address):
        if not self.slots.acquire(blocking=False):
            self.shutdown_request(request)
            return
        try:
            super().process_request(request, client_address)
        except Exception:
            self.slots.release()
            raise

    def process_request_thread(self, request, client_address):
        try:
            super().process_request_thread(request, client_address)
        finally:
            self.slots.release()


def validate_wav(audio_data):
    if len(audio_data) < 44 or len(audio_data) > MAX_AUDIO_BYTES:
        raise ValueError('Invalid audio size')
    with wave.open(io.BytesIO(audio_data), 'rb') as stream:
        if (stream.getcomptype() != 'NONE' or stream.getnchannels() not in (1, 2)
                or stream.getsampwidth() != 2 or not 8000 <= stream.getframerate() <= 48000):
            raise ValueError('Audio must be 16-bit PCM WAV, 8-48 kHz, mono or stereo')
        frames = stream.getnframes()
        if not 0 < frames / stream.getframerate() <= MAX_AUDIO_SECONDS:
            raise ValueError('Audio must be between 0 and 90 seconds')
        expected = frames * stream.getnchannels() * stream.getsampwidth()
        if len(stream.readframes(frames)) != expected:
            raise ValueError('Truncated WAV audio')


class BroadcastHandler(BaseHTTPRequestHandler):
    def log_message(self, format, *args):
        # Never log URL fragments, authorization values or client audio.
        return

    @property
    def owner(self):
        return self.server.owner

    def end_headers(self):
        self.send_header('Cache-Control', 'no-store')
        self.send_header('X-Content-Type-Options', 'nosniff')
        self.send_header('Referrer-Policy', 'no-referrer')
        self.send_header('X-Frame-Options', 'DENY')
        self.send_header('Content-Security-Policy', "default-src 'self'; script-src 'self' 'unsafe-inline' blob:; style-src 'self' 'unsafe-inline'; img-src 'self' data:; worker-src 'self' blob:; frame-ancestors 'none'; object-src 'none'")
        super().end_headers()

    def do_GET(self):
        path = urllib.parse.urlparse(self.path).path
        if path in ('/', '/index.html'):
            body = HTML_CLIENT_TEMPLATE.encode('utf-8')
            self.send_response(200)
            self.send_header('Content-Type', 'text/html; charset=utf-8')
            self.send_header('Content-Length', str(len(body)))
            self.end_headers()
            self.wfile.write(body)
        elif path == '/api/status':
            self._send_json(200, {'status': 'online', 'app': 'Smart School Chime'})
        else:
            self._send_json(404, {'status': 'error', 'message': 'Not found'})

    def do_OPTIONS(self):
        self._send_json(405, {'status': 'error', 'message': 'Cross-origin requests are disabled'})

    def do_POST(self):
        if urllib.parse.urlparse(self.path).path != '/api/broadcast':
            self._send_json(404, {'status': 'error', 'message': 'Not found'})
            return
        if not isinstance(self.connection, ssl.SSLSocket):
            self._send_json(403, {'status': 'error', 'message': 'Use HTTPS and scan the pairing QR code'})
            return
        supplied = self.headers.get('Authorization', '')
        if not self.owner.authorized(supplied):
            self._send_json(401, {'status': 'error', 'message': 'Pairing expired. Scan the QR code again.'})
            return
        origin = self.headers.get('Origin')
        if origin and origin != 'https://' + self.headers.get('Host', ''):
            self._send_json(403, {'status': 'error', 'message': 'Invalid origin'})
            return
        if self.headers.get('Transfer-Encoding') or self.headers.get('Content-Type', '').split(';')[0] != 'audio/wav':
            self._send_json(415, {'status': 'error', 'message': 'Expected audio/wav with Content-Length'})
            return
        try:
            length = int(self.headers.get('Content-Length', '0'))
        except ValueError:
            length = 0
        if not 44 <= length <= MAX_AUDIO_BYTES:
            self._send_json(413, {'status': 'error', 'message': 'Audio size exceeds limit or is empty'})
            return
        if not self.owner.reserve_broadcast():
            self._send_json(409, {'status': 'error', 'message': 'Another announcement is pending or playing'})
            return
        filename = None
        accepted = False
        try:
            chunks = []
            remaining = length
            deadline = time.monotonic() + 20
            while remaining:
                seconds_left = deadline - time.monotonic()
                if seconds_left <= 0:
                    raise TimeoutError('Upload deadline exceeded')
                self.connection.settimeout(min(10, seconds_left))
                chunk = self.rfile.read1(min(65536, remaining))
                if not chunk:
                    raise ValueError('Incomplete upload')
                chunks.append(chunk)
                remaining -= len(chunk)
            data = b''.join(chunks)
            if len(data) != length:
                raise ValueError('Incomplete upload')
            if not self.owner.authorized(supplied):
                raise ValueError('Pairing revoked during upload')
            validate_wav(data)
            os.makedirs(DATA_DIR, exist_ok=True)
            with tempfile.NamedTemporaryFile(suffix='.wav', prefix='announcement-', dir=DATA_DIR, delete=False) as stream:
                filename = stream.name
                stream.write(data)
            self.owner.track_broadcast(filename)
            if not self.owner.on_broadcast_received:
                raise RuntimeError('Audio playback is unavailable')
            params = urllib.parse.parse_qs(urllib.parse.urlparse(self.path).query)
            self.owner.on_broadcast_received(self.client_address[0], filename, params.get('chime', ['1'])[0] == '1')
            accepted = True
            self._send_json(202, {'status': 'ok', 'message': 'Announcement accepted into queue'})
        except (ValueError, wave.Error, EOFError):
            self._send_json(400, {'status': 'error', 'message': 'Invalid or incomplete PCM WAV audio'})
        except (OSError, TimeoutError):
            logger.exception('Broadcast upload failed')
            self.close_connection = True
        except Exception:
            logger.exception('Broadcast acceptance failed')
            self._send_json(503, {'status': 'error', 'message': 'Unable to queue audio'})
        finally:
            if not accepted:
                self.owner.release_broadcast(filename)

    def _send_json(self, code, data):
        body = json.dumps(data).encode('utf-8')
        self.send_response(code)
        self.send_header('Content-Type', 'application/json; charset=utf-8')
        self.send_header('Content-Length', str(len(body)))
        self.end_headers()
        self.wfile.write(body)


class BroadcastServer:
    def __init__(self, http_port=5000, https_port=5443, on_broadcast_received=None, host='0.0.0.0'):
        self.http_port = http_port
        self.https_port = https_port
        self.host = host
        self.on_broadcast_received = on_broadcast_received
        self.lan_ip = get_local_lan_ip()
        self.httpd = None
        self.httpsd = None
        self.is_running = False
        self._threads = []
        self._lock = threading.Lock()
        self._busy = False
        self._files = set()
        self.rotate_token()

    def rotate_token(self):
        with self._lock:
            self._token = secrets.token_urlsafe(32)
            self._token_expires = time.monotonic() + 8 * 3600

    def authorized(self, header):
        with self._lock:
            return time.monotonic() < self._token_expires and hmac.compare_digest(header.encode('utf-8'), ('Bearer ' + self._token).encode('ascii'))

    def reserve_broadcast(self):
        with self._lock:
            if not self.is_running or self._busy:
                return False
            self._busy = True
            return True

    def track_broadcast(self, filename):
        with self._lock:
            if not self.is_running:
                raise RuntimeError('Broadcast server is stopping')
            self._files.add(filename)

    def release_broadcast(self, filename):
        if filename:
            try:
                os.unlink(filename)
            except FileNotFoundError:
                pass
            except OSError:
                logger.exception('Cannot remove temporary announcement')
        with self._lock:
            if filename is None or filename in self._files:
                self._files.discard(filename)
                self._busy = False

    def get_urls(self):
        with self._lock:
            token = self._token
        return {'https': f'https://{self.lan_ip}:{self.https_port}/#token={token}',
                'http': f'http://{self.lan_ip}:{self.http_port}/'}

    def start(self):
        if self.is_running:
            return
        self.lan_ip = get_local_lan_ip()
        cert_file, key_file = ensure_ssl_certs(self.lan_ip)
        if cert_file and key_file:
            listener = None
            try:
                context = ssl.SSLContext(ssl.PROTOCOL_TLS_SERVER)
                context.minimum_version = ssl.TLSVersion.TLSv1_2
                context.load_cert_chain(cert_file, key_file)
                listener = LimitedHTTPServer((self.host, self.https_port), BroadcastHandler, self, context)
                self.httpsd = listener
                self.https_port = listener.server_port
                thread = threading.Thread(target=listener.serve_forever, kwargs={'poll_interval': 0.1}, daemon=True)
                thread.start()
                self._threads.append(thread)
            except Exception:
                if listener:
                    listener.server_close()
                self.httpsd = None
                logger.exception('HTTPS listener failed')
        try:
            self.httpd = LimitedHTTPServer((self.host, self.http_port), BroadcastHandler, self)
            self.http_port = self.httpd.server_port
            thread = threading.Thread(target=self.httpd.serve_forever, kwargs={'poll_interval': 0.1}, daemon=True)
            thread.start()
            self._threads.append(thread)
        except Exception:
            self.httpd = None
            logger.exception('HTTP listener failed')
        self.is_running = bool(self.httpsd or self.httpd)

    def stop(self):
        self.is_running = False
        for listener in (self.httpsd, self.httpd):
            if listener:
                listener.shutdown()
                listener.server_close()
        for thread in self._threads:
            thread.join(timeout=2)
        self._threads.clear()
        self.httpsd = self.httpd = None
        with self._lock:
            files = list(self._files)
        for filename in files:
            self.release_broadcast(filename)
