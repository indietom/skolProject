using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolGame
{
    class enemyBullet:objects
    {
        public int type;
        float accel;

        public enemyBullet(float x2, float y2, int type2)
        {
            setCoords(x2, y2);
            setSize(3, 3);
            type = type2;
            switch (type)
            {
                case 1:
                    setSpriteCoords(133, 10);
                    setSize(18, 9);
                    accel = -3f;
                    break;
                case 2:
                    setSpriteCoords(100, 4);
                    setSize(3, 3);
                    accel = -3f;
                    break;
            }
        }
        public void movment(List<particle> particles)
        {
            Random random = new Random();
            switch (type)
            {
                case 1:
                    particles.Add(new particle(x, y, random.Next(350, 370), random.Next(5, 7), 1, "smoke"));
                    x -= veclocity_x;
                    y -= veclocity_y;
                    if (accel <= 10f)
                    {
                        accel += 0.1f;
                    }
                    math(accel);
                    break;
                case 2:
                    x -= veclocity_x;
                    y -= veclocity_y;
                    math(11);
                    break;
            } 
        }
    }
}
