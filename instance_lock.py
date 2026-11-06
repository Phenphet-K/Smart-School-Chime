"""One application process per writable data directory on Windows."""
import ctypes
from ctypes import wintypes
import hashlib
import os


class InstanceLock:
    def __init__(self, directory):
        self._kernel = ctypes.WinDLL('kernel32', use_last_error=True)
        self._kernel.CreateMutexW.argtypes = [ctypes.c_void_p, wintypes.BOOL, wintypes.LPCWSTR]
        self._kernel.CreateMutexW.restype = wintypes.HANDLE
        self._kernel.CloseHandle.argtypes = [wintypes.HANDLE]
        self._kernel.CloseHandle.restype = wintypes.BOOL
        key = hashlib.sha256(os.path.normcase(os.path.abspath(directory)).encode('utf-8')).hexdigest()
        self._handle = self._kernel.CreateMutexW(None, False, 'Local\\SmartSchoolChime-' + key)
        error = ctypes.get_last_error()
        if not self._handle:
            raise ctypes.WinError(error)
        self.acquired = error != 183
        if not self.acquired:
            self.close()

    def close(self):
        if self._handle:
            self._kernel.CloseHandle(self._handle)
            self._handle = None
