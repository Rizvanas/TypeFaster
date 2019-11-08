using System;
using System.Collections.Generic;
using System.Text;
using TypeFaster.GameLogic.Contracts;

namespace TypeFaster.GameLogic.GameStates
{
    public abstract class State
    {
        protected IUserInputHandler _userInputHandler;

        public void SetUserInputHandler(IUserInputHandler userInputHandler)
        {
            _userInputHandler = userInputHandler;
        }

        public abstract void Listen();
    }
}
