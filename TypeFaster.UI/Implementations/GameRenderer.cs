using System;
using TypeFaster.Domain.ValueObjects;
using TypeFaster.GameServices.Contracts;
using TypeFaster.UI.Contracts;
using TypeFaster.UI.GuiComponents;
using TypeFaster.UI.RenderingStates;

namespace TypeFaster.UI.Implementations
{
    public class GameRenderer : IGameRenderer
    {
        private ITypingRace _typingRace;
        private TextBox _gameWindow;
        private TextBox _typingSpeedIndicator;
        private TextBox _pauseStateWindow;
        private UserInputBox _inputBox;
        private RendererState _state;

        public void SetTypingRace(ITypingRace typingRace)
        {
            _typingRace = typingRace;
            _gameWindow = new TextBox("GameWindow", "", 1, 1, Console.WindowWidth - 1, Console.WindowHeight - 1);
            _inputBox = new UserInputBox("Sentence", _typingRace.Sentence, 20 / 2, 20 / 2, Console.WindowWidth - 20);
            _typingSpeedIndicator = new TextBox("Typing Speed", _typingRace.UserTypingSpeed.ToString(), 106, 5, 4, 2);
            _pauseStateWindow = new TextBox("Menu", "If you want to exit press [Enter], If you want to Continue playing, press [Esc]", 20 / 2, 20 / 2, Console.WindowWidth - 20);
        }

        public void Render()
        {
            if (_typingRace == null)
                throw new ArgumentNullException("_typingRace cannot be null.");

            Console.CursorVisible = false;
            _state.Render();
        }

        public void RenderGameWindow()
        {
            _gameWindow.Render();
        }

        public void RenderUserInput()
        {
            SetUserInputColor();
            _inputBox.Render();
        }

        public void RenderPlayerTypingSpeed()
        {
            _typingSpeedIndicator.Render();
        }

        public void RenderPausedStateWindow()
        {
            Console.Clear();
            _pauseStateWindow.Render();
        }

        public void SetUserInputColor()
        {
            if (_typingRace.State == TypingRaceState.Error)
                _inputBox.MatchingInputColor = ConsoleColor.Red;
            else
                _inputBox.MatchingInputColor = ConsoleColor.DarkGreen;
            _inputBox.UserInput = _typingRace.UserInput;
        }

        public void ChangeState(RendererState state)
        {
            _state = state;
            _state.SetGameRenderer(this);
        }

        public void Update(TypingRaceState typingRaceState)
        {
            throw new NotImplementedException();
        }
    }
}
