using System;

namespace GameDomain
{
    public struct Score
    {
        public Score(uint value, DateTimeOffset date)
        {
            this.Value = value;
            this.Date = date;
        }

        public uint Value { get; }

        public DateTimeOffset Date { get; }
    }
}
