using System;
using TypeFaster.Domain.Entities;

namespace TypeFaster.GameServices.Contracts
{
    public interface ITypingCalculator
    {
        int GetNetTypingSpeed(Sentence userInput, DateTime startTime, int totalErrorsMade);
        int GetGrossTypingSpeed(Sentence userInput, DateTime startTime);
        decimal GetTypingAccuracy(Sentence userInput, DateTime startTime, int totalErrorsMade);
    }
}
