using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class FreezerRevertStrategy : IRevertStrategy
    {
        public void Revert(PowerBoost power)
        {
            foreach (GameObject obj in power.Targets.EntitiesList)
            {
                obj.Hostility = ObjectType.hostile;
            }
        }
    }
}
