using TypeFaster.GameLogic.Contracts.TypingRace;
using TypeFaster.GameLogic.TypingRace.States;

namespace TypeFaster.GameLogic.TypingRace.Commands
{
    public class TypingRaceStateChangeCommand : ICommand
    {
        private readonly ITypingRaceInstance _typingRaceInstance;
        private TypingRaceState _previousState;
        private readonly TypingRaceState _state;

        public TypingRaceStateChangeCommand(ITypingRaceInstance typingRaceInstance, TypingRaceState state)
        {
            _typingRaceInstance = typingRaceInstance;
            _state = state;
        }

        public void Execute()
        {
            _previousState = _typingRaceInstance.State;
            _typingRaceInstance.ChangeState(_state);
        }

        public void Undo()
        {
            _typingRaceInstance.ChangeState(_previousState);
        }
    }
}
