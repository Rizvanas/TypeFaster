using System;
using System.Collections.Generic;
using System.Text;
using TypeFaster.GameLogic.Contracts;

namespace TypeFaster.GameLogic.Implementations
{
    public class UserInputListener : IUserInputListener
    {
        private ICommand _onLetterOrSymbolPressed;
        private ICommand _onBackspacePressed;

        public void SetOnLetterOnSymbolPressed(ICommand command) => _onLetterOrSymbolPressed = command;
        public void SetOnBackspacePressed(ICommand command) => _onBackspacePressed = command;

        public void Listen()
        {

        }
    }
}
