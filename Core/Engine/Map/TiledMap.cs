using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TiledSharp;

namespace Core.Engine.Map
{
    public class TiledMap
    {
        TmxMap map;
        Texture2D tileset;

        int tileWidth;
        int tileHeight;
        int tilesetTilesWide;
        int tilesetTilesHigh;

        public void Draw()
        {
            TmxTileset tmxTileset = map.Tilesets[0];
            for (var i = 0; i < map.Layers[0].Tiles.Count; i++)
            {
                int gid = map.Layers[0].Tiles[i].Gid;

                // Empty tile, do nothing
                if (gid == 0)
                {

                }
                else
                {
                    int tileFrame = gid - 1;
                    int column = tileFrame % tilesetTilesWide;
                    int row = (int)Math.Floor((double)tileFrame / (double)tilesetTilesWide);

                    float x = (i % map.Width) * map.TileWidth;
                    float y = (float)Math.Floor(i / (double)map.Width) * map.TileHeight;

                    Rectangle tilesetRec = new Rectangle(tmxTileset.Margin + (tileWidth * column) + (tmxTileset.Spacing * (column)), tmxTileset.Margin + (tileHeight * row) + (tmxTileset.Spacing * (row)), tileWidth, tileHeight);

                    Engine.GameServices.SpriteBatch.Draw(tileset, new Rectangle((int)x, (int)y, tileWidth, tileHeight), tilesetRec, Color.White);
                }
            }

        }

        public TiledMap(string path)
        {
            map = new TmxMap(path);
            tileset = Engine.GameServices.ContentManager.LoadTexture2D("resources\\"+map.Tilesets[0].Name.ToString());

            tileWidth = map.Tilesets[0].TileWidth;
            tileHeight = map.Tilesets[0].TileHeight;

            tilesetTilesWide = (tileset.Width + map.Tilesets[0].Spacing) / (tileWidth + map.Tilesets[0].Spacing);
            tilesetTilesHigh = tileset.Height / tileHeight;
        }

        public static TiledMap Create(string path)
        {
            TiledSharp.TmxMap map = new TiledSharp.TmxMap(path);
            return null;
        }

        private static Dictionary<TiledSharp.TmxTileset, Texture2D> GetTilesetDictionary(TiledSharp.TmxMap map)
        {
            Dictionary<TiledSharp.TmxTileset, Texture2D> tilesetDictionary = new Dictionary<TiledSharp.TmxTileset, Texture2D>();
            foreach (var tileset in map.Tilesets)
            {
                Texture2D texture = Engine.GameServices.ContentManager.LoadTexture2D(tileset.Image.Source);
                tilesetDictionary.Add(tileset, texture);
            }
            return tilesetDictionary;
        }

        private static TiledSharp.TmxTileset GetTileset(int gid, TiledSharp.TmxList<TiledSharp.TmxTileset> tilesets)
        {
            if (gid == 0) return null;
            foreach (var tileset in tilesets)
            {
                if (gid >= tileset.FirstGid && gid <= tileset.FirstGid + tileset.Tiles.Count) return tileset;
            }
            return null;
        }

        private static Rectangle GetSourceRectangle(int gid, TiledSharp.TmxMap map)
        {
            var tileset = GetTileset(gid, map.Tilesets);
            int location = gid - tileset.FirstGid;

            int col = location % tileset.TileWidth;
            //int row = location % tileset.
            return Rectangle.Empty;
        }

        private static void CreateTiles(TiledSharp.TmxMap map)
        {
            foreach (var l in map.Layers)
            {
                foreach (var tile in l.Tiles)
                {
                   
                }
            }
        }
    }
}
