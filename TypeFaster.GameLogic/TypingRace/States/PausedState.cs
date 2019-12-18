using System;
using TypeFaster.GameLogic.TypingRace.Commands;
using TypeFaster.UI.Enums;

namespace TypeFaster.GameLogic.TypingRace.States
{
    public class PausedState : TypingRaceState
    {
        public override void HandleInput(ConsoleKeyInfo keyInfo)
        {
            if (keyInfo.Key == ConsoleKey.Escape)
            {
                UndoPreviousCommand();
            }
            else if (keyInfo.Key == ConsoleKey.Enter)
            {
                IssueCommand(new TypingRaceStateChangeCommand(_raceInstance, new ExitConfirmationState()));
                _raceInstance.Notify();
            }
        }

        public override void Render()
        {
            _gameRenderer.RenderPrompt(UIPrompt.CONTINUE_GAME);
            _gameRenderer.RenderGameWindow();
        }
    }
}
