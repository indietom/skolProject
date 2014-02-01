using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace SchoolGame
{
    class mech:objects
    {
        public int direction;
        public int fireRate;
        public mech()
        {
            Random random = new Random();
            setCoords(random.Next(850, 900), 200);
            setSize(32, 64);
            setSpriteCoords(1, 166);
            direction = 1;
            fireRate = 0;
            hp = 5;
        }
        public void checkHealth(List<explosion> explosions, List<particle> particles, SoundEffect explosionSFX)
        {
            if (hp <= 0)
            {
                explosions.Add(new explosion(x, y, particles, explosionSFX));
                destroy = true;
            }
        }
        public void movment(List<enemyBullet> enemyBullets)
        {
            Random random = new Random();
            if (x > 700)
            {
                x -= 3;
            }
            else
            {
                fireRate += 1;
                if (fireRate >= 32 * 2)
                {
                    enemyBullets.Add(new enemyBullet(x + 32, y + 32, 1));
                    fireRate = random.Next(20);
                }
                if (direction == 1)
                {
                    y += 2;
                }
                if (direction == 2)
                {
                    y -= 2;
                }
                if (y > 480-64)
                {
                    direction = 2;
                }
                if (y < 0)
                {
                    direction = 1;
                }
            }
        }
    }
}
