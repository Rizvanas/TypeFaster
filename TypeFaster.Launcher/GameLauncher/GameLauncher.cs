using TypeFaster.GameLogic.Contracts.Input;
using TypeFaster.GameLogic.Contracts.TypingRace;
using TypeFaster.GameLogic.TypingRace.States;

namespace TypeFaster.Launcher.GameLauncher
{
    public abstract class GameLauncher
    {
        private readonly IInputListener _inputListener;

        public GameLauncher(IInputListener inputListener)
        {
            _inputListener = inputListener;
        }

        public abstract ITypingRaceInstance CreateTypingRaceInstace();

        public void Launch()
        {
            var _typingRace = CreateTypingRaceInstace();

            while(!_typingRace.ShouldExit)
            {
                _typingRace.Render();
                _typingRace.HandleUserInput(_inputListener.Listen());

                if (_typingRace.ShouldRestart)
                    _typingRace = CreateTypingRaceInstace();
            }
        }
    }
}
