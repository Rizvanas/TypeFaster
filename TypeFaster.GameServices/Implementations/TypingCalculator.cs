using System;
using TypeFaster.Common.Contracts;
using TypeFaster.Domain.Entities;
using TypeFaster.GameServices.Contracts;

namespace TypeFaster.GameServices.Implementations
{
    public class TypingCalculator : ITypingCalculator
    {
        private readonly IDateTime _dateTime;

        public TypingCalculator(IDateTime dateTime)
        {
            _dateTime = dateTime;
        }

        public int GetNetTypingSpeed(Sentence userInput, DateTime startTime, int totalErrorsMade)
        {
            var wordsTyped = userInput.Words.Count;
            var elapsedMinutes = (_dateTime.Now - startTime).TotalMinutes;

            var netSpeed = (wordsTyped - totalErrorsMade) / elapsedMinutes;
            
            return Convert.ToInt32(Math.Truncate(netSpeed));
        }

        public int GetGrossTypingSpeed(Sentence userInput, DateTime startTime)
        {
            var wordsTyped = userInput.Words.Count;
            var elapsedMinutes = (_dateTime.Now - startTime).TotalMinutes;

            return Convert.ToInt32(Math.Truncate(wordsTyped / elapsedMinutes));
        }

        public decimal GetTypingAccuracy(Sentence userInput, DateTime startTime, int totalErrorsMade)
        {
            var netTypingSpeed = GetNetTypingSpeed(userInput, startTime, totalErrorsMade);
            var grossTypingSpeed = GetGrossTypingSpeed(userInput, startTime);

            return (netTypingSpeed / grossTypingSpeed) * 100;
        }
    }
}
