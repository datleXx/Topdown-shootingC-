using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyGame
{
    public class MediumEnemyWaveFactory : EnemyWaveFactory
    {
        private Random _seed = new Random();
        private int _index = 0;
        public override Enemy CreateEnemies(Player p)
        {
            if (_index <= 3)
            {
                _index ++;
                return new NormalEnemy(5, _seed.Next(10, 951), _seed.Next(160, 551), p);           
            }
            else
            {
                Random rand = new Random();

                int indexRand = rand.Next(0, 3);
                switch (indexRand)
                {
                    case 0:
                        return new NormalEnemy(5, _seed.Next(10, 951), _seed.Next(160, 551), p);
                    case 1:
                        return new CovidEnemy(15, _seed.Next(10, 951), _seed.Next(160, 551), p);
                    case 2:
                        return new TeleportableEnemy(10, _seed.Next(10, 951), _seed.Next(160, 551), rand.Next(4, 10), p);
                    default:
                        return new NormalEnemy(5, _seed.Next(10, 951), _seed.Next(160, 551), p);
                }
            }
        }
    }
}
