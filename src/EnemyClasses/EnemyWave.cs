using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace MyGame
{
    public class EnemyWave
    {
        private EnemyWaveFactory _factory;
        private List<Enemy> _enemies;
        private int _enemyCount = 1;
        private int _diff; 
        public EnemyWave(int difficulty, Player p)
        {
            EnemyList = new List<Enemy>();
            _diff = difficulty;
            switch (_diff)
            {
                case 1: 
                    Factory = new EasyEnemyWaveFactory(); 
                    break;
                case 2:
                    Factory = new MediumEnemyWaveFactory();
                    break;
                case 3:
                    Factory = new HardEnemyWaveFactory();
                    break;
                default:
                    Factory = new EasyEnemyWaveFactory();
                    break;

            }
            NewWave(p);
        }
        public int Count
        {
            get
            {
                return _enemyCount;
            }
            set
            {
                _enemyCount = value;
            }
        }

        public List<Enemy> EnemyList
        {
            get
            {
                return _enemies;
            }
            set
            {
                _enemies = value;
            }
        }
        public EnemyWaveFactory Factory
        {
            get { return _factory; }
            set { _factory = value; }
        }

        public void NewWave(Player p)
        {
            EnemyList.Clear();
            Count += _diff;
            int i = Count; 
            for (int j = i; j > 0; j--)
            {
                EnemyList.Add(Factory.CreateEnemies(p));
            }
        }
    }
}
