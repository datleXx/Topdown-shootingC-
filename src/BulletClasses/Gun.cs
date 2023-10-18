using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace MyGame
{
    public class Gun
    {
        private bool _reloadStatus;
        private int _round;
        private int _capacity;

        public Gun()
        {
            Reloading = false;
            Round = 25;
            _capacity = _round;
        }

        public int RoundCapacity
        {
            get
            {
                return _capacity;
            }
        }

        public bool Reloading
        {
            get
            {
                return _reloadStatus;
            }
            set
            {
                _reloadStatus = value;
            }
        }

        public int Round
        {
            get
            {
                return _round;
            }
            set
            {
                _round = value;
            }
        }

        public void Reload()
        {
            Round = 25;
            _reloadStatus = false;
        }

        public Bullet Shoot(Direction dir, double x, double y, SoundEffect pewFX, Point2D mousePosition)
        {
            if (Round > 0 && _reloadStatus == false)
            {
                Round--;
                SplashKit.PlaySoundEffect(pewFX);
                Bullet bullet = new PlayerBullet(x, y);
                bullet.FlyingDirection = dir;
                bullet.Target = mousePosition;
                Point2D bulletPos = new();
                bulletPos.X = bullet.ModX;
                bulletPos.Y = bullet.ModY;
                bullet.SpritePosition = bulletPos;
                return bullet;
            }
            else
            {
                Bullet bullet = new PlayerBullet(x, y);
                bullet.HP = 0;
                return bullet;
            }
        }
    }
}
