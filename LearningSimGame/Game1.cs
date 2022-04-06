using Cocos2D;
using CocosDenshion;
using LearningSimGame.components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace LearningSimGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        WorldState state;
        Texture2D texture;

        public Game1() : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            //
            // This is the main Cocos2D connection. The CCApplication is the manager of the
            // nodes that define your game.
            //
            CCApplication application = new AppDelegate(this, graphics);
            this.Components.Add(application);
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
            spriteBatch = new SpriteBatch(base.GraphicsDevice);

            state = new WorldState();

          /*  List<Goods> goods = new List<Goods>();
            var iron = new Goods();
            iron.name = "ironOre";
            iron.buildEffort = 0;
            iron.cost = new List<System.Tuple<int, int>>();
            iron.size = 100;
            iron.id = 1;

            var basicCircuity = new Goods();
            basicCircuity.name = "basicCircuity";
            basicCircuity.id = 5;
            basicCircuity.buildEffort = 10;

            var cost1 = Tuple.Create(1, 3);
            var cost2 = Tuple.Create(2, 7);
            var costs = new List<System.Tuple<int, int>>();
            costs.Add(cost1);
            costs.Add(cost2);
            basicCircuity.cost = costs;
            basicCircuity.size = 5;

            goods.Add(iron);
            goods.Add(basicCircuity);

            string json = JsonSerializer.Serialize(goods);
            File.WriteAllText(@"G:\Monogame\goods.json", json);*/

            //ballTexture = Content.Load<Texture2D>("ball");
            texture = base.Content.Load<Texture2D>("ball");

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            // For Mobile devices, this logic will close the Game when the Back button is pressed
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                ExitGame();
            }

            var map = state.getMap();
            var val = map.GetValue(10, 10);


            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            base.GraphicsDevice.Clear(Color.CornflowerBlue);
            System.Diagnostics.Debug.WriteLine("changed code");
            spriteBatch.Begin();
            var position = new Vector2(0, 0);
            //spriteBatch.Draw(texture, position);
            spriteBatch.Draw(texture, position, new Rectangle(new Point(50, 50), new Point(200, 200)), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
            spriteBatch.Draw(texture, new Rectangle(50, 50, 300, 300), Color.White);
            //spriteBatch.Draw(texture, new Vector2(0, 0), Color.White);


            //var pixel = new Texture2D(base.GraphicsDevice, 1, 1);
            //pixel.SetData<Color>(new Color[] { Color.White });
            //spriteBatch.Draw(pixel, new Rectangle(0, 0, 500, 200), Color.Red);
            


            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        private void ExitGame()
        {
            // TODO: add your exit code here to restore the device to its per-game environment.
            CCSimpleAudioEngine.SharedEngine.RestoreMediaState();
            Exit();
        }
    }
}
