﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolGame
{
    class bullet : objects
    {
        public int type;
        public bullet(float x2, float y2, int type2, float angle3)
        {
            setCoords(x2, y2);
            angle = angle3;
            type = type2;
            destroy = false;
            switch (type)
            {
                case 1:
                    setSpriteCoords(100, 1);
                    setSize(3, 3);
                    break;
            }
        }
        public void movment()
        {
            switch (type)
            {
                case 1:
                    x += veclocity_x;
                    y += veclocity_y;
                    math(11);
                    break;
            }
        }

    }
}
