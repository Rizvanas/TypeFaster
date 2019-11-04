using System;
using System.Collections.Generic;
using System.Text;

namespace TypeFaster.Common.Contracts
{
    public interface IRandomGenerator
    {
        Stack<int> GetRandomStack(int length);
    }
}
