using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Engine.Scene
{
    public interface ISceneManager : IEntity
    {
        void GoToScene(string scene);

        void GoToPreviousScene();

        void AddScene(string name, IScene scene);

        void ExitGame();
    }
}
