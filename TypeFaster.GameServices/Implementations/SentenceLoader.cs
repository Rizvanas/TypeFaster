using System;
using System.Collections.Generic;
using System.Linq;
using TypeFaster.Common.Contracts;
using TypeFaster.Domain.Entities;
using TypeFaster.GameServices.Contracts;
using TypeFaster.Persistence.Contracts;

namespace TypeFaster.GameServices.Implementations
{
    public class SentenceLoader : ISentenceLoader
    {
        private readonly ISentenceRepository _sentenceRepository;
        private readonly IRandomGenerator _randomGenerator;
        private Stack<int> _randomStack;

        public SentenceLoader(ISentenceRepository sentenceRepository, IRandomGenerator randomGenerator)
        {
            _sentenceRepository = sentenceRepository;
            _randomGenerator = randomGenerator;
            _randomStack = new Stack<int>();
        }

        public Sentence GetNextRandomSentence()
        {
            if (_randomStack.Count == 0)
            {
                var sentencesCount = _sentenceRepository.SentencesCount;
                _randomStack = _randomGenerator.GetRandomStack(sentencesCount);
            }

            return _sentenceRepository.GetSentenceById(_randomStack.Pop());
        }
    }
}
