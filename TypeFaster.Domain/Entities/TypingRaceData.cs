using System;
using System.Collections.Generic;

namespace TypeFaster.Domain.Entities
{
    public class TypingRaceData
    {
        public string Title { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Sentence Sentence { get; set; }
        public Sentence UserInput { get; set; }
        public int TotalKeyStrokes { get; set; }
        public IDictionary<int, string> Typos 
        { get; set; } = new Dictionary<int, string>();
    }
}
