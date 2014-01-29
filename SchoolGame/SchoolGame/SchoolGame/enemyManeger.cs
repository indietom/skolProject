using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolGame
{
    class enemyManeger:objects
    {
        public int spawnEnemy;
        public void spawnEnemies(ref int level, List<mech> mechs)
        {
            spawnEnemy += 1;
            if (level == 1)
            {
                if (spawnEnemy == 32 * 10)
                {

                }
                if (spawnEnemy == 32 * 15 && mechs.Count() > 1)
                {
                    mechs.Add(new mech());
                }
                
            }
        }
    }
}
