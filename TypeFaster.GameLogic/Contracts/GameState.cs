using System;
using System.Collections.Generic;
using System.Text;

namespace TypeFaster.GameLogic.Contracts
{
    public abstract class GameState
    {
        protected IUserInputHandler _userInputHandler;

        public void SetUserInputHandler(IUserInputHandler userInputHandler)
        {
            _userInputHandler = userInputHandler;
        }
        


    }
}
