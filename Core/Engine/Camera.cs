using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Core.Engine
{
    public class Camera
    {
        public Matrix Transform { get; private set; }

        public void Follow(ISprite target)
        {
            var position = Matrix.CreateTranslation(
                  Math.Min(-target.Position.X, Engine.GameServices.GraphicsManager.ViewportWidth / -2f) - (target.Rectangle.Width / 2),
                  Math.Min(-target.Position.Y, Engine.GameServices.GraphicsManager.ViewportHeight / -2f) - (target.Rectangle.Height / 2),
                  0);
            
            var offset = Matrix.CreateTranslation(
                Engine.GameServices.GraphicsManager.ViewportWidth / 2,
                Engine.GameServices.GraphicsManager.ViewportHeight / 2,
                0);
            
            Transform = position * offset;
        }
    }
}
