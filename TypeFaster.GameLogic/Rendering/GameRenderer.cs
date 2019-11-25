using System;
using TypeFaster.GameLogic.Contracts.Rendering;
using TypeFaster.GameLogic.Contracts.TypingRace;
using TypeFaster.UI.GuiComponents;

namespace TypeFaster.GameLogic.Rendering
{
    public class GameRenderer : IGameRenderer
    {
        private ITypingRaceInstance _typingRaceInstance;
        private TextBox _gameWindow;
        private TextBox _typingSpeedIndicator;
        private TextBox _promptWindow;
        private TextBox _initializedStateWindow;
        private UserInputBox _inputBox;

        public void SetTypingRaceInstance(ITypingRaceInstance typingRaceInstance)
        {
            _typingRaceInstance = typingRaceInstance;
            _gameWindow = new TextBox("Game Window", 0, 0, Console.WindowWidth - 2, Console.WindowHeight - 2);
            _inputBox = new UserInputBox("Sentence", 20 / 2, 20 / 2, Console.WindowWidth - 20);
            _typingSpeedIndicator = new TextBox("Typing Speed", 106, 5, 4, 2);
            _promptWindow = new TextBox("Menu", 20 / 2, 20 / 2, Console.WindowWidth - 20);
            _initializedStateWindow = new TextBox("Menu", 20 / 2, 20 / 2, Console.WindowWidth - 20);
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

        public void RenderPlayerTypingSpeed()
        {
            _typingSpeedIndicator.Render(_typingRaceInstance.TypingSpeed.ToString());
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
    }
}
