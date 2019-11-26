using System;
using System.Linq;
using TypeFaster.GameServices.Contracts;

namespace TypeFaster.GameServices.Implementations
{
    public class TypingCalculator : ITypingCalculator
    {
        public int GetNetTypingSpeed(string userInput, TimeSpan elapsedTime, int totalErrorsMade)
        {
            var wordsTyped = userInput.Split(" ")
                .Where(w => !string.IsNullOrWhiteSpace(w))
                .Count();

            var elapsedMinutes = elapsedTime.TotalMinutes;

            var netSpeed = (wordsTyped - totalErrorsMade) / elapsedMinutes;
            
            return Convert.ToInt32(Math.Truncate(netSpeed));
        }

        public int GetGrossTypingSpeed(string userInput, TimeSpan elapsedTime)
        {
            var wordsTyped = userInput.Split(" ")
                .Where(w => !string.IsNullOrWhiteSpace(w))
                .Count();

            var elapsedMinutes = elapsedTime.TotalMinutes;

            if (elapsedMinutes == 0)
                throw new DivideByZeroException("Cannot divide by zero.");

            return Convert.ToInt32(Math.Truncate(wordsTyped / elapsedMinutes));
        }

        public decimal GetTypingAccuracy(string userInput, TimeSpan elapsedTime, int totalErrorsMade)
        {
            var netTypingSpeed = GetNetTypingSpeed(userInput, elapsedTime, totalErrorsMade);
            var grossTypingSpeed = GetGrossTypingSpeed(userInput, elapsedTime);

            if (grossTypingSpeed == 0)
                throw new DivideByZeroException("Cannot divide by zero.");

            return (netTypingSpeed / grossTypingSpeed) * 100;
        }
    }
}
