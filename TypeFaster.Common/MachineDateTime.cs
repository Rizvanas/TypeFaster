using System;
using TypeFaster.Common.Contracts;

namespace TypeFaster.Common
{
    public class MachineDateTime : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
