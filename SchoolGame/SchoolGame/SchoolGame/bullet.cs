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
    class bullet : objects
    {
        public int type;
        public float accel;

        public bullet(float x2, float y2, int type2, float angle3, SoundEffect shoot_sfx)
        {
            shoot_sfx.Play();
            setCoords(x2, y2);
            angle = angle3;
            accel = 0f;
            type = type2;
            destroy = false;
            switch (type)
            {
                case 1:
                    setSpriteCoords(100, 1);
                    setSize(3, 3);
                    break;
                case 2:
                    accel = -3f;
                    setSpriteCoords(133,1);
                    setSize(18, 9);
                    break;
            }
        }
        public void movment(List<particle> particles)
        {
            Random random = new Random();
            if (x < 0 || x > 800)
            {
                destroy = true;
            }
            switch (type)
            {
                case 1:
                    x += veclocity_x;
                    y += veclocity_y;
                    math(11);
                    break;
                case 2:
                    particles.Add(new particle(x, y, random.Next(-190, -170), random.Next(5, 7), 1, "smoke"));
                    x += veclocity_x;
                    y += veclocity_y;
                    if (accel <= 10f)
                    {
                        accel += 0.1f;
                    }
                    math(accel);
                    break;
            }
        }

    }
}
