using TypeFaster.GameLogic.Contracts.TypingRace;
using TypeFaster.GameServices.Contracts;

namespace TypeFaster.GameLogic.TypingRace.Commands
{
    public class TimerToggleCommand : ICommand
    {
        private readonly ITimeService _timeService;

        public TimerToggleCommand(ITimeService timeService)
        {
            _timeService = timeService;
        }

        public void Execute()
        {
            ToggleTimer();
        }

        public void Undo()
        {
            ToggleTimer();
        }

        private void ToggleTimer()
        {
            if (_timeService.TimerIsRunning)
                _timeService.StopGameTimer();
            else
                _timeService.StartGameTimer();
        }
    }
}
