﻿using System;
using TypeFaster.GameLogic.TypingRace.Commands;
using TypeFaster.UI.Enums;

namespace TypeFaster.GameLogic.TypingRace.States
{
    public class FinishedState : TypingRaceState
    {
        public override void HandleInput(ConsoleKeyInfo keyInfo)
        {
            if (keyInfo.Key == ConsoleKey.Enter)
            {
                IssueCommand(new TypingRaceStateChangeCommand(_raceInstance, new InitializedState()));
                _raceInstance.ShouldRestart = true;
                _raceInstance.Notify();
            }
            else if (keyInfo.Key == ConsoleKey.Escape)
            {
                IssueCommand(new TypingRaceStateChangeCommand(_raceInstance, new ExitConfirmationState()));
                _raceInstance.Notify();
            }
        }

        public override void Render()
        {
            _gameRenderer.RenderGameWindow();
            _gameRenderer.RenderPrompt(UIPrompt.GAME_FINISHED);
            _gameRenderer.RenderEndPlayerStats();
        }
    }
}
