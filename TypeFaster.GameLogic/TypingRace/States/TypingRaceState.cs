using System;
using TypeFaster.GameLogic.Contracts.Input;
using TypeFaster.GameLogic.Contracts.Rendering;
using TypeFaster.GameLogic.Contracts.TypingRace;
using TypeFaster.GameServices.Contracts;

namespace TypeFaster.GameLogic.TypingRace.States
{
    public abstract class TypingRaceState
    {
        protected ICommandInvoker _invoker;
        protected IGameRenderer _gameRenderer;
        protected ITypingRaceInstance _raceInstance;
        protected ITimeService _timeService;


        public void SetCommandInvoker(ICommandInvoker invoker)
        {
            _invoker = invoker;
        }

        public void SetRenderer(IGameRenderer gameRenderer)
        {
            _gameRenderer = gameRenderer;
        }

        public void SetTypingRaceInstance(ITypingRaceInstance raceInstance)
        {
            _raceInstance = raceInstance;
        }

        public void SetTimeService(ITimeService timeService)
        {
            _timeService = timeService;
        }

        public void IssueCommand(ICommand command)
        {
            _invoker.SetCommand(command);
            _invoker.InvokeCommand();
        }

        public void UndoPreviousCommand() 
        {
            _invoker.InvokeUndo();
        }

        public abstract void HandleInput(ConsoleKeyInfo keyInfo);
        public abstract void Render();

    }
}
