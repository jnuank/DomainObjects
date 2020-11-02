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
            if (this.End.CompareTo(other.Start) > 0) return true;
            return false;
        }


        public bool Equals(SpanOfTime other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return this.Start.Equals(other.Start) 
                   && this.End.Equals(other.End);
        }

        /// <summary>
        /// otherの時間帯を完全に含んでいるか
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool IsContains(SpanOfTime other)
        {
            if (this.Equals(other)) return true;
            return this.Start < other.Start && other.End < this.End;
        }
    }
}