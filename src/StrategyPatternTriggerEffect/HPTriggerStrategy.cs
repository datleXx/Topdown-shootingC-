using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class HPTriggerStrategy : ITriggerEffectStrategy
    {
        public void Trigger(PowerBoost power)
        {
            power.p.HP += 5;
        }
    }
}
