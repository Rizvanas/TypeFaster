using System.Collections.Generic;

namespace TypeFaster.Common.Extensions
{
    public static class StackExtensions
    {
        public static Stack<T> ToStack<T>(this IEnumerable<T> sequence)
        {
            return new Stack<T>(sequence);
        }
    }
}
