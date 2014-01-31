using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolGame
{
    class enemy:objects
    {
        public int type;
        public int fireRate;

        public enemy(float x2, float y2, int type2)
        {
            Random random = new Random();
            setSize(32, 32);
            type = type2;
            setCoords(x2, y2);
            destroy = false;
            fireRate = 0;
            switch (type)
            {
                case 1:
                    hp = 1;
                    setSpriteCoords(1, 67);
                    angle = random.Next(-200, -160);
                    break;
                case 2:
                    hp = 1;
                    setSpriteCoords(1, 67);
                    angle = -90;
                    break;
                case 3:
                    Console.WriteLine("lol yolo");
                    angle = -180;
                    hp = 2;
                    setSpriteCoords(1, 67);
                    break;
            }
        }
        public void checkHealth(List<explosion> explosions, List<particle> particles, ref int score, List<textEffect> textEffects)
        {
            if (hp <= 0)
            {
                switch (type)
                {
                    case 1:
                        textEffects.Add(new textEffect(x, y, 1, "+1000"));
                        score += 1000;
                        break;
                    case 2:
                        textEffects.Add(new textEffect(x, y, 1, "+2000"));
                        score += 2000;
                        break;
                    case 3:
                        textEffects.Add(new textEffect(x, y, 1, "+3000"));
                        score += 3000;
                        break;
                }
                explosions.Add(new explosion(x, y, particles));
                destroy = true;
            }
        }
        public void movment(List<enemyBullet> enemyBullets)
        {
            if (angle >= 360 || angle <= -360)
            {
                angle = 0;
            }
            switch (type)
            {
                case 1: 
                    x += veclocity_x;
                    y += veclocity_y;
                    math(2);
                    break;
                case 2:
                    x -= 1;
                    angle -= 10;
                    x += veclocity_x;
                    y += veclocity_y;
                    math(8);
                    break;
                case 3:
                    fireRate += 1;
                    if (fireRate == 32*2+16)
                    {
                        enemyBullets.Add(new enemyBullet(x + 16, y + 16, 2));
                        fireRate = 0;
                    }
                    x += veclocity_x;
                    y += veclocity_y;
                    math(1);
                    break;
            }
        }
    }
}
