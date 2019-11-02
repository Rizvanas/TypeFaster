using System;
using System.Collections.Generic;
using System.Text;
using TypeFaster.Domain.Contracts;

namespace TypeFaster.Domain.Entities
{
    public class ClassicTypingRace : ITypingRace
    {
        public string Title { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Sentence Sentence { get; set; }
        public string UserInput { get; set; }
        public IList<string> Typos { get; set; } = new List<string>();
    }
}
