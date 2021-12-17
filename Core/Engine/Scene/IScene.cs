using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Engine.Scene
{
    public interface IScene : IEntity
    {
        void OnShow();

        void OnLeave();
    }
}
