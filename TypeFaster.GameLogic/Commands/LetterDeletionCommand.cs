using System;
using System.Collections.Generic;
using System.Text;
using TypeFaster.GameLogic.Contracts;

namespace TypeFaster.GameLogic.Commands
{
    public class LetterDeletionCommand : ICommand
    {
        private  _letterDeletionHandler;

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
