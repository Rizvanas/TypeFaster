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
                IssueCommand(new AddLetterCommand(_raceInstance, keyInfo.KeyChar));
            }
            else if (keyInfo.Key == ConsoleKey.Backspace)
            {
                HandleBackspace();
            }
            else if (keyInfo.Key == ConsoleKey.Escape)
            {
                IssueCommand(new PauseGameCommand(_raceInstance, _timeService));
            }
        }

        public override void Render()
        {
            _gameRenderer.RenderUserInput();
            _gameRenderer.RenderPlayerTypingSpeed();
            _gameRenderer.RenderTimeLeft();
            _gameRenderer.RenderGameWindow();
        }

        private void HandleBackspace()
        {
            IssueCommand(new DeleteLetterCommand(_raceInstance));
            if (!_raceInstance.UserHasMadeATypo())
            {
                IssueCommand(new TypingRaceStateChangeCommand(_raceInstance, new RunningState()));
            }
        }
    }
}
