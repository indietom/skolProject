using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolGame
{
    class explosion:objects
    {
        public void animation()
        {
            animationCount += 1;
            if (animationCount == 10)
            {
                imx += 33;
                animationCount = 0;
            }
        }
    }
}
