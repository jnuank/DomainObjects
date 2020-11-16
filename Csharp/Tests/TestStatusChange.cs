using System;
using System.Collections;
using System.Collections.Generic;
using DomainObjects.Domain.rule;
using DomainObjects.Domain.type;
using Xunit;
using Xunit.Abstractions;

namespace Tests
{
    public class TestStatusChange
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public TestStatusChange(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void 仮予約から予約済みへ変更可能()
        {
            var rule = new ReserveChangeRule();
            var result = rule.CanChange(ReservationStatus.仮予約, ReservationStatus.予約済み);
            
            Assert.True(result);
        }
        [Fact]
        public void 予約済みからキャンセル済みへ変更可能()
        {
            var rule = new ReserveChangeRule();
            var result = rule.CanChange(ReservationStatus.予約済み, ReservationStatus.キャンセル済み);
            
            Assert.True(result);
        }
        [Fact]
        public void キャンセル済みから仮予約は変更不可()
        {
            var rule = new ReserveChangeRule();
            var result = rule.CanChange(ReservationStatus.キャンセル済み, ReservationStatus.仮予約);
            
            Assert.True(!result);
        }
    
    }

}