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

        public Player()
        {
            Texture = Engine.GameServices.ContentManager.LoadTexture2D(@"resources\player.png");
        }

        public void Draw()
        {
            Engine.GameServices.SpriteBatch.Draw(Texture, Position, Color.White);
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
        }
    }
}
