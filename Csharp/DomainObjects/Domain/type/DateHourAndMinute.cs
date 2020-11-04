using System;

namespace DomainObjects.Domain.type
{
    /// <summary>
    /// 年月日時分
    /// </summary>
    public class DateHourAndMinute
    {
        public DateTime Value { get; }

        public DateHourAndMinute(int year, int month, int day, int hour, int minute)
        {
            this.Value = new DateTime(year, month, day, hour, minute, 0);
        }

        
        public HourAndMinute HourAndMinute()
        {
            return new HourAndMinute(Value.Hour, Value.Minute);
        }
    }
}