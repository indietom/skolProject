using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolGame
{
    class enemy:objects
    {
        public int type;
        public int fireRate;

        public enemy(float x2, float y2, int type2)
        {
            Random random = new Random();
            setSize(32, 32);
            type = type2;
            setCoords(x2, y2);
            switch (type)
            {
                case 1:
                    hp = 1;
                    setSpriteCoords(1, 67);
                    angle = random.Next(-200, -160);
                    break;
                case 2:
                    hp = 1;
                    setSpriteCoords(1, 67);
                    angle = -90;
                    break;
            }
        }
        public void checkHealth(List<explosion> explosions)
        {
            if (hp <= 0)
            {
                explosions.Add(new explosion(x - 16, y - 16));
            }
        }
        public void movment()
        {
            if (angle >= 360 || angle <= -360)
            {
                angle = 0;
            }
            switch (type)
            {
                case 1: 
                    x += veclocity_x;
                    y += veclocity_y;
                    math(8);
                    break;
                case 2:
                    angle -= 5;
                    x += veclocity_x;
                    y += veclocity_y;
                    math(8);
                    break;
            }
        }
    }
}
