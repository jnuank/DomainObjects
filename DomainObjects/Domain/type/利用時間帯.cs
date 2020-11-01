using System;

namespace DomainObjects.Domain.type
{
    public class 利用時間帯 : IEquatable<利用時間帯>
    {
        public Time _かいしじふん { get; }
        public Time _しゅうりょうじふん { get; }

        public 利用時間帯(Time かいしじふん, Time しゅうりょうじふん )
        {
            _かいしじふん = かいしじふん;
            _しゅうりょうじふん = しゅうりょうじふん;
        }
        
        // public class 利用時間帯

        public bool IsOverrap(利用時間帯 other)
        {
            if (this.Equals(other)) return true;
            if (this._しゅうりょうじふん.CompareTo(other._かいしじふん) > 0) return true;
            return false;
        }


        public bool Equals(利用時間帯 other)
        {
            if (other == null) return false;
            if (ReferenceEquals(this, other)) return true;
            return this._かいしじふん.Equals(other._かいしじふん) 
                   && this._しゅうりょうじふん.Equals(other._しゅうりょうじふん);
        }

        public bool IsContains(利用時間帯 other)
        {
            if (this.Equals(other)) return true;
            return this._かいしじふん.CompareTo(other._かいしじふん) < 0
                   && this._しゅうりょうじふん.CompareTo(other._しゅうりょうじふん) > 0;
        }
    }
}