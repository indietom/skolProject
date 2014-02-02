using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolGame
{
    class powerUpManeger
    {
        public int spawnPowerUps;
        public powerUpManeger()
        {
            spawnPowerUps = 0;
        }
        public void update(List<powerUp> powerUps)
        {
            spawnPowerUps += 1;
            if (spawnPowerUps == 32 * 10)
            {
                powerUps.Add(new powerUp());
                spawnPowerUps = 0;
            }
        }
    }
}
