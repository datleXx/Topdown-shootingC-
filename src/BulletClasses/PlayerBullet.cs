using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SplashKitSDK;

namespace MyGame
{
    public class PlayerBullet : Bullet
    {
        public PlayerBullet(double x, double y) : base(1, x + 39, y + 26, "rsz_bullet.png", "bullet")
        {
            Speed = 28;
            FlyingDirection = Direction.none;

        }
    }
}
