using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Engine.Scene
{
    public class SceneManager : ISceneManager
    {
        private IDictionary<string, IScene> Scenes;

        private IScene _currentScene;

        private string _previousScene;

        private string _currentSceneName;

        private Action _exitFunction;

        public SceneManager(Action exitFunction)
        {
            Scenes = new Dictionary<string, IScene>();
            _exitFunction = exitFunction;
        }

        public void AddScene(string name, IScene scene)
        {
            Scenes[name] = scene;
        }

        public void GoToScene(string scene)
        {
            _currentScene?.OnLeave();
            _currentScene = Scenes[scene];
            _previousScene = _currentSceneName;
            _currentSceneName = scene;
            _currentScene?.OnShow();
        }
        public void Draw()
        {
            _currentScene?.Draw();
        }

        public void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            _currentScene?.Update(gameTime);
        }

        public void GoToPreviousScene()
        {
            GoToScene(_previousScene);
        }

        public void ExitGame()
        {
            if (_exitFunction != null)
            {
                _exitFunction();
            }
        }
    }
}
