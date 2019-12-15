using System;
using TypeFaster.GameLogic.Contracts.Rendering;
using TypeFaster.GameLogic.Contracts.TypingRace;
using TypeFaster.GameLogic.TypingRace.States;
using TypeFaster.UI.GuiComponents;

namespace TypeFaster.GameLogic.Rendering
{
    public class GameRenderer : IGameRenderer
    {
        private ITypingRaceInstance _typingRaceInstance;
        private TextBox _gameWindow;
        private TextBox _titlebox;
        private TextBox _typingSpeedIndicator;
        private TextBox _timeLeft;
        private TextBox _promptWindow;
        private UserInputBox _inputBox;
        private TextBox _typingAccuracyBox;
        private TextBox _typingSpeedBox;
        private TextBox _typosBox;

        public GameRenderer()
        {
            _gameWindow = new TextBox(1, 1, Console.WindowWidth - 1, Console.WindowHeight - 1);
            _inputBox = new UserInputBox(_gameWindow.LeftPos + 10, (_gameWindow.Height - 3) / 2, _gameWindow.Width - 20);
            _titlebox = new TextBox((_gameWindow.LeftPos + _gameWindow.Width - 12) / 2, _gameWindow.TopPos + 1, 13);
            _typingSpeedIndicator = new TextBox(_inputBox.LeftPos + _inputBox.Width - 23, _inputBox.TopPos - 3, 23);
            _timeLeft = new TextBox(_inputBox.LeftPos, _inputBox.TopPos - 3, 19);
            _promptWindow = new TextBox((_gameWindow.LeftPos + _gameWindow.Width - 80) / 2, (_gameWindow.Height - 3) / 2, 80);
            _typingAccuracyBox = new TextBox((Console.WindowWidth - 31) / 2, _promptWindow.TopPos + 3, 31);
            _typingSpeedBox = new TextBox((Console.WindowWidth - 31) / 2, _typingAccuracyBox.TopPos + 3, _typingAccuracyBox.Width);
            _typosBox = new TextBox(0, _typingSpeedBox.TopPos + 3, 0);
        }

        public void SetTypingRaceInstance(ITypingRaceInstance typingRaceInstance)
        {
            _typingRaceInstance = typingRaceInstance;
        }

        public void RenderGameWindow()
        {
            _titlebox.Render("Type Faster");
            _gameWindow.Render("");
        }

        public void RenderPrompt(string prompt)
        {
            _promptWindow.Render(prompt);
        }

        public void RenderPlayerTypingSpeed()
        { 
            _typingSpeedIndicator.Render($"Typing speed: {_typingRaceInstance.TypingSpeed.ToString()} wpm");
        }

        public void RenderTimeLeft()
        {
            var timeLeft = _typingRaceInstance.GameTimeLeft;
            _timeLeft.Render($"Time left: {String.Format("{0}m:{1:D2}s", timeLeft.Minutes, timeLeft.Seconds)}");
        }

        public void RenderUserInput()
        {
            SetUserInputColor();
            _inputBox.UpdateUserInput(_typingRaceInstance.UserInput, _typingRaceInstance.PreErrorInput);
            _inputBox.Render(_typingRaceInstance.Sentence);
        }

        public void RenderEndPlayerStats()
        {
            _typingAccuracyBox.Render($"Your typing accuracy: {String.Format("{0:0.00}", _typingRaceInstance.TypingAccuracy)}%");
            _typingSpeedBox.Render($"Your typing speed is: {_typingRaceInstance.TypingSpeed} wpm");

            var typos = string.Join("; ", _typingRaceInstance.Typos);
            _typosBox.Width = 44;
            if (typos.Length != 0)
            {
                _typosBox.LeftPos = (Console.WindowWidth - _typosBox.Width) / 2;
                _typosBox.Render(typos);
            }
        }

        public void Update(TypingRaceState typingRaceState)
        {
            Console.Clear();
        }

        private void SetUserInputColor()
        {
            _inputBox.MatchingInputColor = ConsoleColor.DarkGreen;
            _inputBox.ErrorColor = ConsoleColor.Red;
        }
    }
}
