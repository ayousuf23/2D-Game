using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Engine.Graphics
{
    public interface IGraphicsManager
    {
        int ViewportWidth { get; }

        int ViewportHeight { get; }

        bool IsFullscreen { get; }

        void ToggleFullscreen();

    }
}
