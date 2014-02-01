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
        List<textEffect> textEffects = new List<textEffect>();
        player player = new player();
        healthBar healthBar = new healthBar();
        enemyManeger enemyManeger = new enemyManeger();
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            mechs.Add(new mech());
            base.Initialize();
        }

        Texture2D spritesheet;
        Texture2D space;
        SoundEffect explosionSFX;
        SpriteFont font;
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            spritesheet = Content.Load<Texture2D>("spritesheet");
            space = Content.Load<Texture2D>("space");
            font = Content.Load<SpriteFont>("font");
            explosionSFX = Content.Load<SoundEffect>("explosion");
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
        string gameState = "game";
        int level = 1;
        float time = 0f;
        int highScore = 0;

        public void checkHighscore()
        {
            if (player.score >= highScore)
            {
                highScore = player.score;
            }
        }

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
                case "menu":
                    level = 1;
                    time = 0f;
                    enemyManeger = new enemyManeger();
                    player = new player();
                    healthBar = new healthBar();
                    enemies.Clear();
                    bullets.Clear();
                    enemyBullets.Clear();
                    particles.Clear();
                    mechs.Clear();
                    if (keyboard.IsKeyDown(Keys.Enter))
                    {
                        gameState = "game";
                    }
                    break;
                case "gameover":
                    if (keyboard.IsKeyDown(Keys.X))
                    {
                        gameState = "menu";
                    }
                    break;
                case "game":

                    checkHighscore();

                    time += 0.01f;

                    if (time >= 10f*(float)level && level != 5)
                    {
                        level += 1;
                        time = 0f;
                    }

                    Console.WriteLine(time);

                    Rectangle playerC = new Rectangle((int)player.x + 7, (int)player.y + 9, 8, 9);
                    Rectangle bulletC;
                    Rectangle enemyBulletC;
                    Rectangle enemyC;
                    Rectangle mechC;

                    particles.Add(new particle(player.x + 7, player.y + 13, ranodm.Next(-200, -160), ranodm.Next(5, 10), 1, "red"));

                    enemyManeger.spawnEnemies(ref level, mechs, enemies);

                    if (player.hp <= 0)
                    {
                        gameState = "gameover";
                    }

                    foreach (enemyBullet eb in enemyBullets)
                    {
                        eb.movment(particles);
                        enemyBulletC = new Rectangle();
                        if (eb.type == 1)
                        {
                            enemyBulletC = new Rectangle((int)eb.x, (int)eb.y, 18, 9);
                        }
                        if (eb.type == 2)
                        {
                            enemyBulletC = new Rectangle((int)eb.x, (int)eb.y, 3, 3);
                        }
                        if (collision(ref playerC, ref enemyBulletC) && eb.type == 1)
                        {
                            hitEffects.Add(new hitEffect(player.x, player.y));
                            player.hp -= 3;
                            eb.destroy = true;
                            healthBar.widht -= 30*3;
                        }
                        if (collision(ref playerC, ref enemyBulletC) && eb.type == 2)
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
                        m.checkHealth(explosions, particles, explosionSFX);
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
                            if (collision(ref mechC, ref bulletC) && b.type == 1)
                            {
                                if (m.hp != 1)
                                {
                                    hitEffects.Add(new hitEffect(m.x, m.y));
                                }
                                b.destroy = true;
                                m.hp -= 1;
                            }
                            if (collision(ref mechC, ref bulletC) && b.type == 2)
                            {
                                if (m.hp != 1)
                                {
                                    hitEffects.Add(new hitEffect(m.x, m.y));
                                }
                                b.destroy = true;
                                m.hp -= 3;
                            }
                        }
                    }

                    foreach (particle p in particles)
                    {
                        p.movment();
                    }
                    foreach (textEffect te in textEffects)
                    {
                        te.update();
                    }
                    foreach (enemy e in enemies)
                    {
                        e.movment(enemyBullets);
                        e.checkHealth(explosions, particles, ref player.score, textEffects, explosionSFX);
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
                            if (collision(ref enemyC, ref bulletC) && b.type == 1)
                            {
                                if (e.hp != 1)
                                {
                                    hitEffects.Add(new hitEffect(e.x, e.y));
                                }
                                b.destroy = true;
                                e.hp -= 1;
                            }
                            if (collision(ref enemyC, ref bulletC) && b.type == 2)
                            {
                                if (e.hp != 1)
                                {
                                    hitEffects.Add(new hitEffect(e.x, e.y));
                                }
                                b.destroy = true;
                                e.hp -= 3;
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
            switch(gameState)
            {
                case "menu":
                    spriteBatch.Draw(space, new Vector2(spaceX, 0), Color.White);
                    break;
                case "gameover":
                    spriteBatch.Draw(space, new Vector2(spaceX, 0), Color.White);
                    spriteBatch.DrawString(font, "Game Over", new Vector2(350, 140), Color.Red);
                    spriteBatch.DrawString(font, "Press 'x' to restart", new Vector2(350, 240), Color.White);
                    spriteBatch.DrawString(font, "Score: " + player.score.ToString(), new Vector2(10, 64), Color.White);
                    if (player.score == highScore)
                    {
                        spriteBatch.DrawString(font, "New Highscore!", new Vector2(10, 84), Color.Yellow);
                    }
                    break;
                case "game":
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
                    foreach (textEffect te in textEffects) { te.draw(spriteBatch, font); }
                    spriteBatch.DrawString(font, "Score: " + player.score.ToString(), new Vector2(10, 64), Color.White);
                    spriteBatch.DrawString(font, "Level: " + level.ToString(), new Vector2(10, 124), Color.White);
                    break;
        }
            spriteBatch.DrawString(font, "Highscore: " + highScore.ToString(), new Vector2(650, 64), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
