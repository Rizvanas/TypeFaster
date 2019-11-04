namespace TypeFaster.GameLogic.Contracts
{
    public interface IUserInputListener
    {
        void SetOnLetterOnSymbolPressed(ICommand command);
        void SetOnBackspacePressed(ICommand command);
        void Listen();
    }
}
