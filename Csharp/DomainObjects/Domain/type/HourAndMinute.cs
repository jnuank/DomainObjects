using System;
using System.Reflection.Metadata.Ecma335;

namespace DomainObjects.Domain.type
{
    /// <summary>
    /// 時分
    /// </summary>
    public class HourAndMinute : IEquatable<HourAndMinute>, IComparable<HourAndMinute>
    {
        private DateTime Value { get; set; }
        public int Hour { get; }
        public int Minute { get;  }

        public HourAndMinute(int hour, int minute)
        {
            if (hour < 0 || hour > 23) throw new ArgumentException($"{nameof(hour)}は0〜23の間にしてください");
            if (minute < 0 || minute > 59) throw new ArgumentException($"{nameof(minute)}は0〜59の間にしてください");
            
            Hour = hour;
            Minute = minute;
        }

        public bool Equals(HourAndMinute other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return this.Hour == other.Hour && this.Minute == other.Minute;
        }

        public int CompareTo(HourAndMinute other)
        {
            if (other is null) return 1;

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

        public static bool operator <(HourAndMinute self, HourAndMinute other)
        {
            if (self is null || other is null) throw new ArgumentNullException();

            // self < other が trueになるかどうか
            return self.CompareTo(other) < 0;
        }

        public static bool operator >(HourAndMinute self, HourAndMinute other)
        {
            return other < self;
        }

        public static bool operator ==(HourAndMinute self, HourAndMinute other)
        {
            if (self is null)
            {
                return other is null;
            }
            if (other is null)
            {
                return false;
            }

            return self.Equals(other);
        }

        public static bool operator !=(HourAndMinute self, HourAndMinute other)
        {
            return !(self == other);
        }

        public static HourAndMinute operator -(HourAndMinute self, HourAndMinute other)
        {
            var minute = self.Minute - other.Minute;
            var hour = self.Hour - other.Hour;
            // 繰り下がり処理
            if (minute < 0)
            {
                hour--;
                minute += 60;
            }
            
            return new HourAndMinute(hour, minute);
        }    
    }
}