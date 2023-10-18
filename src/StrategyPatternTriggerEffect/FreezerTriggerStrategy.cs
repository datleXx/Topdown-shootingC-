using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class FreezerTriggerStrategy : ITriggerEffectStrategy
    {
        public void Trigger(PowerBoost power)
        {
            power.PowerBoostTimer.Start();
            if (!power.EffectTimedOut())
            {
                foreach (GameObject obj in power.Targets.EntitiesList)
                {

                    obj.Hostility = ObjectType.frozen;

                }
            }
        }
    }
}
