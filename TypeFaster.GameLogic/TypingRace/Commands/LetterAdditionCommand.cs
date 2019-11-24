using TypeFaster.Domain.ValueObjects;
using TypeFaster.GameLogic.Contracts.TypingRace;

namespace TypeFaster.GameLogic.TypingRace.Commands
{
    public class LetterAdditionCommand : ICommand
    {
        private readonly ITypingRaceInstance _typingRaceInstance;

        private readonly char _letter;

        public LetterAdditionCommand(
            ITypingRaceInstance typingRaceInstance,
            char letter)
        {
            _typingRaceInstance = typingRaceInstance;
            _letter = letter;
        }

        public void Execute() 
        {
            _typingRaceInstance.AddNewLetter(_letter);
            if (_typingRaceInstance.State != TypingRaceState.Error)
            {
                _typingRaceInstance.UpdateTypoList();
            }
        }

        public void Undo()
        {
            _typingRaceInstance.DeleteLastLetter();
            _typingRaceInstance.UpdateTypoList();
        }
    }
}
