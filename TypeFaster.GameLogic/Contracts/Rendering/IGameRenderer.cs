using TypeFaster.GameLogic.Contracts.TypingRace;

namespace TypeFaster.GameLogic.Contracts.Rendering
{
    public interface IGameRenderer : IObserver
    {
        void SetTypingRaceInstance(ITypingRaceInstance typingRace);
        void RenderGameWindow();
        void RenderPrompt(string prompt);
        void RenderUserInput();
        void RenderPlayerTypingSpeed();
        void RenderEndPlayerStats();
        void RenderTimeLeft();
    }
}
