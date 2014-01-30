using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolGame
{
    class hitEffect:objects
    {
        public int lifeTime;
        public hitEffect(float x2, float y2)
        {
            setCoords(x2, y2);
            setSize(32, 32);
            setSpriteCoords(1, 331);
            lifeTime = 0;
            destroy = false;
        }
        public void checkLifeTime()
        {
            lifeTime += 1;
            if (lifeTime >= 4)
            {
                destroy = true;
            }
        }
    }
}
