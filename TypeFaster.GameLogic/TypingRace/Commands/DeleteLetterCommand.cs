using System.Linq;
using TypeFaster.GameLogic.Contracts.TypingRace;

namespace TypeFaster.GameLogic.TypingRace.Commands
{
    public class DeleteLetterCommand : ICommand
    {
        private readonly ITypingRaceInstance _typingRaceInstance;
        private char _deletedLetter;

        public DeleteLetterCommand(ITypingRaceInstance typingRaceInstance) => _typingRaceInstance = typingRaceInstance;

        public void Execute() 
        {
            _deletedLetter = _typingRaceInstance.UserInput.LastOrDefault();
            _typingRaceInstance.DeleteLastLetter();
        }

        public void Undo()
        {
            if (_deletedLetter != '\0')
            {
                _typingRaceInstance.AddNewLetter(_deletedLetter);
            }
        }
    }
}
