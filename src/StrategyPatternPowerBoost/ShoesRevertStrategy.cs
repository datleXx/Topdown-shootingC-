using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class ShoesRevertStrategy : IRevertStrategy
    {
        public void Revert(PowerBoost power)
        {
            power.p.Speed = 2;
        }
    }
}
