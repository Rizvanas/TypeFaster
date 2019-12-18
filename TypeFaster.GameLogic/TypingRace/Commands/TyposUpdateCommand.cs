using TypeFaster.GameLogic.Contracts.TypingRace;

namespace TypeFaster.GameLogic.TypingRace.Commands
{
    public class TyposUpdateCommand : ICommand
    {
        private readonly ITypingRaceInstance _typingRaceInstance;

        public TyposUpdateCommand(ITypingRaceInstance typingRaceInstance)
        {
            _typingRaceInstance = typingRaceInstance;
        }

        public void Execute()
        {
                _typingRaceInstance.UpdateTypos();
        }

        public void Undo()
        {}
    }
}
