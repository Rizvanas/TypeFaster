using System;
using System.Collections.Generic;
using System.Text;
using TypeFaster.GameLogic.Contracts.TypingRace;

namespace TypeFaster.GameLogic.TypingRace.States
{
    public class ExitConfirmationState : TypingRaceState
    {
        public override void HandleInput(ConsoleKeyInfo keyInfo)
        {
            if (keyInfo.Key == ConsoleKey.Enter)
                _inputHandler.IssueGameStateChangingCommand(new ExitState());

            if (keyInfo.Key == ConsoleKey.Escape)
                _inputHandler.IssueUndoCommand();
        }

        public override void Render(ITypingRaceInstance typingRaceInstance)
        {
            throw new NotImplementedException();
        }
    }
}
