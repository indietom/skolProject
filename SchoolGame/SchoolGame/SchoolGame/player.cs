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
        public bool inputActive;

        public player()
        {

        }

        public void input()
        {
            KeyboardState keyboard = Keyboard.GetState();
            if (inputActive)
            {
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
                if (keyboard.IsKeyDown(Keys.Down) && y < 800-37)
                {
                    y += 5;
                }
            }
        }
    }
}
