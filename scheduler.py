"""Clock policy independent of Tk. Late bells expire after 15 seconds."""


class MinuteScheduler:
    def __init__(self, grace_seconds=15):
        self.grace_seconds = grace_seconds
        self.last_check = None

    def due(self, now):
        minute = now.replace(second=0, microsecond=0)
        previous = self.last_check
        self.last_check = now
        if previous is not None and now <= previous:
            return []
        return [minute] if ((previous is None or previous < minute)
                            and 0 <= (now - minute).total_seconds() <= self.grace_seconds) else []
