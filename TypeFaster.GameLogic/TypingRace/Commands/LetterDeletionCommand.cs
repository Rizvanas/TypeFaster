using System.Linq;
using TypeFaster.GameLogic.Contracts.TypingRace;

namespace TypeFaster.GameLogic.TypingRace.Commands
{
    public class LetterDeletionCommand : ICommand
    {
        private readonly ITypingRaceInstance _typingRaceInstance;
        private char _deletedLetter;

        public LetterDeletionCommand(ITypingRaceInstance typingRaceInstance) => _typingRaceInstance = typingRaceInstance;

        public void Execute() 
        {
            _deletedLetter = _typingRaceInstance.UserInput.LastOrDefault();
            _typingRaceInstance.DeleteLastLetter();
        }

        public void Undo()
        {
            _typingRaceInstance.AddNewLetter(_deletedLetter);
        }
    }
}
