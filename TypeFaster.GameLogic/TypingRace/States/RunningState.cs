using System;
using System.Linq;
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
                IssueCommand(new PauseGameCommand(_raceInstance, _timeService));
            }
            else if (keyInfo.Key == ConsoleKey.Backspace)
            {
                HandleBackspace();
            }
            else if (keyInfo.KeyChar.IsLetterDigitSymbolOrWhiteSpace())
            {
                HandLetterDigitOrSymbol(keyInfo.KeyChar);
            }
        }

        public override void Render()
        {
            _gameRenderer.RenderUserInput();
            _gameRenderer.RenderTimeLeft();
            _gameRenderer.RenderPlayerTypingSpeed();
            _gameRenderer.RenderGameWindow();
        }

        private void HandLetterDigitOrSymbol(char keyChar)
        {
            IssueCommand(new AddLetterCommand(_raceInstance, keyChar));
            if (_raceInstance.UserHasMadeATypo())
            {
                IssueCommand(new TypingRaceStateChangeCommand(_raceInstance, new ErrorState()));
                IssueCommand(new TyposUpdateCommand(_raceInstance));
            }
            else
            {
                IssueCommand(new UpdatePreErrorInputCommand(_raceInstance));
                IfGameIsFinishedEndGame();
            }
        }

        private void HandleBackspace()
        {
            if (_raceInstance.UserInput.Length != 0 && _raceInstance.UserInput.Last() != ' ')
            {
                IssueCommand(new DeleteLetterCommand(_raceInstance));
                IssueCommand(new UpdatePreErrorInputCommand(_raceInstance));
            }
        }

        private void IfGameIsFinishedEndGame()
        {
            if (_raceInstance.GameIsFinished())
            {
                IssueCommand(new FinishGameCommand(_raceInstance, _timeService));
            }
        }
    }
}
