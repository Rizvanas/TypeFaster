using System;
using System.Collections.Generic;
using System.Text;
using TypeFaster.GameLogic.Commands.Abstract;

namespace TypeFaster.GameLogic.Implementations
{
    public class UserInputListener
    {
        private ICommand _onLetterOrSymbolPressed;
        private ICommand _onBackspacePressed;

        public void SetOnLetterOnSymbolPressed(ICommand command)
        {
            _onLetterOrSymbolPressed = command;
        }

        public void SetOnBackspacePressed(ICommand command)
        {
            _onBackspacePressed = command;
        }
    }
}
