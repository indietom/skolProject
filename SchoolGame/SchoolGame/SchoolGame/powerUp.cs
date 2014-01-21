using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolGame
{
    class powerUp:objects
    {
        public int type;

        public void movment()
        {
            x -= 3;
        }

        public powerUp()
        {
            Random random = new Random();
            setCoords(random.Next(32, 800), random.Next(32, 480));
            setSize(16, 16);
            type = random.Next(1, 5);
            switch (type)
            {
                case 1:
                    setSpriteCoords(34, 34);
                    break;
                case 2:
                    setSpriteCoords(50,34);
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
