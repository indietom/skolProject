using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolGame
{
    class mech:objects
    {
        public int direction;

        public mech()
        {
            setCoords(750, 200);
            setSize(32, 64);
            setSpriteCoords(1, 166);
            direction = 1;
        }

        public void movment()
        {
            if (x > 700)
            {
                x -= 3;
            }
            else
            {
                if (direction == 1)
                {
                    y += 2;
                }
                if (direction == 2)
                {
                    y -= 2;
                }
                if (y > 480-64)
                {
                    direction = 2;
                }
                if (y < 0)
                {
                    direction = 1;
                }
            }
        }
    }
}
