using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace MyGame
{
    public class GiantEnemy : Enemy
    {
        private FireBall _ball;
        private Entities _ammo; 
        public GiantEnemy(int hp, Player p) : base(hp, new Random().Next(0, 1000), new Random().Next(20, 650), "giant.png", "giant dragon", p)
        {
            Random randName = new Random();
            Speed = (float)0.7;
            //StartFire();
            FireStrategy = new BossEnemyFireStrategy();
        }

        public override void MoveDown()
        {
            if (ModY < 500 && Hostility != ObjectType.frozen)
                ModY += Speed;   
        }

        public override void DisplayObject()
        {
            SplashKit.FillRectangle(Color.Red, ModX + 25, ModY - 15, 60, 10);
            //current HP
            SplashKit.FillRectangle(Color.Gray, ModX + 25, ModY - 15, 60 / BaseHP * HP, 10);
            if (SpawnTimer.Ticks > 3000)
            {
                if (Hostility == ObjectType.neutral)
                    Hostility = ObjectType.hostile;
                Speed = (float)0.5;
                SpawnTimer.Pause();
                base.DisplayObject();
            }
            else
            {
                SplashKit.FillRectangle(Color.Red, ModX, ModY, 40, 40);
            }
        }
        /*
        public override void StartFire(Entities bullet)
        {
            if (FireTimer.Ticks > 3000 && HP > 0)
            {
                FireBall _fire = new(ModX, ModY);
                Point2D targetP = new();
                targetP.X = p.ModX;
                targetP.Y = p.ModY;
                _fire.Target = targetP;
                bullet.AddObject(_fire);
                FireTimer.Reset();
            }
        }
        */

    }
}
