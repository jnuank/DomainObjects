from domain.reserve_change_rule import ReserveChangeRule, ReservationStatus


class TestStatusChange:

    def test_仮予約から予約済みへ変更可能(self):
        rule = ReserveChangeRule()
        result = rule.CanChange(ReservationStatus.仮予約, ReservationStatus.予約済み)

        assert result is True

    def test_予約済みからキャンセルへ変更可能(self):
        rule = ReserveChangeRule()
        result = rule.CanChange(ReservationStatus.予約済み, ReservationStatus.キャンセル済み)

        assert result is True

    def test_キャンセル済みから仮予約は変更不可(self):
        rule = ReserveChangeRule()
        result = rule.CanChange(ReservationStatus.キャンセル済み, ReservationStatus.仮予約)

        assert result is False
