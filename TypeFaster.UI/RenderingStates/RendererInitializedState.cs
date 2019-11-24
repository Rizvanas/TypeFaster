
namespace TypeFaster.UI.RenderingStates
{
    public class RendererInitializedState : RendererState
    {
        public override void Render()
        {
            _gameRenderer.RenderGameWindow();
        }
    }
}
