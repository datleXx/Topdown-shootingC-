using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace MyGame
{
    public class PowerBoostSpawner
    {
        private List<PowerBoost> _PowerBoosts;
        private SplashKitSDK.Timer _spawnTimer = new SplashKitSDK.Timer("Spawn PU Timer");
        private Player _p;
        private Entities _targets;
        private Random _seed;
        private int TimerIndex;

        public PowerBoostSpawner(Player p, Entities target)
        {
            _p = p;
            _targets = target;
            _PowerBoosts = new List<PowerBoost>();
            _seed = new Random();
            TimerIndex = 0;
            //Console.WriteLine(_spawnTimer.Ticks);
            SplashKit.StartTimer("Spawn PU Timer");
        }

        public List<PowerBoost> PowerBoostsList
        {
            get
            {
                return _PowerBoosts;
            }
        }

        public void SpawnPowerBoosts(Entities entities)
        {
            //Console.WriteLine(SplashKit.TimerTicks("Spawn PU Timer").ToString() + "    " + PowerBoostsList.Count.ToString());

            if (SplashKit.TimerTicks("Spawn PU Timer") > 7500 && PowerBoostsList.Count <= 5)
            {

                int x, y;
                PowerBoost pwr;
                x = _seed.Next(10, 951);
                y = _seed.Next(200, 551);

                if (x % 3 == 1)
                    pwr = new EnemiesFreezer(x, y, _p, 2, TimerIndex.ToString(), _targets);
                else if (x % 3 == 2)
                    pwr = new Shoes(x, y, _p, 4, TimerIndex.ToString(), _targets);
                else
                    pwr = new HP(x, y, _p);
                TimerIndex++;
                _PowerBoosts.Add(pwr);
                entities.AddObject(pwr);
                SplashKit.ResetTimer("Spawn PU Timer");
            }

            foreach (PowerBoost pwr in PowerBoostsList.ToList())
            {
                if (pwr.EffectTimedOut())
                {
                    _PowerBoosts.Remove(pwr);
                    _targets.EntitiesList.Remove(pwr);

                }
            }
            //SplashKit.ResetTimer("EffectTimer PU");
        }
    }
}
