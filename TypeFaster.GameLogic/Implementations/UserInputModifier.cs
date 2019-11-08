using System;
using TypeFaster.GameLogic.Contracts;

namespace TypeFaster.GameLogic.Implementations
{
    public class UserInputModifier
    {
        private ICommand _inputModificationCommand;

        public void SetCommand(ICommand command) => _inputModificationCommand = command;

        public void InvokeModification()
        {
            if (_inputModificationCommand == null)
                throw new ArgumentNullException($"{nameof(ICommand)} is null.");

            _inputModificationCommand.Execute();
        }
    }
}
