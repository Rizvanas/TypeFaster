using TypeFaster.GameLogic.Contracts;
using TypeFaster.GameServices.Contracts;

namespace TypeFaster.GameLogic.Commands
{
    public class LetterAdditionCommand : ICommand
    {
        private readonly ITypingRace _typingRace;
        private readonly char _letter;

        public LetterAdditionCommand(ITypingRace typingRace, char letter)
        {
            _typingRace = typingRace;
            _letter = letter;
        }

        public void Execute() => _typingRace.InsertNewLetter(_letter);
    }
}
