using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class NoFireStrategy : IEnemyFireStrategy
    {
        public void Fire(Enemy e, Entities bullet)
        {
           //do nothing   
        }
    }
}
