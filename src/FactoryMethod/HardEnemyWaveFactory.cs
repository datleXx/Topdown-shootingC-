using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class HardEnemyWaveFactory : EnemyWaveFactory
    {
        private Random _seed = new Random();
        private int _index = 0;
        public HardEnemyWaveFactory()
        {
            
        }

        public override Enemy CreateEnemies(Player p)
        {
            int index = _index % 5;

            if (index == 0)
            {
                _index++;
                return new GiantEnemy(30, p);
            }
            else if (index <=3 && index > 0)
            {
                _index++;
                return new NormalEnemy(5, _seed.Next(10, 951), _seed.Next(160, 551), p);
            }
            else if (index == 3)
            {
                _index++;
                return new TeleportableEnemy(10, _seed.Next(10, 951), _seed.Next(160, 551), _seed.Next(4, 10), p);
            }
            else 
            {
                _index++;
                return new CovidEnemy(15, _seed.Next(10, 951), _seed.Next(160, 551), p);
            }
        }
    }
}
