using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace MyGame
{
    public class CovidEnemy : Enemy
    {
        public CovidEnemy(int hp, double x, double y, Player p) : base(hp, x, y, "covid_zombie.png", "covid zombie", p)
        {
            Speed = (float)0.7;
        }
        public override void DisplayObject()
        {
            SplashKit.FillRectangle(Color.Red, ModX + 25, ModY - 15, 30, 5);
            //current HP
            SplashKit.FillRectangle(Color.Blue, ModX + 25, ModY - 15, 30 / BaseHP * HP, 5);
            if (SpawnTimer.Ticks > 3000)
            {
                if (Hostility == ObjectType.neutral)
                    Hostility = ObjectType.hostile;
                SpawnTimer.Pause();
                base.DisplayObject();
            }
            else
            {
                SplashKit.FillRectangle(Color.BlueViolet, ModX, ModY, 40, 40);
            }
        }
    }
}
