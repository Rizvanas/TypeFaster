using System;
using TypeFaster.Common.Extensions;
using TypeFaster.GameLogic.TypingRace.Commands;

namespace TypeFaster.GameLogic.TypingRace.States
{
    public class ErrorState : TypingRaceState
    {
        public override void HandleInput(ConsoleKeyInfo keyInfo)
        {
            if (keyInfo.KeyChar.IsLetterDigitSymbolOrWhiteSpace())
            {
                IssueCommand(new LetterAdditionCommand(_raceInstance, keyInfo.KeyChar));
            }
            else if (keyInfo.Key == ConsoleKey.Backspace)
            {
                IssueCommand(new ErrorDeletionCommand(_raceInstance));
                IssueCommand(new ErrorStateToggleCommnand(_raceInstance));
                IssueCommand(new PreErrorInputUpdateCommand(_raceInstance));
            }
            else if (keyInfo.Key == ConsoleKey.Escape)
            {
                IssueCommand(new TimerToggleCommand(_timeService));
                IssueCommand(new EventDispatchDisableCommand(_timeService));
                IssueCommand(new TypingRaceStateChangeCommand(_raceInstance, new PausedState()));
            }
        }

        public override void Render()
        {
            _gameRenderer.RenderUserInput();
            _gameRenderer.RenderPlayerTypingSpeed();
            _gameRenderer.RenderTimeLeft();
            _gameRenderer.RenderGameWindow();
        }
    }
}
