using System;
using System.Collections.Generic;
using TypeFaster.GameLogic.Contracts.TypingRace;

namespace TypeFaster.GameLogic.TypingRace
{
    public class RaceInstanceModifier
    {
        private readonly List<ICommand> _commands = new List<ICommand>();
        private ICommand _inputModificationCommand;

        public void SetCommand(ICommand command) => _inputModificationCommand = command;

        public void InvokeModification()
        {
            if (_inputModificationCommand == null)
                throw new ArgumentNullException($"{nameof(ICommand)} is null.");

            _commands.Add(_inputModificationCommand);
            _inputModificationCommand.Execute();
        }

        public void InvokeUndo()
        {
            var lastCommandIndex = _commands.Count - 1;
            if (lastCommandIndex != -1)
            {
                _inputModificationCommand = _commands[lastCommandIndex];
                _commands.RemoveAt(lastCommandIndex);
            }
        }
    }
}
