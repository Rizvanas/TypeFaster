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
                IssueCommand(new GameInitializationCommand(_raceInstance, _timeService));
                IssueCommand(new TypingRaceStateChangeCommand(_raceInstance, new RunningState()));
            }
            else if (keyInfo.Key == ConsoleKey.Escape)
            {
                IssueCommand(new TypingRaceStateChangeCommand(_raceInstance, new ExitConfirmationState()));
            }
        }

        public override void Render()
        {
            _gameRenderer.RenderPrompt(UIPrompt.GAME_START);
            _gameRenderer.RenderGameWindow();
        }
    }
}
