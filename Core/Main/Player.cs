using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Core.Main
{
    public class Player : Engine.ISprite
    {
        private Texture2D Texture;

        public Rectangle Rectangle => Texture.Bounds;

        public Vector2 Position { get; private set; }

        private Vector2 Velocity = new Vector2(300f, 300f);

        private float Rotation = 0f;

        public Player()
        {
            Texture = Engine.GameServices.ContentManager.LoadTexture2D(@"resources\player.png");
        }

        public void Draw()
        {
            Engine.GameServices.SpriteBatch.Draw(Texture, Position, null, Color.White, Rotation, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();
            Vector2 velocity = Vector2.Zero;
            if (state.IsKeyDown(Keys.W)) velocity = new Vector2(0f, -1f);
            else if (state.IsKeyDown(Keys.S)) velocity = new Vector2(0f, 1f);

            if (state.IsKeyDown(Keys.A)) velocity += new Vector2(-1f, 0f);
            else if (state.IsKeyDown(Keys.D)) velocity += new Vector2(1f, 0f);

            Vector2 result = velocity * Velocity;
            result = new Vector2(result.X * (float)gameTime.ElapsedGameTime.TotalSeconds, result.Y * (float)gameTime.ElapsedGameTime.TotalSeconds);

            Position += result;
            Position.Round();

            //TO-DO: Need to convert mouse coordinates to map coordinates
            MouseState mouse = Mouse.GetState();
            Vector2 playerMouseDiff = new Vector2(mouse.X - Position.X, mouse.Y - Position.Y);
            System.Diagnostics.Debug.WriteLine(mouse.Position);
            float sin = playerMouseDiff.Y / playerMouseDiff.Length();
            Rotation = (float)Math.Asin(sin);
        }
    }
}
