using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolGame
{
    class enemyBullet:objects
    {
        public int type;

        public enemyBullet(float x2, float y2, int type2)
        {
            setCoords(x2, y2);
            setSize(3, 3);
            type = type2;
            switch (type)
            {
                case 1:
                    setSpriteCoords(3, 3);
                    break;
            }
        }
        public void movment()
        {
            
        }
    }
}
