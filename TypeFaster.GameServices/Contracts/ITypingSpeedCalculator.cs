using System;
using TypeFaster.Domain.Entities;

namespace TypeFaster.GameServices.Contracts
{
    public interface ITypingSpeedCalculator
    {
        int GetNetTypingSpeed(Sentence userInput, DateTime startTime, int totalErrorsMade);
    }
}
