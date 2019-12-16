using System;
using TypeFaster.Common.Extensions;
using TypeFaster.GameLogic.TypingRace.Commands;

namespace TypeFaster.GameLogic.TypingRace.States
{
    public class RunningState : TypingRaceState
    {
        public override void HandleInput(ConsoleKeyInfo keyInfo)
        {
            if (keyInfo.Key == ConsoleKey.Escape)
            {
                IssueCommand(new TimerToggleCommand(_timeService));
                IssueCommand(new EventDispatchDisableCommand(_timeService));
                IssueCommand(new TypingRaceStateChangeCommand(_raceInstance, new PausedState()));
            }
            else if (keyInfo.Key == ConsoleKey.Backspace)
            {
                IssueCommand(new LetterDeletionCommand(_raceInstance));
                IssueCommand(new ErrorStateToggleCommnand(_raceInstance));
                IssueCommand(new PreErrorInputUpdateCommand(_raceInstance));
            }
            else if (keyInfo.KeyChar.IsLetterDigitSymbolOrWhiteSpace())
            {
                IssueCommand(new LetterAdditionCommand(_raceInstance, keyInfo.KeyChar));
                IssueCommand(new ErrorStateToggleCommnand(_raceInstance));
                IssueCommand(new PreErrorInputUpdateCommand(_raceInstance));
                IssueCommand(new TyposUpdateCommand(_raceInstance));
                IssueCommand(new TryFinishGameCommand(_raceInstance, _timeService));
            }
        }

        public override void Render()
        {
            _gameRenderer.RenderUserInput();
            _gameRenderer.RenderTimeLeft();
            _gameRenderer.RenderPlayerTypingSpeed();
            _gameRenderer.RenderGameWindow();
        }
    }
}
