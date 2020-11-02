using System;

namespace DomainObjects.Domain.type
{
    /// <summary>
    /// 時間帯
    /// </summary>
    public class SpanOfTime : IEquatable<SpanOfTime>
    {
        private HourAndMinute Start { get; }
        private HourAndMinute End { get; }

        public SpanOfTime(HourAndMinute start, HourAndMinute end)
        {
            if (end < start) throw new ArgumentException("endはstartより遅い時間にしてください");
            Start = start;
            End = end;
        }
        
        /// <summary>
        /// otherと時間帯が重なっているか判定する
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool IsOverRap(SpanOfTime other)
        {
            if (this.Equals(other)) return true;
            return End > other.Start;
        }


        public bool Equals(SpanOfTime other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Start == other.Start && End == other.End;
        }

        /// <summary>
        /// otherの時間帯を完全に含んでいるか
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool IsContains(SpanOfTime other)
        {
            if (this.Equals(other)) return true;
            return Start < other.Start && other.End < End;
        }


        public int Hours()
        {
            return End.Hour - Start.Hour;
        }

        public int Minutes()
        {
            return 45;
        }
    }
}