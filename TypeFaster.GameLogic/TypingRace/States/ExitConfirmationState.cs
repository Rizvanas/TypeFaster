using System;
using TypeFaster.GameLogic.Contracts.TypingRace;
using TypeFaster.UI.Enums;

namespace TypeFaster.GameLogic.TypingRace.States
{
    public class ExitConfirmationState : TypingRaceState
    {
        public override void HandleInput(ConsoleKeyInfo keyInfo)
        {
            if (keyInfo.Key == ConsoleKey.Enter)
            {
                _inputHandler.IssueGameStateChangingCommand(new ExitState());
            }
            else if (keyInfo.Key == ConsoleKey.Escape)
            {
                _inputHandler.IssueUndoCommand();
            }
        }

        public override void Render(ITypingRaceInstance typingRaceInstance)
        {
            _gameRenderer.RenderGameWindow();
            _gameRenderer.RenderPrompt(UIPrompt.EXIT_CONFIRMATION);
        }
    }
}
