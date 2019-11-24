using TypeFaster.GameLogic.TypingRace.States;

namespace TypeFaster.GameLogic.Contracts.TypingRace
{
    public interface ITypingRaceInstance
    {
        void AddNewLetter(char letter);
        void DeleteLastLetter();
        void ChangeState(TypingRaceState state);
    }
}
