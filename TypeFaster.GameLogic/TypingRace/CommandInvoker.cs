using System;
using System.Collections.Generic;
using TypeFaster.GameLogic.Contracts.Input;
using TypeFaster.GameLogic.Contracts.TypingRace;

namespace TypeFaster.GameLogic.TypingRace
{
    public class CommandInvoker : ICommandInvoker
    {
        private readonly List<ICommand> _commands = new List<ICommand>();
        private ICommand _modificationCommand;

        public void SetCommand(ICommand command) => _modificationCommand = command;

        public void InvokeCommand()
        {
            if (_modificationCommand == null)
                throw new ArgumentNullException($"{nameof(_modificationCommand)} is null.");

            _commands.Add(_modificationCommand);
            _modificationCommand.Execute();
        }

        public void InvokeUndo()
        {
            var lastCommandIndex = _commands.Count - 1;
            if (lastCommandIndex != -1)
            {
                _modificationCommand = _commands[lastCommandIndex];
                _modificationCommand.Undo();
                _commands.RemoveAt(lastCommandIndex);
            }
        }
    }
}
