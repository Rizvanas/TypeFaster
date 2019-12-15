using System;
using TypeFaster.GameLogic.Contracts.TypingRace;
using TypeFaster.UI.Enums;

namespace TypeFaster.GameLogic.TypingRace.States
{
    public class PausedState : TypingRaceState
    {
        public override void HandleInput(ConsoleKeyInfo keyInfo)
        {
            if (keyInfo.Key == ConsoleKey.Escape)
            {
                _inputHandler.IssueUndoCommand();
                _inputHandler.IssueTimerToggleCommand();
                _inputHandler.InvokeEventDispatchEnableCommand();
            }
            else if (keyInfo.Key == ConsoleKey.Enter)
            {
                _inputHandler.IssueGameStateChangingCommand(new ExitConfirmationState());
            }
        }

        public override void Render(ITypingRaceInstance typingRaceInstance)
        {
            _gameRenderer.RenderPrompt(UIPrompt.CONTINUE_GAME);
            _gameRenderer.RenderGameWindow();
        }
    }
}
