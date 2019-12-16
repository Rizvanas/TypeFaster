using TypeFaster.GameLogic.Contracts.TypingRace;

namespace TypeFaster.GameLogic.Contracts.Input
{
    public interface ICommandInvoker
    {
        void SetCommand(ICommand command);
        void InvokeCommand();
        void InvokeUndo();
    }
}
