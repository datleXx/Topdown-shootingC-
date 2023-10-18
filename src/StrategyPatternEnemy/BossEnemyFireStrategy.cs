using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class BossEnemyFireStrategy : IEnemyFireStrategy
    {
        public void Fire(Enemy e, Entities bulletEntities)
        {
            if (e.FireTimer.Ticks > 3000 && e.HP > 0)
            {
                FireBall _fire = new(e.ModX, e.ModY);
                Point2D targetP = new Point2D();
                targetP.X = e.p.ModX;
                targetP.Y = e.p.ModY;
                _fire.Target = targetP;
                bulletEntities.AddObject(_fire);
                e.FireTimer.Reset();
            }
        }
    }
}
