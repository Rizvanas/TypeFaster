using System;
using System.Collections.Generic;
using System.Text;
using TypeFaster.GameLogic.Commands;
using TypeFaster.GameServices.Contracts;

namespace TypeFaster.GameLogic.Implementations
{
    public abstract class GameHandler
    {
        protected readonly UserInputHandler _userInputListener;

        protected GameHandler(UserInputHandler userInputListener)
        {
            _userInputListener = userInputListener;
        }

        public abstract ITypingRace CreateTypingRace();

        public bool Run(bool shouldRun)
        {
            _userInputListener.SetTypingRace(CreateTypingRace());
            return shouldRun;
        }
    }
}
