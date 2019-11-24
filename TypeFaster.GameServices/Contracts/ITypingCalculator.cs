using System;
using TypeFaster.Domain.Entities;

namespace TypeFaster.GameServices.Contracts
{
    public interface ITypingCalculator
    {
        int GetNetTypingSpeed(string userInput, DateTime startTime, int totalErrorsMade);
        int GetGrossTypingSpeed(string userInput, DateTime startTime);
        decimal GetTypingAccuracy(string userInput, DateTime startTime, int totalErrorsMade);
    }
}
