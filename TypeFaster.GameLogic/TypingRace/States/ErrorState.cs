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
                _inputHandler.IssueLetterAdditionCommand(keyInfo);

            if (keyInfo.Key == ConsoleKey.Backspace)
            {
                _inputHandler.IssueLetterDeletionCommand();
                _inputHandler.IssueErrorStateToggleCommand();
            }

            if (keyInfo.Key == ConsoleKey.Escape)
                _inputHandler.IssueGameStateChangingCommand(new PausedState());
        }

        public override void Render(ITypingRaceInstance typingRaceInstance)
        {
            throw new NotImplementedException();
        }
    }
}
