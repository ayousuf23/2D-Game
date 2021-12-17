using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Core.Engine.Content
{
    public interface IContentManager
    {
        Texture2D LoadTexture2D(string path);
    }
}
