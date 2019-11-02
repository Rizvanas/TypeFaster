using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TypeFaster.Domain.Entities;
using TypeFaster.GameLogic.Contracts;
using TypeFaster.GameServices.Contracts;

namespace TypeFaster.GameLogic.Implementations
{
    public class SimpleSentenceRotator : ISentenceRotator
    {
        private readonly ISentenceService _sentenceService;
        private IList<Sentence> _sentences = new List<Sentence>();

        public SimpleSentenceRotator(ISentenceService sentenceService)
        {
            _sentenceService = sentenceService;
            _sentences = _sentenceService.GetShuffledSentenceList();
        }

        public Sentence GetNextSentence()
        {
            if (_sentences.Count == 0)
                _sentences = _sentenceService.GetShuffledSentenceList();

            var sentence = _sentences.FirstOrDefault();
            _sentences.RemoveAt(0);

            return sentence;
        }
    }
}
