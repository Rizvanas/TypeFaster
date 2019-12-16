using System;
using TypeFaster.GameLogic.TypingRace.Commands;
using TypeFaster.UI.Enums;

namespace TypeFaster.GameLogic.TypingRace.States
{
    public class ExitConfirmationState : TypingRaceState
    {
        public override void HandleInput(ConsoleKeyInfo keyInfo)
        {
            if (keyInfo.Key == ConsoleKey.Enter)
            {
                IssueCommand(new TypingRaceStateChangeCommand(_raceInstance, new ExitState()));
            }
            else if (keyInfo.Key == ConsoleKey.Escape)
            {
                UndoPreviousCommand();
            }
        }

        public override void Render()
        {
            _gameRenderer.RenderGameWindow();
            _gameRenderer.RenderPrompt(UIPrompt.EXIT_CONFIRMATION);
        }
    }
}
