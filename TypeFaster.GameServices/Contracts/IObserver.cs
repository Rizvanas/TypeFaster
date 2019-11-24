using TypeFaster.Domain.ValueObjects;

namespace TypeFaster.GameServices.Contracts
{
    public interface IObserver
    {
        void Update(TypingRaceState typingRaceState);
    }
}
