using TypeFaster.GameLogic.Contracts.TypingRace;
using TypeFaster.GameLogic.TypingRace.States;
using TypeFaster.GameServices.Contracts;

namespace TypeFaster.GameLogic.TypingRace.Commands
{
    public class FinishGameCommand : ICommand
    {
        private readonly ITypingRaceInstance _typingRaceInstance;
        private readonly ITimeService _timeService;
        private TypingRaceState _previousState;
        private bool _timerWasRunning;
        private bool _eventDispatchingWasEnabled;


        public FinishGameCommand(ITypingRaceInstance typingRaceInstance, ITimeService timeService)
        {
            _typingRaceInstance = typingRaceInstance;
            _timeService = timeService; 
        }

        public void Execute()
        {
            _timerWasRunning = _timeService.TimerIsRunning;
            _eventDispatchingWasEnabled = _timeService.EventDispatchingEnabled;
            _previousState = _typingRaceInstance.State;

            _timeService.StopGameTimer();
            _timeService.DisableEventDispatching();
            _typingRaceInstance.UpdateTypingAccuracy();
            _typingRaceInstance.ChangeState(new FinishedState());
            _typingRaceInstance.Notify();
        }

        public void Undo()
        {
            if (_timerWasRunning)
                _timeService.StartGameTimer();

            if (_eventDispatchingWasEnabled)
                _timeService.EnableEventDispatching();

            if (_previousState != null)
                _typingRaceInstance.ChangeState(_previousState);
        }
    }
}
