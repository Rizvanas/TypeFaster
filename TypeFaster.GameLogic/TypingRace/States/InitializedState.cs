using System;
using TypeFaster.GameLogic.TypingRace.Commands;
using TypeFaster.UI.Enums;

namespace TypeFaster.GameLogic.TypingRace.States
{
    public class InitializedState : TypingRaceState
    {
        public override void HandleInput(ConsoleKeyInfo keyInfo)
        {
            if (keyInfo.Key == ConsoleKey.Enter)
            {
                IssueCommand(new InitializeGameCommand(_raceInstance, _timeService));
                IssueCommand(new TypingRaceStateChangeCommand(_raceInstance, new RunningState()));
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
            _gameRenderer.RenderPrompt(UIPrompt.GAME_START);
            _gameRenderer.RenderGameWindow();
        }
    }
}
