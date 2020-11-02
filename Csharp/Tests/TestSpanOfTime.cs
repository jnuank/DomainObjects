using System;
using System.Collections;
using System.Collections.Generic;
using DomainObjects.Domain.type;
using Xunit;
using Xunit.Abstractions;

namespace Tests
{
    public class TestSpanOfTime
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public TestSpanOfTime(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void 何時間か取得できる()
        {
            var start = new HourAndMinute(10, 45);
            var end = new HourAndMinute(13, 15);
            
            var span = new SpanOfTime(start, end);
            HourAndMinute sut = span.Difference();
            
            Assert.Equal(2, sut.Hour);
            Assert.Equal(30, sut.Minute);
        }
        
        [Fact]
        public void StartがEndより遅い場合はエラーとなる()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var sut = new SpanOfTime(
                        start: new HourAndMinute(23, 59),
                        end: new HourAndMinute(9, 0)
                    );
                
            });
        }
        
        [Theory]
        [ClassData(typeof(利用時間帯テストデータ))]
        public void 利用時間帯の比較テストNGパターン(HourAndMinute sut_start, HourAndMinute sut_end, HourAndMinute other_start, HourAndMinute other_end)
        {
            var sut = new SpanOfTime(sut_start, sut_end);
            var other = new SpanOfTime(other_start, other_end);

            Assert.True(sut.IsOverRap(other));
        }

        [Theory]
        [ClassData(typeof(利用時間帯IsContainsデータ))]
        public void 利用時間帯のIsContains成功パターン(HourAndMinute sut_start, HourAndMinute sut_end, HourAndMinute other_start, HourAndMinute other_end)
        {
            var sut = new SpanOfTime(sut_start, sut_end);
            var other = new SpanOfTime(other_start, other_end);

            Assert.True(sut.IsContains(other));
        }
        [Theory]
        [ClassData(typeof(利用時間帯IsContains失敗データ))]
        public void 利用時間帯のIsContains失敗パターン(HourAndMinute sut_start, HourAndMinute sut_end, HourAndMinute other_start, HourAndMinute other_end)
        {
            var sut = new SpanOfTime(sut_start, sut_end);
            var other = new SpanOfTime(other_start, other_end);

            Assert.False(sut.IsContains(other));
        }
    }

    public class 利用時間帯テストデータ : IEnumerable<object[]>
    {
        List<object[]> _testData = new List<object[]>();

        public 利用時間帯テストデータ()
        {
            _testData.Add(new object[]
            {
                new HourAndMinute(10,0),new HourAndMinute(12, 0),  // |========    |
                new HourAndMinute(11, 0), new HourAndMinute(14, 0),// |    ========|
            });
            _testData.Add(new object[]
            {
                new HourAndMinute(10,0),new HourAndMinute(12, 0),  // |    ========|
                new HourAndMinute(9, 0), new HourAndMinute(11, 0), // |========    |
            });
            _testData.Add(new object[]
            {
                new HourAndMinute(10,0),new HourAndMinute(12, 0),  // |============|
                new HourAndMinute(10, 0), new HourAndMinute(12, 0),// |============|
            });
            _testData.Add(new object[]
            {
                new HourAndMinute(10,0),new HourAndMinute(12, 0),   // |============|
                new HourAndMinute(11, 0), new HourAndMinute(11, 45),// |    =====   |
            });
            _testData.Add(new object[]
            {
                new HourAndMinute(10,0),new HourAndMinute(12, 0),  // |    =====   |
                new HourAndMinute(9, 0), new HourAndMinute(16, 0), // |============|
            });
            
        }
        public IEnumerator<object[]> GetEnumerator() => _testData.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        
    }
    
    public class 利用時間帯IsContainsデータ : IEnumerable<object[]>
    {
        List<object[]> _testData = new List<object[]>();

        public 利用時間帯IsContainsデータ()
        {
            _testData.Add(new object[]
            {
                new HourAndMinute(10,0),new HourAndMinute(12, 0),  // |============|
                new HourAndMinute(10, 0), new HourAndMinute(12, 0),// |============|
            });
            _testData.Add(new object[]
            {
                new HourAndMinute(10,0),new HourAndMinute(12, 0),   // |============|
                new HourAndMinute(11, 0), new HourAndMinute(11, 45),// |    =====   |
            });
            
        }
        public IEnumerator<object[]> GetEnumerator() => _testData.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        
    }
    
    public class 利用時間帯IsContains失敗データ : IEnumerable<object[]>
    {
        List<object[]> _testData = new List<object[]>();

        public 利用時間帯IsContains失敗データ()
        {    
            _testData.Add(new object[]
            {
                new HourAndMinute(10,0),new HourAndMinute(12, 0),  // |========    |
                new HourAndMinute(11, 0), new HourAndMinute(14, 0),// |    ========|
            });
            _testData.Add(new object[]
            {
                new HourAndMinute(10,0),new HourAndMinute(12, 0),  // |    ========|
                new HourAndMinute(9, 0), new HourAndMinute(11, 0), // |========    |
            });
            _testData.Add(new object[]
            {
                new HourAndMinute(10,0),new HourAndMinute(12, 0),  // |    =====   |
                new HourAndMinute(9, 0), new HourAndMinute(16, 0), // |============|
            });
            
        }
        public IEnumerator<object[]> GetEnumerator() => _testData.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        
    }

}