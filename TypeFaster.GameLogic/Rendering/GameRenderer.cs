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

        public void SetTypingRaceInstance(ITypingRaceInstance typingRaceInstance)
        {
            _typingRaceInstance = typingRaceInstance;
            _gameWindow = new TextBox("Game Window", 1, 1, Console.WindowWidth - 1, Console.WindowHeight - 1);
            _inputBox = new UserInputBox("Sentence", 20 / 2, 20 / 2, Console.WindowWidth - 20);
            _typingSpeedIndicator = new TextBox("Typing Speed", 114, 5, 4, 2);
            _timeLeft = new TextBox("Time Left", 106, 5, 8);
            _promptWindow = new TextBox("Menu", 20 / 2, 20 / 2, Console.WindowWidth - 20);
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
            _inputBox.UpdateUserInput(_typingRaceInstance.UserInput);
            _inputBox.Render(_typingRaceInstance.Sentence);
        }

        private void SetUserInputColor()
        {
            _inputBox.MatchingInputColor = ConsoleColor.DarkGreen;
        }

        public void Update(TypingRaceState typingRaceState)
        {
            Console.Clear();
            /*
            _promptWindow.ClearComponent();
            _timeLeft.ClearComponent();
            _typingSpeedIndicator.ClearComponent();
            _inputBox.ClearComponent();             
             */

        }
    }
}
