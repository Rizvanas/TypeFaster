using System;
using TypeFaster.Common.Contracts;
using TypeFaster.Domain.Entities;
using TypeFaster.GameServices.Contracts;

namespace TypeFaster.GameServices.Implementations
{
    public class TypingSpeedCalculator : ITypingSpeedCalculator
    {
        private readonly IDateTime _dateTime;

        public TypingSpeedCalculator(IDateTime dateTime)
        {
            _dateTime = dateTime;
        }

        public int GetNetTypingSpeed(Sentence userInput, DateTime startTime, int totalErrorsMade)
        {
            var wordsTyped = userInput.Words.Count;
            var elapsedTime = _dateTime.Now - startTime;

            var netSpeed = (wordsTyped - totalErrorsMade) / elapsedTime.TotalMinutes;
            
            return Convert.ToInt32(Math.Truncate(netSpeed));
        }
    }
}
