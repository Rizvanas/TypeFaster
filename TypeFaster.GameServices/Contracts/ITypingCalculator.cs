using System;

namespace TypeFaster.GameServices.Contracts
{
    public interface ITypingCalculator
    {
        int GetNetTypingSpeed(string userInput, TimeSpan elapsedTime, int totalErrorsMade);
        int GetGrossTypingSpeed(string userInput, TimeSpan elapsedTime);
        decimal GetTypingAccuracy(string userInput, TimeSpan elapsedTime, int totalErrorsMade);
    }
}
