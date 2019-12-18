using TypeFaster.GameLogic.Contracts.TypingRace;

namespace TypeFaster.GameLogic.TypingRace.Commands
{
    public class UpdatePreErrorInputCommand : ICommand
    {
        private readonly ITypingRaceInstance _typingRaceInstance;

        public UpdatePreErrorInputCommand(ITypingRaceInstance typingRaceInstance)
        {
            _typingRaceInstance = typingRaceInstance;
        }

        public void Execute()
        {
            _typingRaceInstance.UpdatePreErrorInput();
        }

        public void Undo()
        {
        }
    }
}
