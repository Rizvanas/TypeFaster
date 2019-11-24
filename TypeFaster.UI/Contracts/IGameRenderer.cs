using TypeFaster.GameServices.Contracts;
using TypeFaster.UI.RenderingStates;

namespace TypeFaster.UI.Contracts
{
    public interface IGameRenderer : IObserver
    {
        void SetTypingRaceInstance(ITypingRaceInstance typingRace);
        void Render();
        void RenderGameWindow();
        void RenderUserInput();
        void RenderPlayerTypingSpeed();
        void RenderPausedStateWindow();
        void ChangeState(RendererState state);
    }
}
