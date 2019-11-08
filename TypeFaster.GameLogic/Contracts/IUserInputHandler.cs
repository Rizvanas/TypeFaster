using TypeFaster.GameServices.Contracts;

namespace TypeFaster.GameLogic.Contracts
{
    public interface IUserInputHandler
    {
        void SetTypingRace(ITypingRace typingRace);
        void Listen();
    }
}
