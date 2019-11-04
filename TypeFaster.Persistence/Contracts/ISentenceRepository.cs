using System;
using System.Collections.Generic;
using System.Text;
using TypeFaster.Domain.Entities;

namespace TypeFaster.Persistence.Contracts
{
    public interface ISentenceRepository
    {
        int SentencesCount { get; }
        IList<Sentence> GetAllSentences();
        Sentence GetSentenceById(int sentence_id);
    }
}
