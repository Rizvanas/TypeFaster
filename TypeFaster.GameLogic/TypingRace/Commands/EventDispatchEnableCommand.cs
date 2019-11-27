using TypeFaster.GameLogic.Contracts.TypingRace;
using TypeFaster.GameServices.Contracts;

namespace TypeFaster.GameLogic.TypingRace.Commands
{
    public class EventDispatchEnableCommand : ICommand
    {
        private readonly ITimeService _timeService;
        private bool _eventDispatchWasDisabled;

        public EventDispatchEnableCommand(ITimeService timeService)
        {
            _timeService = timeService;
        }

        public void Execute()
        {
            _eventDispatchWasDisabled = !_timeService.EventDispatchingEnabled;
            _timeService.EnableEventDispatching();
        }

        public void Undo()
        {
            if (_eventDispatchWasDisabled)
            {
                _timeService.DisableEventDispatching();
            }
        }
    }
}
