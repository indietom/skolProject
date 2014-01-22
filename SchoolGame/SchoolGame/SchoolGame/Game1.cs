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

namespace SchoolGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        List<bullet> bullets = new List<bullet>();
        List<explosion> explosions = new List<explosion>();
        List<enemy> enemies = new List<enemy>();
        player player = new player();
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            enemies.Add(new enemy(700, 200, 2));
            base.Initialize();
        }

        Texture2D spritesheet;
        Texture2D space;
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            spritesheet = Content.Load<Texture2D>("spritesheet");
            space = Content.Load<Texture2D>("space");
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
        public bool collision(ref Rectangle object1, ref Rectangle object2)
        {
            if (object1.Y >= object2.Y + object2.Height)
                return false;
            if (object1.X >= object2.X + object2.Width)
                return false;
            if (object1.Y + object1.Height <= object2.Y)
                return false;
            if (object1.X + object1.Width <= object2.X)
                return false;
            return true;
        }
        int spaceX = 0;
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            KeyboardState keyboard = Keyboard.GetState();

            if (keyboard.IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }

            foreach (enemy e in enemies)
            {
                e.movment();
                e.checkHealth(explosions);
            }

            foreach (bullet b in bullets)
            {
                b.movment();
            }
            foreach (explosion ex in explosions)
            {
                ex.animation();
            }

            player.input(bullets);
            player.animation();

            spaceX -= 1;

            if (spaceX == -800)
            {
                spaceX = 0;
            }
            for (int i = 0; i < bullets.Count; i++)
            {
                if (bullets[i].destroy)
                {
                    bullets.RemoveAt(i);
                }
            }
            for (int i = 0; i < explosions.Count; i++)
            {
                if (explosions[i].destroy)
                {
                    explosions.RemoveAt(i);
                }
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(space, new Vector2(spaceX, 0), Color.White);
            player.drawSprite(spriteBatch, spritesheet);
            foreach (bullet b in bullets) { b.drawSprite(spriteBatch, spritesheet); }
            foreach (enemy e in enemies) { e.drawSprite(spriteBatch, spritesheet); }
            foreach (explosion ex in explosions) { ex.drawSprite(spriteBatch, spritesheet); }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
