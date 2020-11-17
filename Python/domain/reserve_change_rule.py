import enum
from dataclasses import dataclass
from typing import Dict, Set


class ReservationStatus(enum.Enum):
    仮予約 = enum.auto()
    予約済み = enum.auto()
    キャンセル済み = enum.auto()

@dataclass
class ReserveChangeRule:
    map: Dict[ReservationStatus, Set[ReservationStatus]]

    def __init__(self):
        self.map = {
            ReservationStatus.仮予約: {ReservationStatus.予約済み, },
            ReservationStatus.予約済み: {ReservationStatus.キャンセル済み, },
            ReservationStatus.キャンセル済み: {},
        }

    def CanChange(self, _from, _to) -> bool:
        return _to in self.map[_from]
