using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class ShoesTriggerStrategy : ITriggerEffectStrategy
    {
        public void Trigger(PowerBoost power)
        {
            power.PowerBoostTimer.Start();
            if (!power.EffectTimedOut())
            {
                power.p.Speed = 4;
            }
        }
    }
}
