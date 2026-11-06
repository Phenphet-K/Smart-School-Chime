"""
NVDA Screen Reader Integration Helper for Smart School Chime
Connects directly to NVDA Controller API via ctypes if available,
with graceful fallback if NVDA is not running.
"""

import os
import sys
import ctypes
import threading
import logging

logger = logging.getLogger("NVDAHelper")

class NVDAClient:
    def __init__(self):
        self._dll = None
        self._is_available = False
        self._init_dll()

    def _init_dll(self):
        """Locate and load nvdaControllerClient DLL"""
        possible_dirs = [
            os.path.dirname(os.path.abspath(__file__)),
            os.path.join(os.environ.get("ProgramFiles", "C:\\Program Files"), "NVDA"),
            os.path.join(os.environ.get("ProgramFiles(x86)", "C:\\Program Files (x86)"), "NVDA"),
            os.path.join(os.environ.get("APPDATA", ""), "nvda"),
            os.path.join(os.environ.get("LOCALAPPDATA", ""), "Programs", "NVDA")
        ]

        dll_names = [
            "nvdaControllerClient64.dll" if sys.maxsize > 2**32 else "nvdaControllerClient32.dll",
            "nvdaControllerClient.dll",
            "nvdaControllerClient64.dll",
            "nvdaControllerClient32.dll"
        ]

        # 2. Try known directory paths
        for p_dir in possible_dirs:
            if not os.path.exists(p_dir):
                continue
            for name in dll_names:
                candidate = os.path.join(p_dir, name)
                if os.path.exists(candidate):
                    try:
                        self._dll = ctypes.windll.LoadLibrary(candidate)
                        for name, arguments in {
                            'nvdaController_testIfRunning': [],
                            'nvdaController_cancelSpeech': [],
                            'nvdaController_speakText': [ctypes.c_wchar_p],
                            'nvdaController_brailleMessage': [ctypes.c_wchar_p],
                        }.items():
                            function = getattr(self._dll, name)
                            function.argtypes = arguments
                            function.restype = ctypes.c_int
                        self._is_available = True
                        return
                    except Exception:
                        continue

    def is_running(self) -> bool:
        """Check if NVDA screen reader is actively running"""
        if not self._dll:
            self._init_dll()
        if self._dll:
            try:
                return self._dll.nvdaController_testIfRunning() == 0
            except Exception:
                return False
        return False

    def speak(self, text: str, cancel: bool = False) -> bool:
        """Speak text through NVDA speech engine"""
        if not text:
            return False
        if not self.is_running():
            return False
        try:
            if cancel:
                self._dll.nvdaController_cancelSpeech()
            # nvdaController_speakText takes a wchar_t* string
            res = self._dll.nvdaController_speakText(str(text))
            return res == 0
        except Exception as e:
            logger.debug(f"Error speaking to NVDA: {e}")
            return False

    def cancel_speech(self) -> bool:
        """Cancel ongoing speech in NVDA"""
        if self.is_running():
            try:
                return self._dll.nvdaController_cancelSpeech() == 0
            except Exception:
                pass
        return False

    def braille_message(self, text: str) -> bool:
        """Output text to braille display via NVDA"""
        if self.is_running():
            try:
                return self._dll.nvdaController_brailleMessage(str(text)) == 0
            except Exception:
                pass
        return False

# Global singleton
nvda = NVDAClient()

