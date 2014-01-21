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
    class objects
    {
        public bool destroy;

        public float x;
        public float y;
        public int imx;
        public int imy;
        public int widht;
        public int height;
        public int hp;

        public int animationCount;

        public bool animationActive;
        public float angle2;
        public float angle;
        public float speed;
        public float scale_x;
        public float scale_y;
        public float veclocity_x;
        public float veclocity_y;

        public void setCoords(float x2, float y2)
        {
            x = x2;
            y = y2;
        }
        public void setSpriteCoords(int imx2, int imy2)
        {
            imx = imx2;
            imy = imy2;
        }
        public void setSize(int w2, int h2)
        {
            widht = w2;
            height = h2;
        }
        public void drawSprite(SpriteBatch spriteBatch, Texture2D spritesheet)
        {
            spriteBatch.Draw(spritesheet, new Vector2(x, y), new Rectangle(imx, imy, widht, height), Color.White);
        }
        public void math(int speed2)
        {
            angle2 = (angle * (float)Math.PI / 180);
            speed = speed2;
            veclocity_x = (speed * (float)Math.Cos(angle));
            veclocity_y = (speed * (float)Math.Sin(angle));
        }
    }
}
