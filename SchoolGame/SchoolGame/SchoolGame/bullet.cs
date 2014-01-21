using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolGame
{
    class bullet : objects
    {
        public bullet(float x2, float y2)
        {
            setCoords(x2, y2);
            setSpriteCoords(100, 1);
            setSize(3, 3);
            destroy = false;
        }
        public void movment()
        {
            x += 10;
        }

    }
}
