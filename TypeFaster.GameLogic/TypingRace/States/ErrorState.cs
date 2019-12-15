using System;
using TypeFaster.Common.Extensions;
using TypeFaster.GameLogic.Contracts.TypingRace;

namespace TypeFaster.GameLogic.TypingRace.States
{
    public class ErrorState : TypingRaceState
    {
        public override void HandleInput(ConsoleKeyInfo keyInfo)
        {
            if (keyInfo.KeyChar.IsLetterDigitSymbolOrWhiteSpace())
            {
                _inputHandler.IssueLetterAdditionCommand(keyInfo);
            }
            else if (keyInfo.Key == ConsoleKey.Backspace)
            {
                _inputHandler.IssueErrorDeletionCommand();
                _inputHandler.IssueErrorStateToggleCommand();
                _inputHandler.InvokePreErrorInputUpdateCommand();
            }
            else if (keyInfo.Key == ConsoleKey.Escape)
            {
                _inputHandler.IssueTimerToggleCommand();
                _inputHandler.IssueEventDispatchDisableCommand();
                _inputHandler.IssueGameStateChangingCommand(new PausedState());
            }
        }

        public override void Render(ITypingRaceInstance typingRaceInstance)
        {
            _gameRenderer.RenderUserInput();
            _gameRenderer.RenderPlayerTypingSpeed();
            _gameRenderer.RenderTimeLeft();
            _gameRenderer.RenderGameWindow();
        }
    }
}
