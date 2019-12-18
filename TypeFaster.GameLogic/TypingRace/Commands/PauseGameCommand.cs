using TypeFaster.GameLogic.Contracts.TypingRace;
using TypeFaster.GameLogic.TypingRace.States;
using TypeFaster.GameServices.Contracts;

namespace TypeFaster.GameLogic.TypingRace.Commands
{
    public class PauseGameCommand : ICommand
    {
        private readonly ITypingRaceInstance _raceInstance;
        private readonly ITimeService _timeService;
        private TypingRaceState _previousState;
        private bool _timerWasRunning;
        private bool _eventDispatchingWasEnabled;

        public PauseGameCommand(ITypingRaceInstance raceInstance, ITimeService timeService)
        {
            _raceInstance = raceInstance;
            _timeService = timeService;
        }

        public void Execute()
        {
            _timerWasRunning = _timeService.TimerIsRunning;
            _eventDispatchingWasEnabled = _timeService.EventDispatchingEnabled;
            _previousState = _raceInstance.State;

            _timeService.DisableEventDispatching();
            _timeService.StopGameTimer();
            _raceInstance.ChangeState(new PausedState());
            _raceInstance.Notify();
        }

        public void Undo()
        {
            if (_timerWasRunning)
                _timeService.StartGameTimer();

            if (_eventDispatchingWasEnabled)
                _timeService.EnableEventDispatching();

            if (_previousState != null)
                _raceInstance.ChangeState(_previousState);

            _raceInstance.Notify();
        }
    }
}
