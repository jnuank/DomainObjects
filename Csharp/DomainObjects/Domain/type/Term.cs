using System;

namespace DomainObjects.Domain.type
{
    public class Term
    {
        private DateHourAndMinute _start;
        private DateHourAndMinute _end;

        public Term(DateHourAndMinute start, DateHourAndMinute end, DateTime 予約可能期間の起点日)
        {
            this._start = start;
            this._end = end;
        }

        /// <summary>
        /// 時間帯を計算して返す
        /// </summary>
        /// <returns></returns>
        public SpanOfTime SpanOfTime()
        {
            return new SpanOfTime(_start.HourAndMinute(), _end.HourAndMinute());
        }
    }
}