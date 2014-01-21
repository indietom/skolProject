using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolGame
{
    class explosion:objects
    {
        public explosion(float x2, float y2)
        {
            setCoords(x2, y2);
            setSpriteCoords(1, 100);
            setSize(32, 32);
            animationCount = 0;
            destroy = false;
        }
        public void animation()
        {
            animationCount += 1;
            if (animationCount == 7)
            {
                imx += 33;
                animationCount = 0;
            }
            if (imx >= 166)
            {
                destroy = true;
            }
        }
    }
}
