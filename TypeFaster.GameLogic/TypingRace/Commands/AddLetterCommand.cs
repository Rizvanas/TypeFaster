using TypeFaster.GameLogic.Contracts.TypingRace;

namespace TypeFaster.GameLogic.TypingRace.Commands
{
    public class AddLetterCommand : ICommand
    {
        private readonly ITypingRaceInstance _typingRaceInstance;

        private readonly char _letter;

        public AddLetterCommand(ITypingRaceInstance typingRaceInstance, char letter)
        {
            _typingRaceInstance = typingRaceInstance;
            _letter = letter;
        }

        public void Execute() 
        {
            if (_typingRaceInstance.UserInput.Length < _typingRaceInstance.Sentence.Length)
            {
                _typingRaceInstance.AddNewLetter(_letter);
            }
        }

        public void Undo()
        {
            _typingRaceInstance.DeleteLastLetter();
        }
    }
}
