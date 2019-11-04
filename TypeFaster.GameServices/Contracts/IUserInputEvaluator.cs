using System;
using System.Collections.Generic;
using System.Text;
using TypeFaster.Domain.Entities;

namespace TypeFaster.GameServices.Contracts
{
    public interface IUserInputEvaluator
    {
        KeyValuePair<int, string> GetUserInputError(Sentence userInput, Sentence sentence);
    }
}
