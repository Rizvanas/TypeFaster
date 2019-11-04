using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TypeFaster.Common.Contracts;
using TypeFaster.Common.Extensions;

namespace TypeFaster.Common.services
{
    public class RandomGenerator : IRandomGenerator
    {
        private readonly Random _random;

        public RandomGenerator(Random random)
        {
            _random = random;
        }

        public Stack<int> GetRandomStack(int length)
        {
            return Enumerable.Range(0, length)
                .Shuffle(_random)
                .ToStack();
        }
    }
}
