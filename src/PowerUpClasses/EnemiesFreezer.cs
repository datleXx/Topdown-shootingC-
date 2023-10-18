using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace MyGame
{
    public class EnemiesFreezer : PowerBoost
    {
        public EnemiesFreezer(double x, double y, Player p, float duration, string timerName, Entities targets) : base(x, y, p, duration, "freeze.png", "freeze", timerName, targets)
        {
            RevertStrategy = new FreezerRevertStrategy();
            TriggerStrategy = new FreezerTriggerStrategy();
        }
    }
}
