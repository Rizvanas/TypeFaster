using System.Collections.Generic;
using TypeFaster.Domain.Entities;

namespace TypeFaster.GameServices.Contracts
{
    public interface ISentenceService
    {
        IList<Sentence> GetShuffledSentenceList();
    }
}
