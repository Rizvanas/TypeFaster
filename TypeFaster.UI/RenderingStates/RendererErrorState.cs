
namespace TypeFaster.UI.RenderingStates
{
    public class RendererErrorState : RendererState
    {
        public override void Render()
        {
            _gameRenderer.RenderGameWindow();
            _gameRenderer.RenderUserInput();
            _gameRenderer.RenderPlayerTypingSpeed();
        }
    }
}
