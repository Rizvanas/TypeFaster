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
        private TextBox _typingSpeedIndicator;
        private TextBox _timeLeft;
        private TextBox _promptWindow;
        private UserInputBox _inputBox;
        private TextBox _typingAccuracyBox;
        private TextBox _typingSpeedBox;
        private TextBox _typosBox;

        public void SetTypingRaceInstance(ITypingRaceInstance typingRaceInstance)
        {
            _typingRaceInstance = typingRaceInstance;
            _gameWindow = new TextBox("Game Window", 1, 1, Console.WindowWidth - 1, Console.WindowHeight - 1);
            _inputBox = new UserInputBox("Sentence", 20 / 2, 20 / 2, Console.WindowWidth - 20);
            _typingSpeedIndicator = new TextBox("Typing Speed", 114, 5, 4, 2);
            _timeLeft = new TextBox("Time Left", 106, 5, 8);
            _promptWindow = new TextBox("Menu", 10, 10, Console.WindowWidth - 20);
            _typingAccuracyBox = new TextBox("Typing Accuracy", (Console.WindowWidth - 31) / 2, _promptWindow.TopPos + 3, 31);
            _typingSpeedBox = new TextBox("Typing Speed", (Console.WindowWidth - 31) / 2, _typingAccuracyBox.TopPos + 3, _typingAccuracyBox.Width);

            _typosBox = new TextBox("Mistakes", 0, _typingSpeedBox.TopPos + 3, 0);
        }

        public void RenderGameWindow()
        {
            _gameWindow.Render("");
        }

        public void RenderPausedStatePrompt()
        {
            _promptWindow.Render("Press [Enter] to exit the game, If you want to Continue playing, press [Esc]");
        }

        public void RenderInitializedStatePrompt()
        {
            _promptWindow.Render("Press [Enter] to start a game. If you want to exit the game press [Esc]");
        }

        public void RenderExitConfirmationPrompt()
        {
            _promptWindow.Render("Do you really want to exit the game? [Enter]");
        }

        public void RenderGameOverPrompt()
        {
            _promptWindow.Render("Game Over, do you want to play again? [Enter]/[Esc]");
        }

        public void RenderGameFinishedPrompt()
        {
            _promptWindow.Render("Success!!! Do you want to play again? [Enter]/[Esc]");
        }

        public void RenderPlayerTypingSpeed()
        { 
            _typingSpeedIndicator.Render(_typingRaceInstance.TypingSpeed.ToString());
        }

        public void RenderTimeLeft()
        {
            var timeLeft = _typingRaceInstance.GameTimeLeft;
            _timeLeft.Render(String.Format("{0}m:{1:D2}s", timeLeft.Minutes, timeLeft.Seconds));
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
            _typosBox.Width = typos.Length + 2;
            _typosBox.LeftPos = (Console.WindowWidth - _typosBox.Width) / 2;
            _typosBox.Render(typos);
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
