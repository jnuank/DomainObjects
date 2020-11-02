using DomainObjects.Domain.type;
using Xunit;

namespace Tests
{
    public class TestHourAndMinute
    {
        [Fact]
        public void 十時の方が小さい()
        {
            var sut = new HourAndMinute(10, 0);
            var other = new HourAndMinute(12, 0);
            
            Assert.True(sut < other);
        }
        [Fact]
        public void どちらも同じ()
        {
            var sut = new HourAndMinute(12, 0);
            var other = new HourAndMinute(12, 0);
            
            Assert.True(sut == other);
        }
        [Fact]
        public void 四十五分の方が大きい()
        {
            var sut = new HourAndMinute(12, 45);
            var other = new HourAndMinute(12, 0);
            
            Assert.True(sut > other);
        }
        [Fact]
        public void null比較()
        {
           
            HourAndMinute sut = null;
            HourAndMinute other = null;

            Assert.True(sut == other);
        }

        [Fact]
        public void 時間が一緒ではない()
        { 
            var sut = new HourAndMinute(0, 0);
            var other = new HourAndMinute(23, 59);

            Assert.True(sut != other);
            
        }

        [Fact]
        public void 時分の差を計算する()
        {
            var sut = new HourAndMinute(10, 45);
            var other = new HourAndMinute(13, 15);

            var result = other - sut;
            
            Assert.Equal(2, result.Hour);
            Assert.Equal(30, result.Minute);
        }
    }
}