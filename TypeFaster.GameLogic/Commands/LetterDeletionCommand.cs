using System;
using System.Collections.Generic;
using System.Text;
using TypeFaster.GameLogic.CommandHandlers;
using TypeFaster.GameLogic.Commands.Abstract;

namespace TypeFaster.GameLogic.Commands
{
    public class LetterDeletionCommand : ICommand
    {
        private readonly LetterDeletionHandler _letterDeletionHandler;

        public LetterDeletionCommand(LetterDeletionHandler letterDeletionHandler)
        {
            _letterDeletionHandler = letterDeletionHandler;
        }

        public void Execute()
        {
            _letterDeletionHandler.DeleteLetter();
        }
    }
}
