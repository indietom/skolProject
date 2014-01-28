using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace SchoolGame
{
    class player:objects
    {
        public int gunType;
        public int fireRate;
        public int score;
        public bool inputActive;
        public bool keyFalse;
        public bool buttonFalse;

        public player()
        {
            setCoords(400, 240);
            setSize(32, 32);
            setSpriteCoords(1, 1);
            inputActive = true;
            gunType = 1;
            score = 0;
            fireRate = 0;
            animationActive = true;
            animationCount = 0;
            buttonFalse = false;
        }
        public void animation()
        {
            if (animationActive)
            {
                animationCount += 1;
                if (animationCount >= 10)
                {
                    imx = 34;
                }
                if (animationCount >= 20)
                {
                    animationCount = 0;
                }
                if (animationCount == 0)
                {
                    imx = 1;
                }
            }
        }
        public void input(List<bullet> bullets) 
        {
            KeyboardState keyboard = Keyboard.GetState();
            GamePadState gamePad = GamePad.GetState(PlayerIndex.One);
            if (inputActive)
            {
                if (keyboard.IsKeyDown(Keys.X) && gunType == 1 && !keyFalse && fireRate == 0)
                {
                    bullets.Add(new bullet(x + 13, y + 13, 1, 0));
                    fireRate = 1;
                    keyFalse = true;
                }
                if (keyboard.IsKeyDown(Keys.X) && gunType == 4 && !keyFalse && fireRate == 0)
                {
                    bullets.Add(new bullet(x + 13, y + 13, 2, 0));
                    fireRate = 1;
                    keyFalse = true;
                }
                if (gamePad.Buttons.A == ButtonState.Pressed && gunType == 1 && !buttonFalse && fireRate == 0)
                {
                    bullets.Add(new bullet(x + 13, y + 13, 1, 0));
                    fireRate = 1;
                    buttonFalse = true;
                }
                if (gamePad.Buttons.A == ButtonState.Pressed && gunType == 4 && !buttonFalse && fireRate == 0)
                {
                    bullets.Add(new bullet(x + 13, y + 13,2, 0));
                    fireRate = 1;
                    buttonFalse = true;
                }
                if (keyboard.IsKeyDown(Keys.X) && gunType == 2 && !keyFalse && fireRate == 0)
                {
                    bullets.Add(new bullet(x + 13, y + 13, 1, 0));
                    bullets.Add(new bullet(x + 13, y + 13, 1, -25));
                    bullets.Add(new bullet(x + 13, y + 13, 1, 25));
                    fireRate = 1;
                    keyFalse = true;
                }
                if (keyboard.IsKeyDown(Keys.X) && gunType == 3 && fireRate == 0)
                {
                    bullets.Add(new bullet(x + 13, y + 13, 1, 0));
                    fireRate = 20;
                }
                if (gamePad.Buttons.A == ButtonState.Pressed && gunType == 3 && fireRate == 0)
                {
                    bullets.Add(new bullet(x + 13, y + 13, 1, 0));
                    fireRate = 20;
                }
                if (gamePad.Buttons.A == ButtonState.Pressed && gunType == 2 && !buttonFalse && fireRate == 0)
                {
                    bullets.Add(new bullet(x + 13, y + 13, 1, 0));
                    bullets.Add(new bullet(x + 13, y + 13, 1, -25));
                    bullets.Add(new bullet(x + 13, y + 13, 1, 25));
                    fireRate = 1;
                    buttonFalse = true;
                }
                if (fireRate >= 1)
                {
                    fireRate += 1;
                    if (fireRate >= 32)
                    {
                        fireRate = 0;
                    }
                }
                if (keyFalse)
                {
                    if (keyboard.IsKeyUp(Keys.X))
                    {
                        keyFalse = false;
                    }
                }
                if (buttonFalse)
                {
                    if (gamePad.Buttons.A == ButtonState.Released)
                    {
                        buttonFalse = false;
                    }
                }
                if ( x < 800-37 && keyboard.IsKeyDown(Keys.Right) || gamePad.DPad.Right == ButtonState.Pressed && x < 800-37)
                {
                    x += 5;
                }
                if (x > 0 && keyboard.IsKeyDown(Keys.Left) || gamePad.DPad.Left == ButtonState.Pressed && x > 0)
                {
                    x -= 5;
                }
                if (y > 0 && keyboard.IsKeyDown(Keys.Up) || gamePad.DPad.Up == ButtonState.Pressed && y > 0)
                {
                    y -= 5;
                }
                if (y < 480 - 37 && keyboard.IsKeyDown(Keys.Down) || gamePad.DPad.Down == ButtonState.Pressed && y < 480 - 37)
                {
                    y += 5;
                }
            }
        }
    }
}
