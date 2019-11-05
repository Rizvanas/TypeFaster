using System.Collections.Generic;
using System.Linq;
using TypeFaster.GameServices.Contracts;

namespace TypeFaster.GameServices.Implementations
{
    public class UserInputEvaluator : IUserInputEvaluator
    {
        public IList<KeyValuePair<int, string>> GetInputErrors(IList<string> userInput, IList<string> sentence)
        {
            return sentence
                .Where((word, index) => word.StartsWith(userInput[index]))
                .Select((word, index) => new KeyValuePair<int, string>(index, word))
                .ToList();
        }
    }
}
