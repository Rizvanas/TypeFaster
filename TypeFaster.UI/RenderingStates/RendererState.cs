using System;
using TypeFaster.UI.Contracts;

namespace TypeFaster.UI.RenderingStates
{
    public abstract class RendererState
    {
        protected IGameRenderer _gameRenderer;

        public void SetGameRenderer(IGameRenderer gameRenderer)
        {
            _gameRenderer = gameRenderer;
        }

        public abstract void Render();
    }
}
