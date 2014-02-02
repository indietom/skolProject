using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolGame
{
    class powerUp:objects
    {
        public int type;
        public int subType;

        public void movment()
        {
            x -= 3;
            if (x < 0)
            {
                destroy = true;
            }
        }

        public powerUp()
        {
            Random random = new Random();
            setCoords(random.Next(850, 950), random.Next(32, 480-32));
            setSize(16, 16);
            type = random.Next(1, 4);
            destroy = false;
            switch (type)
            {
                case 1:
                    setSpriteCoords(34, 34);
                    break;
                case 2:
                    setSpriteCoords(50,34);
                    subType = random.Next(1, 4);
                    break;
                case 3:
                    setSpriteCoords(34, 50);
                    break;
                case 4:
                    setSpriteCoords(50, 50);
                    break;
            }
        }
    }
}
