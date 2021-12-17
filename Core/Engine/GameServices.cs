using System;
using Core.Engine.Content;
using Core.Engine.Graphics;
using Core.Engine.Scene;

namespace Core.Engine
{
    public static class GameServices
    {
        public static ISceneManager SceneManager { private set; get; }

        public static IContentManager ContentManager { private set; get; }

        public static IGraphicsManager GraphicsManager { private set; get; }

        public static void Initialize(ISceneManager sceneManager, IContentManager contentManager, IGraphicsManager graphicsManager)
        {
            SceneManager = sceneManager;
            ContentManager = contentManager;
            GraphicsManager = graphicsManager;
        }
    }
}
