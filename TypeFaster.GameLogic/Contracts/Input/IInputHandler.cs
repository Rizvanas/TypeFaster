using System;
using TypeFaster.GameLogic.Contracts.TypingRace;
using TypeFaster.GameLogic.TypingRace.States;

namespace TypeFaster.GameLogic.Contracts.Input
{
    public interface IInputHandler
    {
        void SetTypingRaceInstance(ITypingRaceInstance typingRaceInstance);
        void IssueLetterAdditionCommand(ConsoleKeyInfo keyInfo);
        void IssueLetterDeletionCommand();
        void IssueGameStateChangingCommand(TypingRaceState typingRaceState);
        void IssueErrorStateToggleCommand();
        void IssueTyposUpdateCommand();
        void IssueUndoCommand();
    }
}
