using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace Game
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        _2048 __2048 = new _2048();
        SpriteFont Sp;
        SpriteFont SPScore;
        Vector2 Postion;
        Texture2D ScoreT;
        Vector2 ScorePostion = new Vector2(500, 100);
        Texture2D[] Digit = new Texture2D[12];
        InputManager Is = new InputManager();
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //this.graphics.IsFullScreen = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Sp = this.Content.Load<SpriteFont>("SpriteFont1");
            SPScore = this.Content.Load<SpriteFont>("SpriteFont2");
            Digit[0] = this.Content.Load<Texture2D>("2");
            Digit[1] = this.Content.Load<Texture2D>("4");
            Digit[2] = this.Content.Load<Texture2D>("8");
            Digit[3] = this.Content.Load<Texture2D>("16");
            Digit[4] = this.Content.Load<Texture2D>("32");
            Digit[5] = this.Content.Load<Texture2D>("64");
            Digit[6] = this.Content.Load<Texture2D>("128");
            Digit[7] = this.Content.Load<Texture2D>("256");
            Digit[8] = this.Content.Load<Texture2D>("512");
            Digit[9] = this.Content.Load<Texture2D>("1024");
            Digit[10] = this.Content.Load<Texture2D>("2048");
            Digit[11] = this.Content.Load<Texture2D>("0");
            ScoreT = this.Content.Load<Texture2D>("score_wallpaper");
            Postion = Vector2.Zero;
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
           
           
            if (Is.IsKeyJustPressed(Keys.Escape))
                this.Exit();

            // TODO: Add your update logic here
            if (Is.IsKeyJustPressed(Keys.Left))
            {
                __2048.waitKey(Keys.Left);
                __2048.moved = false;
                
                
                
            }
            if (Is.IsKeyJustPressed(Keys.Right))
            {
                __2048.waitKey(Keys.Right);
                __2048.moved = false;

            }
            if (Is.IsKeyJustPressed(Keys.Up))
            {
                __2048.waitKey(Keys.Up);
                __2048.moved = false;
                

            }

            if (Is.IsKeyJustPressed(Keys.Down))
            {
                __2048.waitKey(Keys.Down);
                __2048.moved = false;

            }
            if(Is.IsKeyJustPressed(Keys.Tab)){
            graphics.IsFullScreen=!graphics.IsFullScreen;
                graphics.ApplyChanges();
            }
            Is.Update();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
           GraphicsDevice.Clear(Color.CornflowerBlue);
           Postion.Y = 100;
           Postion.X = 100;
            spriteBatch.Begin();
            // TODO: Add your drawing code here
            spriteBatch.Draw(ScoreT, ScorePostion, Color.White);
            spriteBatch.DrawString(SPScore, "SCORE", new Vector2(545, 140), Color.White);
            spriteBatch.DrawString(SPScore, __2048.Score.ToString(), new Vector2(565, 260), Color.White);
            for (int i = 0; i < 4; i++)
            {
              
                for (int j = 0; j < 4; j++)
                {
                    switch (__2048.GetBoard(i, j)) { 
                    
                        case 2:
                            spriteBatch.Draw(Digit[0], Postion, Color.White);
                            break;
                        case 4:
                            spriteBatch.Draw(Digit[1], Postion, Color.White);
                            break;
                        case 8:
                            spriteBatch.Draw(Digit[2], Postion, Color.White);
                            break;
                        case 16:
                            spriteBatch.Draw(Digit[3], Postion, Color.White);
                            break;
                        case 32:
                            spriteBatch.Draw(Digit[4], Postion, Color.White);
                            break;
                        case 64:
                            spriteBatch.Draw(Digit[5], Postion, Color.White);
                            break;
                        case 128:
                            spriteBatch.Draw(Digit[6], Postion, Color.White);
                            break;
                        case 256:
                            spriteBatch.Draw(Digit[7], Postion, Color.White);
                            break;
                        case 512:
                            spriteBatch.Draw(Digit[8], Postion, Color.White);
                            break;
                        case 1024:
                            spriteBatch.Draw(Digit[9], Postion, Color.White);
                            break;
                        case 2048:
                            spriteBatch.Draw(Digit[10], Postion, Color.White);
                            break;
                            case 0:
                            spriteBatch.Draw(Digit[11], Postion, Color.White);
                            break;

                    }
                  //  spriteBatch.DrawString(Sp, __2048.GetBoard(i, j).ToString(), Postion, Color.Black);
                    Postion.Y += 100;
                }

                Postion.X += 100;
                Postion.Y = 100;
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
