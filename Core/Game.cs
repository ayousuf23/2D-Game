using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Core
{
    public class Game : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Engine.Scene.ISceneManager _sceneManager;
        private Engine.Graphics.IGraphicsManager _graphicsManager;
        private Engine.Content.IContentManager _contentManager;

        private Engine.Map.TiledMap _map;

        private Main.Player _player;

        private Engine.Camera _camera;

        public Game()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _sceneManager = new Engine.Scene.SceneManager(Exit);
            _contentManager = new Engine.Content.FileContentManager(GraphicsDevice);
            _graphicsManager = new Engine.Graphics.GraphicsManager(GraphicsDevice);
            

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Engine.GameServices.Initialize(_sceneManager, _contentManager, _graphicsManager, _spriteBatch);

            _map = Engine.Map.TiledMapFactory.Create(@"resources\level1.tmx").Build();

            _player = new Main.Player();
            _camera = new Engine.Camera();
            _camera.Follow(_player);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            _player.Update(gameTime);
            _camera.Follow(_player);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin(blendState: BlendState.NonPremultiplied, transformMatrix: _camera.Transform);
            
            _map.Draw();

            _player.Draw();

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
