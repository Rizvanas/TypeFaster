using System;
using System.Threading.Tasks;
using TypeFaster.GameLogic.Commands;
using TypeFaster.GameLogic.Contracts;
using TypeFaster.GameLogic.GameStates;
using TypeFaster.GameServices.Contracts;

namespace TypeFaster.GameLogic.Implementations
{
    public class UserInputHandler : IUserInputHandler
    {
        private State _state;
        private ITypingRace _typingRace;

        private readonly UserInputModifier _userInputModifier;

        public UserInputHandler(State state, UserInputModifier userInputModifier)
        {
            TransitionTo(state);
            _userInputModifier = userInputModifier;
        }

        public void TransitionTo(State state)
        {
            _state = state;
            _state.SetUserInputHandler(this);
        }

        public void SetTypingRace(ITypingRace typingRace)
        {
            _typingRace = typingRace;
        }

        public void Listen()
        {
            var keypressTask = Task.Run(() => Console.ReadKey(true));
            
            if (true)
            {
                _userInputModifier.SetCommand(new LetterDeletionCommand(_typingRace));
                _userInputModifier.InvokeModification();
            }
        }
    }
}
