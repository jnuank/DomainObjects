using DomainObjects.Domain.type;
using Xunit;

namespace Tests
{
    public class Test時分
    {
        [Fact]
        public void 十時の方が小さい()
        {
            var sut = new Time(10, 0);
            var other = new Time(12, 0);
            
            Assert.True(sut.CompareTo(other) < 0);
        }
        [Fact]
        public void どちらも同じ()
        {
            var sut = new Time(12, 0);
            var other = new Time(12, 0);
            
            Assert.True(sut.CompareTo(other) == 0);
        }
        [Fact]
        public void 四十五分の方が大きい()
        {
            var sut = new Time(12, 45);
            var other = new Time(12, 0);
            
            Assert.True(sut.CompareTo(other) > 0);
        }
    }
}