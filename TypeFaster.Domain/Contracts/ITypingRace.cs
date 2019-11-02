using System;
using System.Collections.Generic;
using System.Text;
using TypeFaster.Domain.Entities;

namespace TypeFaster.Domain.Contracts
{
    public interface ITypingRace
    {
        string Title { get; set; }
        DateTime StartTime { get; set; }
        DateTime EndTime { get; set; }
        Sentence Sentence { get; set; }
        string UserInput { get; set; }
        IList<string> Typos { get; set; }
    }
}
