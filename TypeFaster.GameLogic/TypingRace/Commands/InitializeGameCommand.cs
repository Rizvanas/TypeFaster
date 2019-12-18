using TypeFaster.GameLogic.Contracts.TypingRace;
using TypeFaster.GameServices.Contracts;

namespace TypeFaster.GameLogic.TypingRace.Commands
{
    public class InitializeGameCommand : ICommand
    {
        private readonly ITypingRaceInstance _typingRaceInstance;
        private readonly ITimeService _timeService;

        public InitializeGameCommand(ITypingRaceInstance typingRaceInstance, ITimeService timeService)
        {
            _typingRaceInstance = typingRaceInstance;
            _timeService = timeService;
        }

        public void Execute()
        {
            _timeService.AddTimedEvent(_typingRaceInstance.UpdateTypingSpeed);
            _timeService.AddTimedEvent(_typingRaceInstance.TrySetToGameOverState);
            _timeService.EnableEventDispatching();
            _timeService.RestartGameTimer();
        }

        public void Undo()
        {
            _timeService.DisableEventDispatching();
            _timeService.RestartGameTimer();
        }
    }
}
