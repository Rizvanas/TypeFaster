using System;

namespace TypeFaster.UI.RenderingStates
{
    public class RendererPausedState : RendererState
    {
        public override void Render()
        {
            Console.Clear();
            _gameRenderer.RenderGameWindow();
            _gameRenderer.RenderPausedStateWindow();
        }
    }
}
