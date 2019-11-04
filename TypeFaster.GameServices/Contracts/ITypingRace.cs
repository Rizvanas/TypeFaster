using System;
using System.Collections.Generic;
using System.Text;

namespace TypeFaster.GameServices.Contracts
{
    public interface ITypingRace
    {
        void InsertNewLetter(char letter);
        void DeleteLastLetter();
    }
}
