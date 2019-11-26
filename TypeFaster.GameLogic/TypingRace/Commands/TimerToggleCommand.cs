using TypeFaster.GameLogic.Contracts.TypingRace;

namespace TypeFaster.GameLogic.TypingRace.Commands
{
    public class TimerToggleCommand : ICommand
    {
        private readonly ITypingRaceInstance _typingRaceInstance;

        public TimerToggleCommand(ITypingRaceInstance typingRaceInstance)
        {
            _typingRaceInstance = typingRaceInstance;
        }

        public void Execute()
        {
            _typingRaceInstance.ToggleTimer();
        }

        public void Undo()
        {
            _typingRaceInstance.ToggleTimer();
        }
    }
}
