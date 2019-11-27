using TypeFaster.GameLogic.Contracts.TypingRace;
using TypeFaster.GameServices.Contracts;

namespace TypeFaster.GameLogic.TypingRace.Commands
{
    public class TimerRestartCommand : ICommand
    {
        private readonly ITimeService _timeService;

        public TimerRestartCommand(ITimeService timeService)
        {
            _timeService = timeService;
        }

        public void Execute()
        {
            _timeService.RestartGameTimer();
        }

        public void Undo()
        {
            _timeService.RestartGameTimer();
        }
    }
}
