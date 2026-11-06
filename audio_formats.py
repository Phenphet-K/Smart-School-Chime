"""Bounded RIFF WAV inspection and float-to-PCM compatibility for WinMM."""
import array
from contextlib import contextmanager
from dataclasses import dataclass
import math
import os
import struct
import sys
import tempfile
import wave


@dataclass(frozen=True)
class WaveInfo:
    format: int
    channels: int
    rate: int
    bits: int
    offset: int
    size: int
    block_align: int

    @property
    def duration(self):
        return self.size / (self.rate * self.block_align)


def inspect_wave(filename):
    total = os.path.getsize(filename)
    with open(filename, 'rb') as stream:
        header = stream.read(12)
        if len(header) != 12 or header[:4] != b'RIFF' or header[8:] != b'WAVE':
            raise ValueError('Expected RIFF WAV')
        limit = struct.unpack_from('<I', header, 4)[0] + 8
        if limit > total:
            raise ValueError('Truncated RIFF')
        fmt = data = None
        while stream.tell() + 8 <= limit:
            tag, size = struct.unpack('<4sI', stream.read(8))
            offset = stream.tell()
            if offset + size > limit:
                raise ValueError('Truncated WAV chunk')
            if tag == b'fmt ':
                if size < 16:
                    raise ValueError('Invalid WAV format header')
                fmt = struct.unpack('<HHIIHH', stream.read(16))
            elif tag == b'data':
                data = (offset, size)
            stream.seek(offset + size + size % 2)
        if fmt is None or data is None:
            raise ValueError('Missing WAV format or audio data')
        kind, channels, rate, byte_rate, align, bits = fmt
        if (kind not in (1, 3) or not 1 <= channels <= 2 or not 8000 <= rate <= 192000
                or bits not in ((8, 16, 24, 32) if kind == 1 else (32, 64))
                or align != channels * bits // 8 or byte_rate != rate * align
                or data[1] == 0 or data[1] % align):
            raise ValueError('Unsupported or inconsistent WAV format')
        return WaveInfo(kind, channels, rate, bits, *data, align)


@contextmanager
def playable_wave(filename, cancel):
    info = inspect_wave(filename)
    if info.format == 1:
        yield str(filename), info.duration
        return
    temporary = None
    try:
        with tempfile.NamedTemporaryFile(suffix='.wav', prefix='chime-pcm-', delete=False) as stream:
            temporary = stream.name
        with open(filename, 'rb') as source, wave.open(temporary, 'wb') as target:
            source.seek(info.offset)
            target.setparams((info.channels, 2, info.rate, 0, 'NONE', 'not compressed'))
            remaining = info.size
            while remaining and not cancel.is_set():
                block = source.read(min(65536, remaining))
                remaining -= len(block)
                samples = array.array('h')
                for (sample,) in struct.iter_unpack('<f' if info.bits == 32 else '<d', block):
                    sample = sample if math.isfinite(sample) else 0
                    sample = max(-1.0, min(1.0, sample))
                    samples.append(round(sample * (32768 if sample < 0 else 32767)))
                if sys.byteorder != 'little':
                    samples.byteswap()
                target.writeframesraw(samples.tobytes())
        yield temporary, info.duration
    finally:
        if temporary:
            os.unlink(temporary)
