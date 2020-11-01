using System;

namespace DomainObjects.Domain.type
{
    public class Time : IEquatable<Time>, IComparable<Time>
    {
        private DateTime Value { get; set; }
        public int Hour { get; }
        public int Minute { get;  }

        public Time(int hour, int minute)
        {
            if (hour < 0 || hour > 23) throw new ArgumentException($"{nameof(hour)}は0〜23の間にしてください");
            if (minute < 0 || minute > 59) throw new ArgumentException($"{nameof(minute)}は0〜59の間にしてください");
            
            Hour = hour;
            Minute = minute;
        }

        public bool Equals(Time other)
        {
            if (other == null) return false;
            if (ReferenceEquals(this, other)) return true;
            return this.Hour == other.Hour && this.Minute == other.Minute;
        }

        public int CompareTo(Time other)
        {
            if (other == null) return 1;

            if (ReferenceEquals(this, other)) return 0;

            var hourCompareResult = this.Hour.CompareTo(other.Hour);
            if (hourCompareResult == 0)
            {
                return this.Minute.CompareTo(other.Minute);
            }
            else
            {
                return hourCompareResult;
            }
        }
        //
        // public static bool operator <(時分 self, 時分 other)
        // {
        //     if (self.CompareTo(other) > 0) return
        // }
    }
}