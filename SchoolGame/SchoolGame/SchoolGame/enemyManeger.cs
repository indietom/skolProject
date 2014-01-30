using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolGame
{
    class enemyManeger:objects
    {
        public int spawnEnemy;
        public int ifSpawnMech;
        public void spawnEnemies(ref int level, List<mech> mechs, List<enemy> enemies)
        {
            Random random = new Random();
            spawnEnemy += 1;
            if (level == 1)
            {
                if (spawnEnemy == 32 * 10)
                {
                    enemies.Add(new enemy(random.Next(850, 950), random.Next(0, 480 - 32), random.Next(1,3)));
                }
                if (spawnEnemy == 32 * 15 && mechs.Count() > 1)
                {
                    ifSpawnMech = random.Next(1, 5);
                    if (ifSpawnMech == 1)
                    {
                        mechs.Add(new mech());
                    }
                }
            }
            if (level == 2)
            {
                if (spawnEnemy == 32 * 7)
                {
                    enemies.Add(new enemy(random.Next(850, 950), random.Next(0, 480 - 32), random.Next(1, 3)));
                }
                if (spawnEnemy == 32 * 15 && mechs.Count() > 1)
                {
                    ifSpawnMech = random.Next(1, 4);
                    if (ifSpawnMech == 1)
                    {
                        mechs.Add(new mech());
                    }
                }
            }
            if (level == 3)
            {
                if (spawnEnemy == 32 * 5)
                {
                    enemies.Add(new enemy(random.Next(850, 950), random.Next(0, 480 - 32), random.Next(1, 3)));
                }
                if (spawnEnemy == 32 * 15 && mechs.Count() > 1)
                {
                    ifSpawnMech = random.Next(1, 3);
                    if (ifSpawnMech == 1)
                    {
                        mechs.Add(new mech());
                    }
                }
            }
        }
    }
}
