using TypeFaster.GameLogic.Contracts.TypingRace;
using TypeFaster.GameServices.Contracts;

namespace TypeFaster.GameLogic.TypingRace.Commands
{
    public class EventDispatchDisableCommand : ICommand
    {
        private readonly ITimeService _timeService;
        private bool wasEnabled;

        public EventDispatchDisableCommand(ITimeService timeService)
        {
            _timeService = timeService;
        }

        public void Execute()
        {
            wasEnabled = _timeService.EventDispatchingEnabled;
            _timeService.DisableEventDispatching();
        }

        public void Undo()
        {
            if (wasEnabled)
            {
                _timeService.EnableEventDispatching();
            }
        }
    }
}
