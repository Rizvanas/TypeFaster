using TypeFaster.GameLogic.Contracts.TypingRace;

namespace TypeFaster.GameLogic.Contracts.Rendering
{
    public interface IGameRenderer
    {
        void SetTypingRaceInstance(ITypingRaceInstance typingRace);
        void RenderGameWindow();
        void RenderPausedStatePrompt();
        void RenderInitializedStatePrompt();
        void RenderExitConfirmationPrompt();
        void RenderUserInput();
        void RenderPlayerTypingSpeed();
    }
}
