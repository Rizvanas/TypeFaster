using System;
using System.Collections.Generic;
using System.Text;
using TypeFaster.GameServices.Contracts;

namespace TypeFaster.GameLogic.Implementations
{
    public abstract class GameHandler
    {
        protected readonly UserInputListener _userInputListener;

        protected GameHandler(UserInputListener userInputListener)
        {
            _userInputListener = userInputListener;
        }

        public abstract ITypingRace CreateTypingRace();

        public bool Run(bool shouldRun)
        {
            var typingRace = CreateTypingRace();
            return shouldRun;
        }
    }
}
