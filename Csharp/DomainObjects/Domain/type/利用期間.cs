using System;

namespace DomainObjects.Domain.type
{
    public class 利用期間
    {
        // private 開始年月日時分 かいしねんがっぴじふん;
        // private 終了年月日時分 しゅうりょうねんがっぴじふん;
        private 開始年月日時分 _開始年月日時分;
        private 終了年月日時分 _終了年月日時分;

        public 利用期間(開始年月日時分 開始年月日時分, 終了年月日時分 終了年月日時分, DateTime 予約可能期間の起点日)
        {
            this._開始年月日時分 = 開始年月日時分;
            this._終了年月日時分 = 終了年月日時分;
        }

        public 利用時間帯 りようじかんたい()
        {
            Time かいしじふん = new Time(_開始年月日時分.Value.Hour, _開始年月日時分.Value.Minute);
            Time しゅうりょうじふん = new Time(_終了年月日時分.Value.Hour, _終了年月日時分.Value.Minute);
            return new 利用時間帯(かいしじふん, しゅうりょうじふん);
        }
    }
}