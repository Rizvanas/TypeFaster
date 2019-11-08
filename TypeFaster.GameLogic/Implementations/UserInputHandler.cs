﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TypeFaster.GameLogic.Commands;
using TypeFaster.GameLogic.Contracts;
using TypeFaster.GameServices.Contracts;

namespace TypeFaster.GameLogic.Implementations
{
    public class UserInputHandler : IUserInputHandler
    {
        private GameState _state;
        private ITypingRace _typingRace;

        private readonly UserInputModifier _userInputModifier;

        public UserInputHandler(GameState state, UserInputModifier userInputModifier)
        {
            TransitionTo(state);
            _userInputModifier = userInputModifier;
        }

        public void TransitionTo(GameState state)
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
