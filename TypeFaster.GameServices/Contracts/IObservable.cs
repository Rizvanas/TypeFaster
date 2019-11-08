
namespace TypeFaster.GameServices.Contracts
{
    public interface IObservable
    {
        void Subscribe(IObserver observer);
        void Unsubscribe(IObserver observer);
        void Notify();
    }
}
