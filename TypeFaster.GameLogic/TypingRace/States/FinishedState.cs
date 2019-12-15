using System;
using TypeFaster.GameLogic.Contracts.TypingRace;
using TypeFaster.UI.Enums;

namespace TypeFaster.GameLogic.TypingRace.States
{
    public class FinishedState : TypingRaceState
    {
        public override void HandleInput(ConsoleKeyInfo keyInfo)
        {
            if (keyInfo.Key == ConsoleKey.Enter)
            {
                _inputHandler.IssueGameStateChangingCommand(new WaitingForRestartState());

            }
            else if (keyInfo.Key == ConsoleKey.Escape)
            {
                _inputHandler.IssueGameStateChangingCommand(new ExitConfirmationState());
            }
        }

        public override void Render(ITypingRaceInstance typingRaceInstance)
        {
            _gameRenderer.RenderGameWindow();
            _gameRenderer.RenderPrompt(UIPrompt.GAME_FINISHED);
            _gameRenderer.RenderEndPlayerStats();
        }
    }
}
