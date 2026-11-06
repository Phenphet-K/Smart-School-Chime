"""
Audio Player Module for School Telling Time
Plays .wav files using Windows native winsound in background threads
"""

import os
import threading
import logging
import winsound
from collections import deque
import app_paths
from audio_formats import playable_wave

logger = logging.getLogger("AudioPlayer")

class AudioPlayer:
    def __init__(self, base_dir=None):
        self.base_dir = base_dir or str(app_paths.INSTALL_DIR)
        self.sound_dir = os.path.join(base_dir, 'Sound') if base_dir else str(app_paths.SOUND_DIR)
        self._condition = threading.Condition(threading.RLock())
        self._queue = deque()
        self._current = None
        self._closed = False
        self._worker = threading.Thread(target=self._run, name='ChimeAudio', daemon=True)
        self._worker.start()

    def get_sound_path(self, *rel_path):
        return os.path.join(self.sound_dir, *rel_path)

    def get_bell_packs(self):
        bell_dir = self.get_sound_path("Bell")
        if os.path.exists(bell_dir):
            return sorted([d for d in os.listdir(bell_dir) if os.path.isdir(os.path.join(bell_dir, d))])
        return ["Sound01", "Sound02", "Sound03", "Sound04", "Sound05"]

    def get_thai_announcements(self):
        con_dir = self.get_sound_path("Thai", "ConTN")
        if os.path.exists(con_dir):
            return sorted([f for f in os.listdir(con_dir) if f.lower().endswith(".wav")])
        return []

    def get_eng_announcements(self):
        con_dir = self.get_sound_path("Eng", "ConTN")
        if os.path.exists(con_dir):
            return sorted([f for f in os.listdir(con_dir) if f.lower().endswith(".wav")])
        return []

    def _callback(self, callback, *args):
        if callback:
            try:
                callback(*args)
            except Exception:
                logger.exception('Audio callback failed')

    def _cancel_locked(self):
        cancelled = list(self._queue)
        self._queue.clear()
        for job in cancelled:
            job['cancel'].set()
        if self._current:
            self._current['cancel'].set()
        try:
            winsound.PlaySound(None, 0)
        except RuntimeError:
            logger.exception('Cannot stop audio output')
        return cancelled

    def stop(self):
        with self._condition:
            cancelled = self._cancel_locked()
            self._condition.notify_all()
        for job in cancelled:
            self._callback(job['cleanup'])

    def close(self):
        with self._condition:
            self._closed = True
        self.stop()
        self._worker.join(timeout=3)

    def is_playing(self):
        with self._condition:
            return bool(self._current or self._queue)

    def _play_file_sync(self, file_path, cancel):
        # Use asynchronous WinMM playback so cancellation is not tied to WAV duration.
        with playable_wave(file_path, cancel) as (filename, duration):
            with self._condition:
                if cancel.is_set():
                    return
                winsound.PlaySound(filename, winsound.SND_FILENAME | winsound.SND_ASYNC | winsound.SND_NODEFAULT)
            cancel.wait(duration)
            with self._condition:
                winsound.PlaySound(None, 0)

    def _run(self):
        while True:
            with self._condition:
                self._condition.wait_for(lambda: self._closed or self._queue)
                if self._closed:
                    return
                job = self._queue.popleft()
                self._current = job
            try:
                for filename in job['files']:
                    if job['cancel'].is_set():
                        break
                    self._play_file_sync(filename, job['cancel'])
                if not job['cancel'].is_set():
                    self._callback(job['finish'])
            except Exception as error:
                logger.exception('Audio playback failed')
                self._callback(job['error'], error)
            finally:
                self._callback(job['cleanup'])
                with self._condition:
                    self._current = None
                    self._condition.notify_all()

    def _build_time_thai(self, hour, minute):
        files = []
        files.append(self.get_sound_path("Thai", "Now.wav"))
        files.append(self.get_sound_path("Thai", f"{int(hour)}.wav"))
        files.append(self.get_sound_path("Thai", "OClock.wav"))
        m_int = int(minute)
        files.append(self.get_sound_path("Thai", f"{m_int}.wav"))
        if m_int != 0:
            files.append(self.get_sound_path("Thai", "Minute.wav"))
        return files

    def _build_time_eng(self, hour, minute):
        files = []
        files.append(self.get_sound_path("Eng", "Now.wav"))
        h_int = int(hour)
        m_int = int(minute)
        if m_int == 30:
            files.append(self.get_sound_path("Eng", "HalfPast.wav"))
            files.append(self.get_sound_path("Eng", f"{h_int}.wav"))
        else:
            files.append(self.get_sound_path("Eng", f"{h_int}.wav"))
            files.append(self.get_sound_path("Eng", f"{m_int}.wav"))
        return files

    def play_sequence_async(self, file_list, on_finish=None, *, enqueue=False,
                            on_cleanup=None, on_error=None):
        job = dict(files=list(file_list), finish=on_finish, cleanup=on_cleanup,
                   error=on_error, cancel=threading.Event())
        cancelled = []
        with self._condition:
            if self._closed:
                raise RuntimeError('Audio player is closed')
            if enqueue and len(self._queue) >= 64:
                raise RuntimeError('Audio queue is full')
            if not enqueue:
                cancelled = self._cancel_locked()
            self._queue.append(job)
            self._condition.notify_all()
        for previous in cancelled:
            self._callback(previous['cleanup'])
        return job['cancel']

    def play_bell(self, bell_pack, kind="First", on_finish=None):
        file_path = self.get_sound_path("Bell", bell_pack, f"{kind}.wav")
        self.play_sequence_async([file_path], on_finish)

    def play_slot_event(self, slot_data, bell_pack="Sound01", voice_lang="thai", on_finish=None, *, enqueue=False, on_error=None, on_cleanup=None):
        """
        Executes sequence for a slot:
        1. First bell (if enabled)
        2. Time announcement (Thai/Eng) (if enabled)
        3. Custom announcement ConTN (if enabled)
        4. Last bell (if enabled)
        """
        seq = []
        hour = slot_data.get("hour", "08")
        minute = slot_data.get("minute", "00")

        # 1. First bell
        if slot_data.get("sound_first"):
            seq.append(self.get_sound_path("Bell", bell_pack, "First.wav"))

        # 2. Time voice
        if slot_data.get("sound_time"):
            if voice_lang in ("thai", "both"):
                seq.extend(self._build_time_thai(hour, minute))
            if voice_lang in ("eng", "both"):
                seq.extend(self._build_time_eng(hour, minute))

        # 3. Custom announcement (ConTN)
        if slot_data.get("sound_con"):
            if voice_lang in ("thai", "both") and slot_data.get("sound_data"):
                f = self.get_sound_path("Thai", "ConTN", slot_data["sound_data"])
                seq.append(f)
            if voice_lang in ("eng", "both") and slot_data.get("sound_data_eng"):
                f = self.get_sound_path("Eng", "ConTN", slot_data["sound_data_eng"])
                seq.append(f)

        # 4. Last bell
        if slot_data.get("sound_last"):
            seq.append(self.get_sound_path("Bell", bell_pack, "Last.wav"))

        return self.play_sequence_async(seq, on_finish, enqueue=enqueue, on_error=on_error, on_cleanup=on_cleanup)

    def test_single_file(self, full_or_rel_path, on_finish=None):
        if not os.path.isabs(full_or_rel_path):
            full_or_rel_path = self.get_sound_path(full_or_rel_path)
        self.play_sequence_async([full_or_rel_path], on_finish)
