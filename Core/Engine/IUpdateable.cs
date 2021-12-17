using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Engine
{
    public interface IUpdateable
    {
        void Update(Microsoft.Xna.Framework.GameTime gameTime);
    }
}
