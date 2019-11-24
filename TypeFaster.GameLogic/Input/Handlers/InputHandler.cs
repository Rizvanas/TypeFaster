using System;
using TypeFaster.GameLogic.Contracts.Input;
using TypeFaster.GameLogic.Contracts.TypingRace;
using TypeFaster.GameLogic.TypingRace;
using TypeFaster.GameLogic.TypingRace.Commands;
using TypeFaster.GameLogic.TypingRace.States;

namespace TypeFaster.GameLogic.Input.Handlers
{
    public class InputHandler : IInputHandler
    {
        private ITypingRaceInstance _typingRaceInstance;

        private readonly RaceInstanceModifier _raceInstanceModifier;

        public InputHandler(RaceInstanceModifier raceInstanceModifier)
        {
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

        public void IssueUndoCommand()
        {
            _raceInstanceModifier.InvokeUndo();
        }
    }
}
