using System;
using System.Collections.Generic;
using TypeFaster.Domain.ValueObjects;

namespace TypeFaster.Domain.Entities
{
    public class TypingRaceData
    {
        public string Title { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Sentence Sentence { get; set; }
        public string UserInput { get; set; }
        public IDictionary<int, string> Typos
        { get; set; } = new Dictionary<int, string>();
    }
}
