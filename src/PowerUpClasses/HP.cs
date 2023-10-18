using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace MyGame
{
    public class HP : PowerBoost
    {
        public HP(double x, double y, Player p) : base(x, y, p, 0 , "health.png", "HP Boost", "", null)
        { 
            RevertStrategy = new HPRevertStrategy();
            TriggerStrategy = new HPTriggerStrategy();
        }
    }
}
