using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace monogame_topic3
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D tribbleGreyTexture;
        Texture2D tribbleBrownTexture;
        Texture2D tribbleCreamTexture;
        Texture2D tribbleOrangeTexture;
        Rectangle tribbleGreyRect;
        Rectangle tribbleBrownRect;
        Rectangle tribbleCreamRect;
        Rectangle tribbleOrangeRect;
        Vector2 tribbleGreySpeed;
        Vector2 tribbleBrownSpeed;
        Vector2 tribbleCreamSpeed;
        Vector2 tribbleOrangeSpeed;

        SoundEffect tribblecoo;

        Texture2D introTexture;
        Rectangle introRect;
        Screen screen;
        MouseState mouseState;
        SpriteFont file;

        enum Screen
        {
            Intro,
            Tribbleyard
        }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            tribbleGreyRect = new Rectangle(350, 250, 100, 100);
            tribbleBrownRect = new Rectangle(350, 250, 100, 100);
            tribbleCreamRect = new Rectangle(350, 250, 100, 100);
            tribbleOrangeRect = new Rectangle(350, 250, 100, 100);
            tribbleGreySpeed = new Vector2(3, 1);
            tribbleBrownSpeed = new Vector2(2, 2);
            tribbleCreamSpeed = new Vector2(4, 0);
            tribbleOrangeSpeed = new Vector2(0, 4);

            introRect = new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            screen = Screen.Intro;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            tribbleGreyTexture = Content.Load<Texture2D>("tribbleGrey");
            tribbleBrownTexture = Content.Load<Texture2D>("tribbleBrown");
            tribbleCreamTexture = Content.Load<Texture2D>("tribbleCream");
            tribbleOrangeTexture = Content.Load<Texture2D>("tribbleOrange");

            tribblecoo = Content.Load<SoundEffect>("tribble_coo");

            introTexture = Content.Load<Texture2D>("Untitled");
            file = Content.Load<SpriteFont>("File");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            mouseState = Mouse.GetState();
            if (screen == Screen.Intro)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                    screen = Screen.Tribbleyard;
            }
            else if (screen == Screen.Tribbleyard)
            {
                tribbleGreyRect.X += (int)tribbleGreySpeed.X;
                if (tribbleGreyRect.Right > _graphics.PreferredBackBufferWidth || tribbleGreyRect.X < 0)
                {
                    tribblecoo.Play();
                    tribbleGreySpeed.X *= -1;
                }

                tribbleGreyRect.Y += (int)tribbleGreySpeed.Y;
                if (tribbleGreyRect.Bottom > _graphics.PreferredBackBufferHeight || tribbleGreyRect.Y < 0)
                {
                    tribblecoo.Play();
                    tribbleGreySpeed.Y *= -1;
                }

                tribbleBrownRect.X += (int)tribbleBrownSpeed.X;
                if (tribbleBrownRect.Right > _graphics.PreferredBackBufferWidth || tribbleBrownRect.X < 0)
                {
                    tribblecoo.Play();
                    tribbleBrownSpeed.X *= -1;
                }

                tribbleBrownRect.Y += (int)tribbleBrownSpeed.Y;
                if (tribbleBrownRect.Bottom > _graphics.PreferredBackBufferHeight || tribbleBrownRect.Y < 0)
                {
                    tribblecoo.Play();
                    tribbleBrownSpeed.Y *= -1;
                }

                tribbleCreamRect.X += (int)tribbleCreamSpeed.X;
                if (tribbleCreamRect.Right > _graphics.PreferredBackBufferWidth || tribbleCreamRect.X < 0)
                {
                    tribblecoo.Play();
                    tribbleCreamSpeed.X *= -1;
                }

                tribbleCreamRect.Y += (int)tribbleCreamSpeed.Y;
                if (tribbleCreamRect.Bottom > _graphics.PreferredBackBufferHeight || tribbleCreamRect.Y < 0)
                {
                    tribblecoo.Play();
                    tribbleCreamSpeed.Y *= -1;
                }

                tribbleOrangeRect.X += (int)tribbleOrangeSpeed.X;
                if (tribbleOrangeRect.Right > _graphics.PreferredBackBufferWidth || tribbleOrangeRect.X < 0)
                {
                    tribblecoo.Play();
                    tribbleOrangeSpeed.X *= -1;
                }

                tribbleOrangeRect.Y += (int)tribbleOrangeSpeed.Y;
                if (tribbleOrangeRect.Bottom > _graphics.PreferredBackBufferHeight || tribbleOrangeRect.Y < 0)
                {
                    tribblecoo.Play();
                    tribbleOrangeSpeed.Y *= -1;
                }
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            if (screen == Screen.Intro)
            {
                _spriteBatch.Draw(introTexture, introRect, Color.White);
                _spriteBatch.DrawString(file, "Left click to go to the tribble yard", new Vector2(150, 300), Color.White);
            }
            else if (screen == Screen.Tribbleyard)
            {
                _spriteBatch.Draw(tribbleGreyTexture, tribbleGreyRect, Color.White);
                _spriteBatch.Draw(tribbleBrownTexture, tribbleBrownRect, Color.White);
                _spriteBatch.Draw(tribbleCreamTexture, tribbleCreamRect, Color.White);
                _spriteBatch.Draw(tribbleOrangeTexture, tribbleOrangeRect, Color.White);
            }


            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}