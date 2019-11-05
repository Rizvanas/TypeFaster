using System.Collections.Generic;

namespace TypeFaster.GameServices.Contracts
{
    public interface IUserInputEvaluator
    {
        IList<KeyValuePair<int, string>> GetInputErrors(IList<string> userInput, IList<string> sentence);
    }
}
