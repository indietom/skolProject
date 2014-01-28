using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolGame
{
    class explosion:objects
    {
        public explosion(float x2, float y2, List<particle> particles)
        {
            setCoords(x2, y2);
            setSpriteCoords(1, 100);
            setSize(32, 32);
            animationCount = 0;
            destroy = false;
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                particles.Add(new particle(x + 16, y + 16, random.Next(360), random.Next(5, 10), 1, "red"));
            }
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
