using TypeFaster.GameLogic.TypingRace.States;

namespace TypeFaster.GameLogic.Contracts.TypingRace
{
    public interface IObserver
    {
        void Update(TypingRaceState typingRaceState);
    }
}
