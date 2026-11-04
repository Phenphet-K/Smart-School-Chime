"""
LAN Live Broadcast Web Server for Smart School Chime
Enables teachers/staff to scan QR code and broadcast live voice announcements
via smartphone or PC browser on the same Wi-Fi / Local Area Network.
Features Push-to-Talk, Noise Suppression, and 0.1s Pre-roll Delay Buffer.
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
import winsound

logger = logging.getLogger("BroadcastServer")

BASE_DIR = os.path.dirname(os.path.abspath(__file__))
CONFIG_DIR = os.path.join(BASE_DIR, "config")
DATA_DIR = os.path.join(BASE_DIR, "data")
TEMP_WAV = os.path.join(DATA_DIR, "live_broadcast_temp.wav")

def get_local_lan_ip() -> str:
    """Detect the active local IP address in the LAN"""
    try:
        s = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
        s.settimeout(0.5)
        s.connect(("8.8.8.8", 80))
        ip = s.getsockname()[0]
        s.close()
        return ip
    except Exception:
        return "127.0.0.1"

def ensure_ssl_certs():
    """Ensure SSL certificate and private key exist for HTTPS"""
    os.makedirs(CONFIG_DIR, exist_ok=True)
    cert_file = os.path.join(CONFIG_DIR, "cert.pem")
    key_file = os.path.join(CONFIG_DIR, "key.pem")

    if os.path.exists(cert_file) and os.path.exists(key_file):
        return cert_file, key_file

    try:
        from cryptography import x509
        from cryptography.x509.oid import NameOID
        from cryptography.hazmat.primitives import hashes
        from cryptography.hazmat.primitives.asymmetric import rsa
        from cryptography.hazmat.primitives import serialization
        import datetime

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
            .not_valid_before(datetime.datetime.utcnow())
            .not_valid_after(datetime.datetime.utcnow() + datetime.timedelta(days=3650))
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
  <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no">
  <link rel="icon" href="data:image/svg+xml,<svg xmlns=%22http://www.w3.org/2000/svg%22 viewBox=%220 0 100 100%22><text y=%22.9em%22 font-size=%2290%22>🔔</text></svg>">
  <title>Smart School Chime - ระบบพูดประกาศสด (Push-to-Talk)</title>
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
      <span>Smart School Chime Live LAN</span>
    </div>
    <h1>📢 ระบบพูดประกาศสด</h1>
    <p class="sub">กดปุ่มค้างเพื่อพูดกระจายเสียงผ่านลำโพงโรงเรียน</p>
    <div id="httpWarning" class="notice-box warning btn-action" onclick="switchToHttps()">
      ⚠️ คุณกำลังเปิดผ่าน HTTP ซึ่งเบราว์เซอร์จะบล็อกไมโครโฟน<br><b>👉 แตะที่นี่เพื่อสลับไปใช้ HTTPS ทันที</b>
    </div>
  </header>

  <div class="center-container">
    <div class="ptt-wrapper">
      <div class="ptt-button" id="pttButton">
        <div class="mic-icon" id="micIcon">🎙️</div>
        <div class="ptt-label" id="btnLabel">กดค้างเพื่อพูด</div>
        <div class="ptt-hint" id="btnHint">Hold to Speak</div>
      </div>
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
      <span class="control-title">⏱️ หน่วงเวลาเริ่มพูด 0.1 วินาที (100ms)</span>
      <label class="switch">
        <input type="checkbox" id="chkDelay" checked>
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
    const chkDelay = document.getElementById('chkDelay');
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
    let delayTimeout = null;
    let pressStartTime = 0;

    // Detect insecure HTTP origin on LAN (which browser blocks microphone for)
    if (!window.isSecureContext && location.hostname !== 'localhost' && location.hostname !== '127.0.0.1') {
      httpWarning.style.display = 'block';
      statusText.innerText = "⚠️ ต้องใช้งานผ่าน HTTPS เพื่อให้ใช้ไมค์ได้";
      statusText.style.color = "#facc15";
    }

    function switchToHttps() {
      location.href = "https://" + location.hostname + ":5443";
    }

    function initAudioSync() {
      if (!audioCtx || audioCtx.state === 'closed') {
        const AudioCtxClass = window.AudioContext || window.webkitAudioContext;
        if (!AudioCtxClass) {
          throw new Error("เบราว์เซอร์นี้ไม่รองรับ Web Audio API");
        }
        audioCtx = new AudioCtxClass();
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
      if (isRecording || isStarting) return;
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
        scriptProcessor = audioCtx.createScriptProcessor(4096, 1, 1);
        audioBuffers = [];

        // 0.1s Pre-roll buffer (100ms) delay
        const delayMs = chkDelay.checked ? 100 : 0;
        let captureEnabled = (delayMs === 0);
        if (delayMs > 0) {
          delayTimeout = setTimeout(() => {
            captureEnabled = true;
          }, delayMs);
        }

        scriptProcessor.onaudioprocess = (e) => {
          if (!isRecording || !captureEnabled) return;
          const inputData = e.inputBuffer.getChannelData(0);
          audioBuffers.push(new Float32Array(inputData));

          let sum = 0;
          for (let i = 0; i < inputData.length; i += 16) {
            sum += Math.abs(inputData[i]);
          }
          const avg = sum / (inputData.length / 16);
          updateVU(avg);
        };

        source.connect(scriptProcessor);
        scriptProcessor.connect(audioCtx.destination);

        isRecording = true;
        isStarting = false;
        recordingStartTime = Date.now();
        btnLabel.innerText = "กำลังประกาศ...";
        btnHint.innerText = chkToggle.checked ? "แตะเพื่อสิ้นสุด" : "ปล่อยเมื่อพูดจบ (หรือแตะอีกครั้ง)";
        statusText.innerText = "🎙️ กำลังส่งเสียงสด... (พูดได้เลย)";
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
      if (delayTimeout) clearTimeout(delayTimeout);
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

      const wavBlob = encodeWAV(audioBuffers, sampleRate);

      try {
        const playChime = chkChime.checked ? "1" : "0";
        const res = await fetch(`/api/broadcast?chime=${playChime}`, {
          method: 'POST',
          headers: { 'Content-Type': 'audio/wav' },
          body: wavBlob
        });
        const result = await res.json();
        if (result.status === 'ok') {
          statusText.innerText = "✅ ประกาศสำเร็จ กำลังดังที่ลำโพง!";
          statusText.style.color = "#4ade80";
        } else {
          statusText.innerText = "⚠️ ข้อผิดพลาด: " + (result.message || "ไม่สามารถเล่นเสียงได้");
          statusText.style.color = "#facc15";
        }
      } catch (e) {
        statusText.innerText = "❌ ส่งเสียงไม่สำเร็จ: " + e.message;
        statusText.style.color = "#f87171";
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
        statusText.innerText = "🔴 กำลังประกาศสด... (แตะปุ่มอีกครั้งเมื่อพูดจบ)";
      }
    }

    pttButton.addEventListener('pointerdown', handlePressStart);
    pttButton.addEventListener('pointerup', handlePressEnd);
    pttButton.addEventListener('pointercancel', handlePressEnd);

    chkToggle.addEventListener('change', () => {
      btnHint.innerText = chkToggle.checked ? "Tap to Speak" : "Hold or Tap to Speak";
    });
  </script>
</body>
</html>
"""

class BroadcastHandler(BaseHTTPRequestHandler):
    server_instance = None

    def log_message(self, format, *args):
        pass

    def do_GET(self):
        parsed = urllib.parse.urlparse(self.path)
        if parsed.path == "/" or parsed.path == "/index.html":
            self.send_response(200)
            self.send_header("Content-Type", "text/html; charset=utf-8")
            self.send_header("Access-Control-Allow-Origin", "*")
            self.end_headers()
            self.wfile.write(HTML_CLIENT_TEMPLATE.encode("utf-8"))
        elif parsed.path == "/api/status":
            self.send_response(200)
            self.send_header("Content-Type", "application/json; charset=utf-8")
            self.send_header("Access-Control-Allow-Origin", "*")
            self.end_headers()
            resp = {
                "status": "online",
                "app": "Smart School Chime",
                "lan_ip": self.server_instance.lan_ip if self.server_instance else "127.0.0.1"
            }
            self.wfile.write(json.dumps(resp).encode("utf-8"))
        elif parsed.path in ("/favicon.ico", "/apple-touch-icon.png", "/apple-touch-icon-precomposed.png"):
            self.send_response(200)
            self.send_header("Content-Type", "image/svg+xml")
            self.send_header("Access-Control-Allow-Origin", "*")
            self.send_header("Cache-Control", "public, max-age=86400")
            self.end_headers()
            self.wfile.write(b'<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 100 100"><text y=".9em" font-size="90">&#128276;</text></svg>')
        else:
            self.send_response(404)
            self.end_headers()

    def do_OPTIONS(self):
        self.send_response(200)
        self.send_header("Access-Control-Allow-Origin", "*")
        self.send_header("Access-Control-Allow-Methods", "GET, POST, OPTIONS")
        self.send_header("Access-Control-Allow-Headers", "Content-Type, Range")
        self.end_headers()

    def do_POST(self):
        parsed = urllib.parse.urlparse(self.path)
        if parsed.path == "/api/broadcast":
            try:
                content_length = int(self.headers.get("Content-Length", 0))
                audio_data = self.rfile.read(content_length)

                if len(audio_data) < 100:
                    self._send_json(400, {"status": "error", "message": "Audio data too short"})
                    return

                params = urllib.parse.parse_qs(parsed.query)
                play_chime = params.get("chime", ["1"])[0] == "1"

                client_ip = self.client_address[0]
                logger.info(f"Received live broadcast from {client_ip} ({len(audio_data)} bytes)")

                os.makedirs(DATA_DIR, exist_ok=True)
                with open(TEMP_WAV, "wb") as f:
                    f.write(audio_data)

                if self.server_instance and self.server_instance.on_broadcast_received:
                    self.server_instance.on_broadcast_received(client_ip, TEMP_WAV, play_chime)

                self._send_json(200, {"status": "ok", "message": "Broadcast received and playing"})
            except Exception as e:
                logger.error(f"Error handling broadcast: {e}")
                self._send_json(500, {"status": "error", "message": str(e)})
        else:
            self.send_response(404)
            self.end_headers()

    def _send_json(self, code, data):
        self.send_response(code)
        self.send_header("Content-Type", "application/json; charset=utf-8")
        self.send_header("Access-Control-Allow-Origin", "*")
        self.end_headers()
        self.wfile.write(json.dumps(data).encode("utf-8"))

class BroadcastServer:
    def __init__(self, http_port=5000, https_port=5443, on_broadcast_received=None):
        self.http_port = http_port
        self.https_port = https_port
        self.on_broadcast_received = on_broadcast_received
        self.lan_ip = get_local_lan_ip()
        self.httpd = None
        self.httpsd = None
        self.is_running = False
        self._threads = []

    def get_urls(self):
        return {
            "https": f"https://{self.lan_ip}:{self.https_port}",
            "http": f"http://{self.lan_ip}:{self.http_port}"
        }

    def start(self):
        if self.is_running:
            return

        BroadcastHandler.server_instance = self
        self.lan_ip = get_local_lan_ip()

        # 1. Start HTTPS server (Required by mobile browsers to grant microphone access)
        cert_file, key_file = ensure_ssl_certs()
        if cert_file and key_file and os.path.exists(cert_file) and os.path.exists(key_file):
            try:
                self.httpsd = ThreadingHTTPServer(('0.0.0.0', self.https_port), BroadcastHandler)
                context = ssl.SSLContext(ssl.PROTOCOL_TLS_SERVER)
                context.load_cert_chain(certfile=cert_file, keyfile=key_file)
                self.httpsd.socket = context.wrap_socket(self.httpsd.socket, server_side=True)

                t_https = threading.Thread(target=self.httpsd.serve_forever, daemon=True)
                t_https.start()
                self._threads.append(t_https)
                logger.info(f"HTTPS Broadcast server started at https://{self.lan_ip}:{self.https_port}")
            except Exception as e:
                logger.error(f"Failed to start HTTPS server: {e}")

        # 2. Start HTTP server
        try:
            self.httpd = ThreadingHTTPServer(('0.0.0.0', self.http_port), BroadcastHandler)
            t_http = threading.Thread(target=self.httpd.serve_forever, daemon=True)
            t_http.start()
            self._threads.append(t_http)
            logger.info(f"HTTP Broadcast server started at http://{self.lan_ip}:{self.http_port}")
        except Exception as e:
            logger.error(f"Failed to start HTTP server: {e}")

        self.is_running = True

    def stop(self):
        self.is_running = False
        if self.httpsd:
            try:
                self.httpsd.shutdown()
            except Exception:
                pass
        if self.httpd:
            try:
                self.httpd.shutdown()
            except Exception:
                pass
