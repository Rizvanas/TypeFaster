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
        void IssueErrorDeletionCommand();
        void IssueErrorStateToggleCommand();
        void IssueTyposUpdateCommand();
        void IssueTimerToggleCommand();
        void IssueTimerRestartCommand();
        void IssueGameInitializationCommand();
        void InvokeEventDispatchEnableCommand();
        void IssueEventDispatchDisableCommand();
        void InvokeTryFinishGameCommand();
        void InvokeSendNotificationCommand();
        void IssueUndoCommand();
        void InvokePreErrorInputUpdateCommand();
        void InvokeCommand(ICommand command);
    }
}
