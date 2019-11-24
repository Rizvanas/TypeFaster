using System;
using TypeFaster.Common.Extensions;
using TypeFaster.GameLogic.Contracts.TypingRace;

namespace TypeFaster.GameLogic.TypingRace.States
{
    public class RunningState : TypingRaceState
    {
        public override void HandleInput(ConsoleKeyInfo keyInfo)
        {
            if (keyInfo.Key == ConsoleKey.Escape)
                _inputHandler.IssueGameStateChangingCommand(new PausedState());

            if (keyInfo.Key == ConsoleKey.Backspace)
                _inputHandler.IssueLetterDeletionCommand();

            if (keyInfo.KeyChar.IsLetterDigitSymbolOrWhiteSpace())
                _inputHandler.IssueLetterAdditionCommand(keyInfo);
        }

        public override void Render(ITypingRaceInstance typingRaceInstance)
        {
            _gameRenderer.RenderUserInput();
            _gameRenderer.RenderPlayerTypingSpeed();
            _gameRenderer.RenderGameWindow();
        }
    }
}
