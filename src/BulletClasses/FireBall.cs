using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class FireBall : Bullet
    {

        public FireBall(double x, double y) : base(99999, x, y, "fireball.png", "Fire Ball")
        {
            Speed = 5;
            FlyingDirection = Direction.bullet;
        }
    }
}
