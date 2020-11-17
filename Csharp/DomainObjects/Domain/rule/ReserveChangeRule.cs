using System;
using System.Collections.Generic;
using System.Xml.Schema;

namespace DomainObjects.Domain.rule
{
    /// <summary>
    /// ステータス変更ルールの表条件
    /// </summary>
    public class ReserveChangeRule
    {
        Dictionary<ReservationStatus, HashSet<ReservationStatus>> map = new Dictionary<ReservationStatus,HashSet<ReservationStatus>>();

        public ReserveChangeRule()
        {
            define(ReservationStatus.仮予約, Enum.GetValues() .仮予約, ReservationStatus.キャンセル済み,]);
            map.Add(ReservationStatus.仮予約, new HashSet<ReservationStatus>() {ReservationStatus.予約済み});
            map.Add(ReservationStatus.予約済み, new HashSet<ReservationStatus>() {ReservationStatus.キャンセル済み});
            map.Add(ReservationStatus.キャンセル済み, new HashSet<ReservationStatus>() {});
        }
        
        

        public bool CanChange(ReservationStatus from, ReservationStatus to)
        {
            var allowedStatus = map[from];
            return allowedStatus.Contains(to);
        }
    }

    public enum ReservationStatus
    {
        仮予約,
        予約済み,
        キャンセル済み,
    }
}