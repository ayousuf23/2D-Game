using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TiledSharp;

namespace Core.Engine.Map
{
    public class TiledMap : IDrawable
    {
        private List<Tile> _tiles;

        //Center of rotation for tiles
        private Vector2 _tileCenter;

        public TiledMap(List<Tile> tiles, int tileWidth, int tileHeight)
        {
            _tiles = tiles;
            _tileCenter = new Vector2(tileWidth / 2f, tileHeight / 2f);
        }

        public void Draw()
        {
            foreach (var tile in _tiles)
            {
                Vector2 origin = (tile.Rotation > 0f) ? _tileCenter :  Vector2.Zero;
                Engine.GameServices.SpriteBatch.Draw(tile.Texture, tile.Destination, tile.Source, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0f);
            }

        }

    }
}
