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

        public enemyManeger()
        {
            spawnEnemy = 0;
            ifSpawnMech = 0;
        }

        public void spawnEnemies(ref int level, List<mech> mechs, List<enemy> enemies)
        {
            Random random = new Random();
            spawnEnemy += 1;
            if (level == 1)
            {
                if (spawnEnemy == 32*5)
                {
                    enemies.Add(new enemy(random.Next(850, 950), random.Next(0, 480 - 32), random.Next(1,4)));
                }
                if (spawnEnemy == 32 * 5 + 16 && mechs.Count() < 1)
                {
                    ifSpawnMech = random.Next(1, 5);
                    if (ifSpawnMech == 1)
                    {
                        mechs.Add(new mech());
                    }
                }
                if (spawnEnemy == 32 * 5 + 16)
                {
                    spawnEnemy = 0;
                }
            }
            if (level == 2)
            {
                if (spawnEnemy == 32 * 4)
                {
                    enemies.Add(new enemy(random.Next(850, 950), random.Next(0, 480 - 32), random.Next(1, 4)));
                }
                if (spawnEnemy == 32 * 5 && mechs.Count() < 1)
                {
                    ifSpawnMech = random.Next(1, 4);
                    if (ifSpawnMech == 1)
                    {
                        mechs.Add(new mech());
                    }
                    spawnEnemy = 0;
                }
                if (spawnEnemy == 32 * 5 + 16)
                {
                    spawnEnemy = 0;
                }
            }
            if (level == 3)
            {
                if (spawnEnemy == 32 * 2)
                {
                    enemies.Add(new enemy(random.Next(850, 950), random.Next(0, 480 - 32), random.Next(1, 4)));
                }
                if (spawnEnemy == 32 * 3 && mechs.Count() < 1)
                {
                    ifSpawnMech = random.Next(1, 3);
                    if (ifSpawnMech == 1)
                    {
                        mechs.Add(new mech());
                    }
                }
                if (spawnEnemy == 32 * 3 + 16)
                {
                    spawnEnemy = 0;
                }
            }
            if (level == 4)
            {
                if (spawnEnemy == 32)
                {
                    enemies.Add(new enemy(random.Next(850, 950), random.Next(0, 480 - 32), random.Next(1, 4)));
                }
                if (spawnEnemy == 32 * 2 && mechs.Count() < 1)
                {
                    ifSpawnMech = random.Next(1, 3);
                    if (ifSpawnMech == 1)
                    {
                        mechs.Add(new mech());
                    }
                }
                if (spawnEnemy == 32 * 2 + 16)
                {
                    spawnEnemy = 0;
                }
            }
            if (level == 5)
            {
                if (spawnEnemy == 2)
                {
                    enemies.Add(new enemy(random.Next(850, 950), random.Next(0, 480 - 32), random.Next(1, 4)));
                }
                if (spawnEnemy == 2 * 2 && mechs.Count() < 1)
                {
                    mechs.Add(new mech());
                }
                if (spawnEnemy == 2 * 2 + 4)
                {
                    spawnEnemy = 0;
                }
            }
        }
    }
}
