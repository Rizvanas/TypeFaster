using System;
using System.Collections.Generic;
using System.Text;
using TypeFaster.GameLogic.Contracts.Rendering;
using TypeFaster.GameLogic.Contracts.TypingRace;
using TypeFaster.UI.GuiComponents;

namespace TypeFaster.GameLogic.Rendering
{
    public class GameRenderer : IGameRenderer
    {
        public void RenderGameWindow()
        {
            _gameWindow.Render();
        }

        public void RenderPausedStateWindow()
        {
            Console.Clear();
            _pauseStateWindow.Render();
        }

        public void RenderPlayerTypingSpeed()
        {
            _typingSpeedIndicator.Render();
        }

        public void RenderUserInput()
        {
            SetUserInputColor();
            _inputBox.Render();
        }

        public void SetTypingRaceInstance(ITypingRaceInstance typingRaceInstance)
        {
            _typingRaceInstance = typingRaceInstance;
            _gameWindow = new TextBox("GameWindow", "", 1, 1, Console.WindowWidth - 1, Console.WindowHeight - 1);
            _inputBox = new UserInputBox("Sentence", _typingRace.Sentence, 20 / 2, 20 / 2, Console.WindowWidth - 20);
            _typingSpeedIndicator = new TextBox("Typing Speed", _typingRace.UserTypingSpeed.ToString(), 106, 5, 4, 2);
            _pauseStateWindow = new TextBox("Menu", "If you want to exit press [Enter], If you want to Continue playing, press [Esc]", 20 / 2, 20 / 2, Console.WindowWidth - 20);
        }

        private ITypingRaceInstance _typingRaceInstance;
        private TextBox _gameWindow;
        private TextBox _typingSpeedIndicator;
        private TextBox _pauseStateWindow;
        private UserInputBox _inputBox;


        private void SetUserInputColor()
        {
            if (_typingRace.State == TypingRaceState.Error)
                _inputBox.MatchingInputColor = ConsoleColor.Red;
            else
                _inputBox.MatchingInputColor = ConsoleColor.DarkGreen;
            _inputBox.UserInput = _typingRace.UserInput;
        }
    }
}
