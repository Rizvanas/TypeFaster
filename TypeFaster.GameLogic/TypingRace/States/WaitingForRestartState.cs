using System;
using TypeFaster.GameLogic.Contracts.TypingRace;

namespace TypeFaster.GameLogic.TypingRace.States
{
    public class WaitingForRestartState : TypingRaceState
    {
        public override void HandleInput(ConsoleKeyInfo keyInfo)
        {
        }

        public override void Render(ITypingRaceInstance typingRaceInstance)
        {
        }
    }
}
