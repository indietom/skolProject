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
        List<particle> particles = new List<particle>();
        List<mech> mechs = new List<mech>();
        List<enemyBullet> enemyBullets = new List<enemyBullet>();
        List<hitEffect> hitEffects = new List<hitEffect>();
        player player = new player();
        healthBar healthBar = new healthBar();
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            mechs.Add(new mech());
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
        public string gameState = "game";
        protected override void Update(GameTime gameTime)
        {
            Random ranodm = new Random();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            KeyboardState keyboard = Keyboard.GetState();

            if (keyboard.IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }

            switch(gameState)
            {
                case "game":
                    Rectangle playerC = new Rectangle((int)player.x + 7, (int)player.y + 9, 8, 9);
                    Rectangle bulletC;
                    Rectangle enemyBulletC;
                    Rectangle enemyC;
                    Rectangle mechC;


                    particles.Add(new particle(player.x + 7, player.y + 13, ranodm.Next(-200, -160), ranodm.Next(5, 10), 1, "red"));

                    foreach (enemyBullet eb in enemyBullets)
                    {
                        eb.movment(particles);
                        enemyBulletC = new Rectangle();
                        if (eb.type == 1)
                        {
                            enemyBulletC = new Rectangle((int)eb.x, (int)eb.y, 18, 9);
                        }
                        if (collision(ref playerC, ref enemyBulletC))
                        {
                            hitEffects.Add(new hitEffect(player.x, player.y));
                            player.hp -= 1;
                            eb.destroy = true;
                            healthBar.widht -= 30;
                        }
                    }

                    foreach (hitEffect he in hitEffects)
                    {
                        he.checkLifeTime();
                    }

                    foreach (mech m in mechs)
                    {
                        m.movment(enemyBullets);
                        m.checkHealth(explosions, particles);
                        mechC = new Rectangle((int)m.x + 13, (int)m.y + 2, 9, 40);
                        if (collision(ref playerC, ref mechC))
                        {
                            hitEffects.Add(new hitEffect(player.x, player.y));
                            player.x -= 64;
                            player.hp -= 1;
                            healthBar.widht -= 30;
                        }
                        foreach (bullet b in bullets)
                        {
                            bulletC = new Rectangle();
                            if (b.type == 1)
                            {
                                bulletC = new Rectangle((int)b.x, (int)b.y, 3, 3);
                            }
                            if (b.type == 2)
                            {
                                bulletC = new Rectangle((int)b.x, (int)b.y, 18, 9);
                            }
                            if (collision(ref mechC, ref bulletC))
                            {
                                if (m.hp != 1)
                                {
                                    hitEffects.Add(new hitEffect(m.x, m.y));
                                }
                                b.destroy = true;
                                m.hp -= 1;
                            }
                        }
                    }

                    foreach (particle p in particles)
                    {
                        p.movment();
                    }
                    foreach (enemy e in enemies)
                    {
                        e.movment(enemyBullets);
                        e.checkHealth(explosions, particles, ref player.score);
                        enemyC = new Rectangle((int)e.x, (int)e.y, 32, 32);
                        if (collision(ref playerC, ref enemyC))
                        {
                            hitEffects.Add(new hitEffect(player.x, player.y));
                            e.destroy = true;
                            player.hp -= 1;
                            healthBar.widht -= 30;
                        }
                        foreach (bullet b in bullets)
                        {
                            bulletC = new Rectangle();
                            if (b.type == 1)
                            {
                                bulletC = new Rectangle((int)b.x, (int)b.y, 3, 3);
                            }
                            if (b.type == 2)
                            {
                                bulletC = new Rectangle((int)b.x, (int)b.y, 18, 9);
                            }
                            if (collision(ref enemyC, ref bulletC))
                            {
                                if (e.hp != 1)
                                {
                                    hitEffects.Add(new hitEffect(e.x, e.y));
                                }
                                b.destroy = true;
                                e.hp -= 1;
                            }
                        }
                    }

                    foreach (bullet b in bullets)
                    {
                        b.movment(particles);
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
                    for (int i = 0; i < enemyBullets.Count; i++)
                    {
                        if (enemyBullets[i].destroy)
                        {
                            enemyBullets.RemoveAt(i);
                        }
                    }
                    for (int i = 0; i < mechs.Count; i++)
                    {
                        if (mechs[i].destroy)
                        {
                            mechs.RemoveAt(i);
                        }
                    }
                    for (int i = 0; i < explosions.Count; i++)
                    {
                        if (explosions[i].destroy)
                        {
                            explosions.RemoveAt(i);
                        }
                    }
                    for (int i = 0; i < bullets.Count; i++)
                    {
                        if (bullets[i].destroy)
                        {
                            bullets.RemoveAt(i);
                        }
                    }
                    for (int i = 0; i < enemies.Count; i++)
                    {
                        if (enemies[i].destroy)
                        {
                            enemies.RemoveAt(i);
                        }
                    }
                    for (int i = 0; i < particles.Count; i++)
                    {
                        if (particles[i].destroy)
                        {
                            particles.RemoveAt(i);
                        }
                    }
                    for (int i = 0; i < hitEffects.Count; i++)
                    {
                        if (hitEffects[i].destroy)
                        {
                            hitEffects.RemoveAt(i);
                        }
                    }
                    break;
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
            foreach (particle p in particles) { p.drawSprite(spriteBatch, spritesheet); }
            player.drawSprite(spriteBatch, spritesheet);
            foreach (mech m in mechs) { m.drawSprite(spriteBatch, spritesheet); }
            foreach (bullet b in bullets) { b.drawSprite(spriteBatch, spritesheet); }
            foreach (enemyBullet eb in enemyBullets) { eb.drawSprite(spriteBatch, spritesheet); }
            foreach (enemy e in enemies) { e.drawSprite(spriteBatch, spritesheet); }
            foreach (hitEffect he in hitEffects) { he.drawSprite(spriteBatch, spritesheet); }
            foreach (explosion ex in explosions) { ex.drawSprite(spriteBatch, spritesheet); }
            healthBar.drawSprite(spriteBatch, spritesheet);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
