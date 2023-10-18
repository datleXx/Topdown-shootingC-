using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MyGame;
using SplashKitSDK;

namespace MyGame
{
    public class Bullet : MovableObject
    {
        private Direction _dir;
        private Point2D _targetPoint;
        private Point2D _spritePos;

        //plus 18 to the cords so that the bullet will be at the middle of the player. base speed is 30 for best collision test and visibility
        public Bullet(int hp, double x, double y, string file, string name) : base(hp, x + 18, y + 18, file, name)
        {
            Speed = 28;
            FlyingDirection = Direction.none;
            _spritePos.X = ModX;
            _spritePos.Y = ModY;
        }

        public Point2D SpritePosition
        {
            get
            {
                return _spritePos;
            }
            set
            {
                _spritePos = value;
            }
        }
        public Point2D Target
        {
            get
            {
                return _targetPoint;
            }
            set
            {
                _targetPoint = value;
            }
        }
        public Direction FlyingDirection
        {
            get
            {
                return _dir;
            }
            set
            {
                _dir = value;
            }
        }

        public void Fly()
        {
            if (FlyingDirection == Direction.bullet)
            {
                //because bullets is located at the middle of player so we have to minus 18 unit in each cordinate
                double angle = SplashKit.PointPointAngle(Target, SpritePosition);

                angle = angle * Math.PI / 180.0;
                Move(angle);
            }
        }

        public void Move(double angle)
        {
            if (ModX >= 0 && ModX <= 1000 && ModY >= 0 && ModY <= 910)
            {
                ModX -= Speed * Math.Cos(angle);
                ModY -= Speed * Math.Sin(angle);
            }
            else
            {
                TakeDamage(HP);
            }

        }

        //overriding the movement since the bullet take different shape for moving up/down and left/right
        //bullets will go into neutral state if it hits a wall, and situated next to the wall (so that it doesn't look like it goes through the wall)
        //bullets that are neutral will disappear in the next frame (this handler is in gamemain)
    }
}
