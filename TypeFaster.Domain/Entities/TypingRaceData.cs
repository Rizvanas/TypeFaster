using System;
using System.Collections.Generic;

namespace TypeFaster.Domain.Entities
{
    public class TypingRaceData
    {
        public string Title { get; set; }
        public TimeSpan Duration { get; set; }
        public Sentence Sentence { get; set; }
        public string UserInput { get; set; }
        public int TypingSpeed { get; set; }
        public decimal TypingAccuracy { get; set; }
        public IDictionary<int, string> Typos
        { get; set; } = new Dictionary<int, string>();
    }
}
