using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolGame
{
    class particle:objects
    {
        public float accel;
        public int type;
        public particle(float x2, float y2, float angValue, float accel, int type2)
        {
            setCoords(x2, y2);
            setSize(4, 4);
            setSpriteCoords(100, 7);
            type = type2;
        }
        public void movment()
        {
            switch (type)
            {
                case 1:
                    math(3);
                    accel -= 5;
                    break;
            }
        }
    }
}
