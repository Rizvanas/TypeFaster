using System;
using TypeFaster.GameServices.Contracts;
using TypeFaster.Persistence.Contracts;

namespace TypeFaster.GameServices
{
    public class SentenceEvaluationService : ISententceEvaluationService
    {
        private readonly ISentenceRepository _sentenceRepository;

        public SentenceEvaluationService(ISentenceRepository sentenceRepository)
        {
            _sentenceRepository = sentenceRepository;
        }

        public bool CheckIfInputIsASliceOfSentence(string userInput, int sentence_id)
        {
            if (userInput == null)
                throw new ArgumentNullException();

            int startPos = 0;
            var substringOfASentence = _sentenceRepository
                .GetSentenceById(sentence_id)
                .Words.Substring(startPos, userInput.Length);

            return substringOfASentence == userInput;
        }
    }
}
