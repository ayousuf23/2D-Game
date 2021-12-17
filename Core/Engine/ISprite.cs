using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Core.Engine
{
    public interface ISprite : IEntity
    {
        Rectangle Rectangle { get; }

        Vector2 Position { get; }
    }
}
