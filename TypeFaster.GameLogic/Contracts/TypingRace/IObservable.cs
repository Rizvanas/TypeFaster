
namespace TypeFaster.GameLogic.Contracts.TypingRace
{
    public interface IObservable
    {
        void Subscribe(IObserver observer);
        void Unsubscribe(IObserver observer);
        void Notify();
    }
}
