using System;
using System.Collections.Generic;
using System.Text;
using TypeFaster.GameLogic.CommandHandlers;
using TypeFaster.GameLogic.Commands.Abstract;

namespace TypeFaster.GameLogic.Commands
{
    public class LetterAdditionCommand : ICommand
    {
        private readonly LetterAdditionHandler _letterAdditionHandler;
        private readonly string _letter;

        public LetterAdditionCommand(LetterAdditionHandler letterAdditionHandler, string letter)
        {
            _letterAdditionHandler = letterAdditionHandler;
            _letter = letter;
        }

        public void Execute()
        {
            _letterAdditionHandler.AddLetter(_letter);
        }
    }
}
