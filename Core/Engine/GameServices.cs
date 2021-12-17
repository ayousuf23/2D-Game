using System;
using Core.Engine.Content;
using Core.Engine.Graphics;
using Core.Engine.Scene;
using Microsoft.Xna.Framework.Graphics;

namespace Core.Engine
{
    public static class GameServices
    {
        public static ISceneManager SceneManager { private set; get; }

        public static IContentManager ContentManager { private set; get; }

        public static IGraphicsManager GraphicsManager { private set; get; }

        public static SpriteBatch SpriteBatch { private set; get; }

        public static void Initialize(ISceneManager sceneManager, IContentManager contentManager, IGraphicsManager graphicsManager, SpriteBatch spriteBatch)
        {
            SceneManager = sceneManager;
            ContentManager = contentManager;
            GraphicsManager = graphicsManager;
            SpriteBatch = spriteBatch;
        }
    }
}
