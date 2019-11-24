namespace TypeFaster.GameLogic.Contracts.TypingRace
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}
