using System;
using TypeFaster.GameLogic.Contracts.Input;
using TypeFaster.GameLogic.Contracts.TypingRace;
using TypeFaster.GameLogic.TypingRace;
using TypeFaster.GameLogic.TypingRace.Commands;
using TypeFaster.GameLogic.TypingRace.States;
using TypeFaster.GameServices.Contracts;

namespace TypeFaster.GameLogic.Input.Handlers
{
    public class InputHandler : IInputHandler
    {
        private ITypingRaceInstance _typingRaceInstance;
        private readonly ITimeService _timeService;
        private readonly RaceInstanceModifier _raceInstanceModifier;

        public InputHandler(ITimeService timeService, RaceInstanceModifier raceInstanceModifier)
        {
            _timeService = timeService;
            _raceInstanceModifier = raceInstanceModifier;
        }

        public void SetTypingRaceInstance(ITypingRaceInstance typingRaceInstance)
        {
            _typingRaceInstance = typingRaceInstance;
        }

        public void IssueLetterAdditionCommand(ConsoleKeyInfo keyInfo)
        {
            _raceInstanceModifier.SetCommand(new LetterAdditionCommand(_typingRaceInstance, keyInfo.KeyChar));
            _raceInstanceModifier.InvokeModification();
        }

        public void IssueLetterDeletionCommand()
        {
            _raceInstanceModifier.SetCommand(new LetterDeletionCommand(_typingRaceInstance));
            _raceInstanceModifier.InvokeModification();
        }

        public void IssueGameStateChangingCommand(TypingRaceState typingRaceState)
        {
            _raceInstanceModifier.SetCommand(new TypingRaceStateChangeCommand(_typingRaceInstance, typingRaceState));
            _raceInstanceModifier.InvokeModification();
        }

        public void IssueErrorStateToggleCommand()
        {
            _raceInstanceModifier.SetCommand(new ErrorStateToggleCommnand(_typingRaceInstance));
            _raceInstanceModifier.InvokeModification();
        }

        public void IssueErrorDeletionCommand()
        {
            _raceInstanceModifier.SetCommand(new ErrorDeletionCommand(_typingRaceInstance));
            _raceInstanceModifier.InvokeModification();
        }

        public void IssueTyposUpdateCommand()
        {
            _raceInstanceModifier.SetCommand(new TyposUpdateCommand(_typingRaceInstance));
            _raceInstanceModifier.InvokeModification();
        }

        public void IssueTimerToggleCommand()
        {
            _raceInstanceModifier.SetCommand(new TimerToggleCommand(_timeService));
            _raceInstanceModifier.InvokeModification();
        }

        public void IssueTimerRestartCommand()
        {
            _raceInstanceModifier.SetCommand(new TimerRestartCommand(_timeService));
            _raceInstanceModifier.InvokeModification();
        }

        public void InvokeTryFinishGameCommand()
        {
            _raceInstanceModifier.SetCommand(new TryFinishGameCommand(_typingRaceInstance, _timeService));
            _raceInstanceModifier.InvokeModification();
        }

        public void IssueGameInitializationCommand()
        {
            _raceInstanceModifier.SetCommand(new GameInitializationCommand(_typingRaceInstance, _timeService));
            _raceInstanceModifier.InvokeModification();
        }

        public void IssueEventDispatchDisableCommand()
        {
            _raceInstanceModifier.SetCommand(new EventDispatchDisableCommand(_timeService));
            _raceInstanceModifier.InvokeModification();
        }

        public void InvokeEventDispatchEnableCommand()
        {
            _raceInstanceModifier.SetCommand(new EventDispatchEnableCommand(_timeService));
            _raceInstanceModifier.InvokeModification();
        }

        public void InvokeCommand(ICommand command)
        {
            _raceInstanceModifier.SetCommand(command);
            _raceInstanceModifier.InvokeModification();
        }

        public void InvokePreErrorInputUpdateCommand()
        {
            _raceInstanceModifier.SetCommand(new PreErrorInputUpdateCommand(_typingRaceInstance));
            _raceInstanceModifier.InvokeModification();
        }

        public void IssueUndoCommand()
        {
            _raceInstanceModifier.InvokeUndo();
        }
    }
}
