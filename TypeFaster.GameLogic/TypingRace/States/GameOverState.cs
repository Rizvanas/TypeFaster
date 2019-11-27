using System;
using TypeFaster.GameLogic.Contracts.TypingRace;

namespace TypeFaster.GameLogic.TypingRace.States
{
    public class GameOverState : TypingRaceState
    {
        public override void HandleInput(ConsoleKeyInfo keyInfo)
        {
            if (keyInfo.Key == ConsoleKey.Enter)
                _inputHandler.IssueGameStateChangingCommand(new WaitingForRestartState());

            if (keyInfo.Key == ConsoleKey.Escape)
                _inputHandler.IssueGameStateChangingCommand(new ExitConfirmationState());
        }

        public override void Render(ITypingRaceInstance typingRaceInstance)
        {
            _gameRenderer.RenderGameOverPrompt();
            _gameRenderer.RenderGameWindow();
        }

    }
}
