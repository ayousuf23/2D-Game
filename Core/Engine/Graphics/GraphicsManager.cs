using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Core.Engine.Graphics
{
    public class GraphicsManager : IGraphicsManager
    {
        private GraphicsDevice _graphicsDevice;

        public GraphicsManager(GraphicsDevice graphicsDevice)
        {
            _graphicsDevice = graphicsDevice;
        }

        public int ViewportWidth => _graphicsDevice.Viewport.Width;

        public int ViewportHeight => _graphicsDevice.Viewport.Height;

        public bool IsFullscreen => throw new NotImplementedException();

        public void ToggleFullscreen()
        {
            throw new NotImplementedException();
        }
    }
}
