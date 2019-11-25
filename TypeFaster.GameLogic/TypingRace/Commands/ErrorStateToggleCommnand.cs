using TypeFaster.GameLogic.Contracts.TypingRace;
using TypeFaster.GameLogic.TypingRace.States;

namespace TypeFaster.GameLogic.TypingRace.Commands
{
    public class ErrorStateToggleCommnand : ICommand
    {
        private readonly ITypingRaceInstance _typingRaceInstance;
        private TypingRaceState _previousState;

        public ErrorStateToggleCommnand(ITypingRaceInstance typingRaceInstance)
        {
            _typingRaceInstance = typingRaceInstance;
        }

        public void Execute()
        {
            if (_typingRaceInstance.CheckForInputError() && !_typingRaceInstance.IsInErrorState)
            {
                _previousState = _typingRaceInstance.State;
                _typingRaceInstance.ChangeState(new ErrorState());

            }
            else if (!_typingRaceInstance.CheckForInputError() && _typingRaceInstance.IsInErrorState)
            {
                _previousState = _typingRaceInstance.State;
                _typingRaceInstance.ChangeState(new RunningState());
            }

        }

        public void Undo()
        {
            _typingRaceInstance.ChangeState(_previousState);
        }
    }
}
