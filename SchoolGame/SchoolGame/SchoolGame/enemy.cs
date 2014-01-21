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
            switch (type2)
            {
                case 1:
                    setSpriteCoords(1, 67);
                    angle = random.Next(-200, -160);
                    break;
            }
        }
        public void movment()
        {
            switch (type)
            {
                case 1: 
                    x += veclocity_x;
                    y += veclocity_y;
                    break;
            }
            math(8);
        }
    }
}
