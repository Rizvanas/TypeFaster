﻿using System;
using TypeFaster.GameLogic.Contracts.TypingRace;

namespace TypeFaster.GameLogic.TypingRace.States
{
    public class InitializedState : TypingRaceState
    {
        public override void HandleInput(ConsoleKeyInfo keyInfo)
        {
            if (keyInfo.Key == ConsoleKey.Enter)
            {
                _inputHandler.IssueGameInitializationCommand();
                _inputHandler.IssueGameStateChangingCommand(new RunningState());
            }
            else if (keyInfo.Key == ConsoleKey.Escape)
            {
                _inputHandler.IssueGameStateChangingCommand(new ExitConfirmationState());
            }
        }

        public override void Render(ITypingRaceInstance typingRaceInstance)
        {
            _gameRenderer.RenderInitializedStatePrompt();
            _gameRenderer.RenderGameWindow();
        }
    }
}
