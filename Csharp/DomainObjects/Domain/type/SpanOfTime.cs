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
            Start = start;
            End = end;
        }
        public bool IsOverRap(SpanOfTime other)
        {
            if (this.Equals(other)) return true;
            if (this.End.CompareTo(other.Start) > 0) return true;
            return false;
        }


        public bool Equals(SpanOfTime other)
        {
            if (other == null) return false;
            if (ReferenceEquals(this, other)) return true;
            return this.Start.Equals(other.Start) 
                   && this.End.Equals(other.End);
        }

        public bool IsContains(SpanOfTime other)
        {
            if (this.Equals(other)) return true;
            return this.Start.CompareTo(other.Start) < 0
                   && this.End.CompareTo(other.End) > 0;
        }
    }
}