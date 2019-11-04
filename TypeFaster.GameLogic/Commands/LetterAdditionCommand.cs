using TypeFaster.Domain.Entities;
using TypeFaster.GameLogic.CommandHandlers;
using TypeFaster.GameLogic.Contracts;

namespace TypeFaster.GameLogic.Commands
{
    public class LetterAdditionCommand : ICommand
    {
        private readonly LetterAdditionHandler _letterAdditionHandler;
        private readonly string _letter;
        private readonly string _userInput;

        public LetterAdditionCommand(LetterAdditionHandler letterAdditionHandler, string letter, string userInput)
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
