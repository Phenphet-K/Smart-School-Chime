"""
Audio Player Module for School Telling Time
Plays .wav files using Windows native winsound in background threads
"""

import os
import sys
import time
import threading
import logging
import winsound

logger = logging.getLogger("AudioPlayer")

class AudioPlayer:
    def __init__(self, base_dir=None):
        if base_dir is None:
            base_dir = os.path.dirname(os.path.abspath(__file__))
        self.base_dir = base_dir
        
        # Search for Sound folder (/sound or /Sound)
        possible_paths = [
            os.path.join(self.base_dir, "sound"),
            os.path.join(self.base_dir, "Sound"),
            os.path.join(os.getcwd(), "sound"),
            os.path.join(os.getcwd(), "Sound"),
            "C:\\sound",
            "C:\\Sound"
        ]
        self.sound_dir = None
        for p in possible_paths:
            if os.path.exists(p):
                self.sound_dir = p
                break
        
        if not self.sound_dir:
            self.sound_dir = os.path.join(self.base_dir, "Sound")
            
        self._is_playing = False
        self._stop_event = threading.Event()
        self._current_thread = None

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

    def stop(self):
        """Stop current audio playback"""
        self._stop_event.set()
        try:
            winsound.PlaySound(None, winsound.SND_PURGE)
        except Exception:
            pass
        self._is_playing = False

    def is_playing(self):
        return self._is_playing

    def _play_file_sync(self, file_path):
        if self._stop_event.is_set():
            return
        if os.path.exists(file_path):
            try:
                winsound.PlaySound(file_path, winsound.SND_FILENAME)
            except Exception as e:
                logger.error(f"Error playing {file_path}: {e}")
        else:
            logger.warning(f"Audio file not found: {file_path}")

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

    def play_sequence_async(self, file_list, on_finish=None):
        """Play a list of .wav files consecutively in background thread"""
        self.stop()
        self._stop_event.clear()

        def runner():
            self._is_playing = True
            try:
                for f in file_list:
                    if self._stop_event.is_set():
                        break
                    self._play_file_sync(f)
            finally:
                self._is_playing = False
                if on_finish and not self._stop_event.is_set():
                    try:
                        on_finish()
                    except Exception:
                        pass

        self._current_thread = threading.Thread(target=runner, daemon=True)
        self._current_thread.start()

    def play_bell(self, bell_pack, kind="First", on_finish=None):
        file_path = self.get_sound_path("Bell", bell_pack, f"{kind}.wav")
        self.play_sequence_async([file_path], on_finish)

    def play_slot_event(self, slot_data, bell_pack="Sound01", voice_lang="thai", on_finish=None):
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
                if os.path.exists(f):
                    seq.append(f)
            if voice_lang in ("eng", "both") and slot_data.get("sound_data_eng"):
                f = self.get_sound_path("Eng", "ConTN", slot_data["sound_data_eng"])
                if os.path.exists(f):
                    seq.append(f)

        # 4. Last bell
        if slot_data.get("sound_last"):
            seq.append(self.get_sound_path("Bell", bell_pack, "Last.wav"))

        self.play_sequence_async(seq, on_finish)

    def test_single_file(self, full_or_rel_path, on_finish=None):
        if not os.path.isabs(full_or_rel_path):
            full_or_rel_path = self.get_sound_path(full_or_rel_path)
        self.play_sequence_async([full_or_rel_path], on_finish)
