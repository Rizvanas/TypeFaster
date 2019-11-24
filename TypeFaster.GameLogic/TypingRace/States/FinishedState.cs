using System;
using System.Collections.Generic;
using System.Text;
using TypeFaster.GameLogic.Contracts.TypingRace;

namespace TypeFaster.GameLogic.TypingRace.States
{
    public class FinishedState : TypingRaceState
    {
        public override void HandleInput(ConsoleKeyInfo keyInfo)
        {
            if (keyInfo.Key == ConsoleKey.Enter)
                _inputHandler.IssueGameStateChangingCommand(new InitializedState());

            if (keyInfo.Key == ConsoleKey.Escape)
                _inputHandler.IssueGameStateChangingCommand(new ExitConfirmationState());
        }

        public override void Render(ITypingRaceInstance typingRaceInstance)
        {
            throw new NotImplementedException();
        }
    }
}
