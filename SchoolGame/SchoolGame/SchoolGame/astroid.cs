using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolGame
{
    class astroid:objects
    {
        public int size;
        public astroid(float x2, float y2, int size2, float angle3)
        {
            setCoords(x2, y2);
            angle = angle3;
            size = size2;
            switch (size2)
            {
                case 32:
                    setSpriteCoords(1, 133);
                    setSize(27, 26);
                    break;
                case 16:
                    setSpriteCoords(34, 133);
                    setSize(14, 13);
                    break;
                case 8:
                    setSpriteCoords(67, 133);
                    setSize(6, 7);
                    break;
            }
        }
        public void checkHealth(List<astroid> astroids, List<explosion> explosions)
        {
            if (hp <= 0 && size == 32)
            {
                astroids.Add(new astroid(x,y, 16, -140));
                astroids.Add(new astroid(x, y, 16, -220));
                destroy = true;
            }
            if (hp <= 0 && size == 16)
            {
                astroids.Add(new astroid(x, y, 8, -140));
                astroids.Add(new astroid(x, y, 8, -220));
                destroy = true;
            }
            if (hp <= 0 && size == 8)
            {
                explosions.Add(new explosion(x - 16, y - 16));
                destroy = true;
            }
        }
    }
}
