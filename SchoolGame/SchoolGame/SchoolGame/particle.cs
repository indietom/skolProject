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
        public string color;
        public particle(float x2, float y2, float angValue, float accel2, int type2, string color2)
        {
            setCoords(x2, y2);
            setSize(4, 4);
            type = type2;
            accel = accel2;
            angle = angValue;
            color = color2;
            switch (color)
            {
                case "red":
                    setSpriteCoords(100, 7);
                    break;
                case "smoke":
                    setSize(8, 8);
                    setSpriteCoords(100, 11);
                    break;
            }
        }
        public void movment()
        {
            if (x < 0 || x > 800 || y < 0 || y > 480)
            {
                destroy = true;
            }
            switch (type)
            {
                case 1:
                    math(7);
                    x += veclocity_x;
                    y += veclocity_y;
                    break;
            }
        }
    }
}
