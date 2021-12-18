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
            var targetX = Math.Min(-target.Position.X, Engine.GameServices.GraphicsManager.ViewportWidth / -2f);
            targetX = Math.Max(targetX, -3200 + Engine.GameServices.GraphicsManager.ViewportWidth / 2f);

            var targetY = Math.Min(-target.Position.Y, Engine.GameServices.GraphicsManager.ViewportHeight / -2f);
            targetY = Math.Max(targetY, -1920 + Engine.GameServices.GraphicsManager.ViewportHeight / 2f);

            var position = Matrix.CreateTranslation(
                  targetX,
                  targetY,
                  0);
            
            var offset = Matrix.CreateTranslation(
                Engine.GameServices.GraphicsManager.ViewportWidth / 2,
                Engine.GameServices.GraphicsManager.ViewportHeight / 2,
                0);
            
            Transform = position * offset;
        }
    }
}
