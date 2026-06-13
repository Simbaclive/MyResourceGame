using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace MyResourceGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

       
        private Texture2D _pixel; 
        private SpriteFont _scoreFont;

     
        private Vector2 _playerPosition = new Vector2(150, 150);
        private Rectangle _playerBounds;
        private int _playerSpeed = 280;

        
        private Vector2 _resourcePosition;
        private Rectangle _resourceBounds;
        private bool _isResourceActive = true;
        private int _score = 0;
        private Random _random = new Random();

      
        private float _timeCounter = 0f; 

        private Color _grassDark = new Color(34, 139, 34);      
        private Color _grassLight = new Color(50, 205, 50);     
        private Color _playerColor = new Color(30, 144, 255);    
        private Color _playerDetail = new Color(240, 248, 255);  
        private Color _goldColor = new Color(255, 215, 0);       
        private Color _goldGlow = new Color(255, 165, 0);        
        private Color _hudBackground = new Color(0, 0, 0, 180);  

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;
        }

        protected override void Initialize()
        {
            _playerBounds = new Rectangle((int)_playerPosition.X, (int)_playerPosition.Y, 36, 36);
            SpawnResource();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
            _pixel = new Texture2D(GraphicsDevice, 1, 1);
            _pixel.SetData(new[] { Color.White });

            _scoreFont = Content.Load<SpriteFont>("ScoreFont");
        }

        private void SpawnResource()
        {
            int maxX = _graphics.PreferredBackBufferWidth - 60;
            int maxY = _graphics.PreferredBackBufferHeight - 60;
            _resourcePosition = new Vector2(_random.Next(60, maxX), _random.Next(60, maxY));
            _resourceBounds = new Rectangle((int)_resourcePosition.X, (int)_resourcePosition.Y, 24, 24);
            _isResourceActive = true;
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            
           
            _timeCounter += deltaTime;

            var keyboardState = Keyboard.GetState();
            Vector2 movement = Vector2.Zero;

            if (keyboardState.IsKeyDown(Keys.W) || keyboardState.IsKeyDown(Keys.Up)) movement.Y = -1;
            if (keyboardState.IsKeyDown(Keys.S) || keyboardState.IsKeyDown(Keys.Down)) movement.Y = 1;
            if (keyboardState.IsKeyDown(Keys.A) || keyboardState.IsKeyDown(Keys.Left)) movement.X = -1;
            if (keyboardState.IsKeyDown(Keys.D) || keyboardState.IsKeyDown(Keys.Right)) movement.X = 1;

            if (movement != Vector2.Zero)
            {
                movement.Normalize();
                _playerPosition += movement * _playerSpeed * deltaTime;
            }

            _playerPosition.X = Math.Clamp(_playerPosition.X, 0, _graphics.PreferredBackBufferWidth - _playerBounds.Width);
            _playerPosition.Y = Math.Clamp(_playerPosition.Y, 0, _graphics.PreferredBackBufferHeight - _playerBounds.Height);
            
            _playerBounds.X = (int)_playerPosition.X;
            _playerBounds.Y = (int)_playerPosition.Y;

            if (_isResourceActive && _playerBounds.Intersects(_resourceBounds))
            {
                _isResourceActive = false;
                _score += 10;
                Console.WriteLine($"Resource Collected! Total Gold Score: {_score}");
                SpawnResource();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(_grassDark);

            _spriteBatch.Begin();

           
            int tileSize = 40;
            for (int x = 0; x < _graphics.PreferredBackBufferWidth; x += tileSize)
            {
                for (int y = 0; y < _graphics.PreferredBackBufferHeight; y += tileSize)
                {
                    if ((x / tileSize + y / tileSize) % 2 == 0)
                    {
                        _spriteBatch.Draw(_pixel, new Rectangle(x, y, tileSize, tileSize), _grassLight * 0.15f);
                    }
                }
            }

           
            if (_isResourceActive)
            {
                Rectangle shadowBounds = new Rectangle(_resourceBounds.X - 2, _resourceBounds.Y - 2, _resourceBounds.Width + 4, _resourceBounds.Height + 4);
                _spriteBatch.Draw(_pixel, shadowBounds, _goldGlow); 
                _spriteBatch.Draw(_pixel, _resourceBounds, _goldColor); 
            }

            
            _spriteBatch.Draw(_pixel, _playerBounds, _playerColor); 
            Rectangle leftEye = new Rectangle(_playerBounds.X + 6, _playerBounds.Y + 8, 6, 10);
            Rectangle rightEye = new Rectangle(_playerBounds.X + _playerBounds.Width - 12, _playerBounds.Y + 8, 6, 10);
            _spriteBatch.Draw(_pixel, leftEye, _playerDetail);
            _spriteBatch.Draw(_pixel, rightEye, _playerDetail);

           
            Rectangle hudBox = new Rectangle(15, 15, 320, 60);
            _spriteBatch.Draw(_pixel, hudBox, _hudBackground); 
            
            
            float pulseSpeed = 4f; 
            float textScale = 1.2f + (float)Math.Sin(_timeCounter * pulseSpeed) * 0.1f;

            
            string hudText = $"INVENTORY: {_score} GOLD";
            Vector2 textPosition = new Vector2(30, 30);

            _spriteBatch.DrawString(
                _scoreFont,          
                hudText,            
                textPosition,        
                Color.Yellow,        
                0f,                  
                Vector2.Zero,        
                textScale,           
                SpriteEffects.None,  
                0f                   
            );

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}