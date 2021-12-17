using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TiledSharp;

namespace Core.Engine.Map
{
    public class TiledMapFactory
    {
        private Dictionary<string, Texture2D> TextureDictionary;

        private TmxMap Map;

        public TiledMapFactory()
        {

        }

        private void CreateTextureDictionary()
        {
            TextureDictionary = new Dictionary<string, Texture2D>();
            foreach (var tileset in Map.Tilesets)
            {
                if (!TextureDictionary.ContainsKey(tileset.Name))
                {
                    TextureDictionary[tileset.Name] = Engine.GameServices.ContentManager.LoadTexture2D("resources\\"+tileset.Name);
                }
            }
        }

        private TmxTileset GetTileset(int gid)
        {
            if (gid == 0) return null;
            foreach (var tileset in Map.Tilesets)
            {
                if (tileset.FirstGid <= gid && tileset.FirstGid + tileset.TileCount >= gid) return tileset; 
            }
            return null;
        }

        public List<Tile> CreateTiles(string path)
        {
            Map = new TmxMap(path);
            CreateTextureDictionary();

            List<Tile> tiles = new List<Tile>();

            foreach (var layer in Map.Layers)
            {
                foreach (var tile in layer.Tiles)
                {
                    if (tile.Gid == 0) continue;
                    //Get tileset for tile
                    var tileset = GetTileset(tile.Gid);

                    //Get source rectangle
                    int tileFrame = tile.Gid - 1;
                    //int column = tileFrame % tilesetTilesWide;
                    int column = tileFrame % tileset.Columns.Value;
                    //int row = (int)Math.Floor((double)tileFrame / (double)tilesetTilesWide);
                    int row = tileFrame / tileset.Columns.Value;

                    int x = tile.X * Map.TileWidth;
                    int y = tile.Y * Map.TileHeight;

                    Rectangle tilesetRec = new Rectangle(tileset.Margin + (tileset.TileWidth * column) + (tileset.Spacing * (column)), tileset.Margin + (tileset.TileHeight * row) + (tileset.Spacing * (row)), tileset.TileWidth, tileset.TileHeight);
                    Rectangle finalRect = new Rectangle(x, y, Map.TileWidth, Map.TileHeight);

                    //Get tileset texture
                    Texture2D texture = TextureDictionary[tileset.Name];
                    
                    if (tile.Gid == 141)
                    {
                        Console.WriteLine("hi");
                    }

                    SpriteEffects effect = SpriteEffects.None;
                    float rotation = 0f;
                    if (tile.HorizontalFlip && tile.DiagonalFlip && !tile.VerticalFlip) rotation = 1f * (float)Math.PI / 2f;
                    else if (tile.HorizontalFlip && !tile.DiagonalFlip && tile.VerticalFlip) rotation = (float)Math.PI;
                    else if (tile.HorizontalFlip) effect = SpriteEffects.FlipHorizontally;
                    else if (tile.VerticalFlip) effect = SpriteEffects.FlipVertically;
                    else if (tile.DiagonalFlip) rotation = 1f;

                    tiles.Add(new Tile(tilesetRec, finalRect, texture, effect, rotation));
                }
            }

            return tiles;
        }
    }
}
