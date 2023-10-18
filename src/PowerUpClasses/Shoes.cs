using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace MyGame
{
    public class Shoes : PowerBoost
    {
        public Shoes(double x, double y, Player p, float duration, string timerName, Entities targets) : base(x, y, p, duration, "speedboost.png", "Shoes", timerName, targets)
        {
            RevertStrategy = new ShoesRevertStrategy();
            TriggerStrategy = new ShoesTriggerStrategy();
        }
    }
}
