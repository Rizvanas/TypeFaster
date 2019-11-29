using TypeFaster.GameLogic.Contracts.TypingRace;

namespace TypeFaster.GameLogic.TypingRace.Commands
{
    public class PreErrorInputUpdateCommand : ICommand
    {
        private readonly ITypingRaceInstance _typingRaceInstance;

        public PreErrorInputUpdateCommand(ITypingRaceInstance typingRaceInstance)
        {
            _typingRaceInstance = typingRaceInstance;
        }

        public void Execute()
        {
            if (!_typingRaceInstance.IsInErrorState)
            {
                _typingRaceInstance.UpdatePreErrorInput();
            }
        }

        public void Undo()
        {
        }
    }
}
