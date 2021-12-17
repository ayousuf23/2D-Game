using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Engine.Content
{
    public class FileContentManager : IContentManager
    {
        private GraphicsDevice _graphicsDevice;

        public FileContentManager(GraphicsDevice graphicsDevice)
        {
            _graphicsDevice = graphicsDevice;
        }

        public Texture2D LoadTexture2D(string path)
        {
            return Texture2D.FromFile(_graphicsDevice, path);
        }
    }
}
