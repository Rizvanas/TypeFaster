using TypeFaster.GameLogic.Contracts.TypingRace;

namespace TypeFaster.GameLogic.Contracts.Rendering
{
    public interface IGameRenderer : IObserver
    {
        void SetTypingRaceInstance(ITypingRaceInstance typingRace);
        void RenderGameWindow();
        void RenderPausedStatePrompt();
        void RenderInitializedStatePrompt();
        void RenderExitConfirmationPrompt();
        void RenderGameOverPrompt();
        void RenderGameFinishedPrompt();
        void RenderUserInput();
        void RenderPlayerTypingSpeed();
        void RenderEndPlayerStats();
        void RenderTimeLeft();
    }
}
