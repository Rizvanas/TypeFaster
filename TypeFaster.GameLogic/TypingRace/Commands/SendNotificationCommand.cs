using TypeFaster.GameLogic.Contracts.TypingRace;

namespace TypeFaster.GameLogic.TypingRace.Commands
{
    public class SendNotificationCommand : ICommand
    {
        private readonly ITypingRaceInstance _typingRaceInstance;

        public SendNotificationCommand(ITypingRaceInstance typingRaceInstance)
        {
            _typingRaceInstance = typingRaceInstance;
        }

        public void Execute()
        {
            _typingRaceInstance.Notify();
        }

        public void Undo()
        {
        }
    }
}
