using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class EasyEnemyWaveFactory : EnemyWaveFactory
    {
        private Random _seed = new Random();
        private int _index = 0; 
        public override Enemy CreateEnemies(Player p)
        {
            if ( _index <= 6)
            {
                _index++;
                return new NormalEnemy(5, _seed.Next(10, 951), _seed.Next(160, 551), p);
            }
            else
            {

                if (_index % 2 == 1)
                {
                    _index++;
                    return new NormalEnemy(5, _seed.Next(10, 951), _seed.Next(160, 551), p);
                }
                else
                {
                    _index ++;
                    return new CovidEnemy(15, _seed.Next(10, 951), _seed.Next(160, 551), p);
                }
            }
        }
    }
}
