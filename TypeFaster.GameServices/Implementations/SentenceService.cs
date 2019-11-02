using System;
using System.Collections.Generic;
using System.Linq;
using TypeFaster.Common.Extensions;
using TypeFaster.Domain.Entities;
using TypeFaster.GameServices.Contracts;
using TypeFaster.Persistence.Contracts;

namespace TypeFaster.GameServices.Implementations
{
    public class SentenceService : ISentenceService
    {
        private readonly ISentenceRepository _sentenceRepository;

        public SentenceService(ISentenceRepository sentenceRepository)
        {
            _sentenceRepository = sentenceRepository;
        }

        public IList<Sentence> GetShuffledSentenceList()
        {
            return _sentenceRepository
                .GetAllSentences()
                .Shuffle(new Random())
                .ToList();
        }
    }
}
