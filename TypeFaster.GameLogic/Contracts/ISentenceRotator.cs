using System;
using System.Collections.Generic;
using System.Text;
using TypeFaster.Domain.Entities;

namespace TypeFaster.GameLogic.Contracts
{
    public interface ISentenceRotator
    {
        Sentence GetNextSentence();
    }
}
