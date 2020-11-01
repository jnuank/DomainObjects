using System;

namespace DomainObjects.Domain.type
{
    public class 開始年月日時分
    {
        public DateTime Value { get; }

        public 開始年月日時分(int year, int month, int day, int hour, int minute)
        {
            this.Value = new DateTime(year, month, day, hour, minute, 0);
        }
    }
}