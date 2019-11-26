using TypeFaster.GameLogic.Contracts.TypingRace;

namespace TypeFaster.GameLogic.TypingRace.Commands
{
    public class TimerRestartCommand : ICommand
    {
        private readonly ITypingRaceInstance _typingRaceInstance;

        public TimerRestartCommand(ITypingRaceInstance typingRaceInstance)
        {
            _typingRaceInstance = typingRaceInstance;
        }

        public void Execute()
        {
            _typingRaceInstance.RestartTimer();
        }

        public void Undo()
        {
            _typingRaceInstance.RestartTimer();
        }
    }
}
