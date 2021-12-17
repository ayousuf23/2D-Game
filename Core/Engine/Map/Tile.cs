using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Core.Engine.Map
{
    public class Tile
    {
        public Rectangle Source { get; set; }
        public Rectangle Destination { get; set; }

        public Texture2D Texture { get; set; }

        public SpriteEffects Effect { get; set; }

        public float Rotation { get; set; }

        public Tile(Rectangle source, Rectangle destination, Texture2D texture, SpriteEffects effect, float rotation)
        {
            Source = source;
            Destination = destination;
            Texture = texture;
            Effect = effect;
            Rotation = rotation;
        }
    }
}
