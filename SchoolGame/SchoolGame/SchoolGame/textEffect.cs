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
    class textEffect:objects
    {
        string text;
        int type;
        public textEffect(float x2, float y2, int type2, string text2)
        {
            type = type2;
            text = text2;
            setCoords(x2, y2);
        }
        public void draw(SpriteBatch spritebatch, SpriteFont font)
        {
            spritebatch.DrawString(font, text, new Vector2(x, y), Color.White);
        }
        public void update()
        {
            switch (type)
            {
                case 1:
                    x += 3;
                    y -= 2;
                    break;
            }
        }
    }
}
