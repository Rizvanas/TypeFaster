using TypeFaster.GameLogic.Contracts;
using TypeFaster.GameServices.Contracts;

namespace TypeFaster.GameLogic.Commands
{
    public class LetterDeletionCommand : ICommand
    {
        private readonly ITypingRace _typingRace;

        public LetterDeletionCommand(ITypingRace typingRace)
        {
            _typingRace = typingRace;
        }

        public void Execute()
        {
            _typingRace.DeleteLastLetter();
        }
    }
}
