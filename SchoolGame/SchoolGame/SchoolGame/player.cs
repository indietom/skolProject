﻿using System;
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
        public bool inputActive;
        public bool keyFalse;

        public player()
        {
            setCoords(400, 240);
            setSize(32, 32);
            setSpriteCoords(1, 1);
            inputActive = true;
            gunType = 1;
            fireRate = 0;
            animationActive = true;
            animationCount = 0;
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
            if (inputActive)
            {
                if (keyboard.IsKeyDown(Keys.X) && gunType == 1 && !keyFalse && fireRate == 0)
                {
                    bullets.Add(new bullet(x + 13, y + 13));
                    fireRate = 1;
                    keyFalse = true;
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
                if (keyboard.IsKeyDown(Keys.Right) && x < 800-37)
                {
                    x += 5;
                }
                if (keyboard.IsKeyDown(Keys.Left) && x > 0)
                {
                    x -= 5;
                }
                if (keyboard.IsKeyDown(Keys.Up) && y > 0)
                {
                    y -= 5;
                }
                if (keyboard.IsKeyDown(Keys.Down) && y < 480-37)
                {
                    y += 5;
                }
            }
        }
    }
}
