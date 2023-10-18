using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace MyGame
{
    public class Enemy : MovableObject
    {
        private SplashKitSDK.Timer _fireTimer;
        private Player _p;
        private Blood _blood;
        public IEnemyFireStrategy _fireStrategy; 
        public Enemy(int hp, double x, double y, string filepath, string zombie_name, Player p) : base(hp, 0, 0, filepath, zombie_name)
        {
            Random _random = new Random();
            int i = _random.Next();
            _fireTimer = new SplashKitSDK.Timer(_random.Next().ToString());   
            ModX = x;
            ModY = y;
            SpawnTimer.Start();
            FireTimer.Start();
            _p = p;
            FireStrategy = new NoFireStrategy();
        }

        public Player p
        {
            get
            {
                return _p;
            }
        }
        public IEnemyFireStrategy FireStrategy
        {
            get
            {
                return _fireStrategy;
            }
            set
            {
                _fireStrategy = value; 
            }
        }
        public SplashKitSDK.Timer FireTimer
        {
            get { return _fireTimer; }
        }
        public Blood BloodyEffect
        {
            get
            {
                return _blood;
            }
            set
            {
                _blood = value;
            }
        }
        public virtual void Rotate()
        {
            double angle = Math.Atan2(p.ModY - ModY, p.ModX - ModX);
            Sprite.Rotation = (float)(angle * (180.0 / 3.14));
        }
        public virtual void SpecialMove()
        {
            if (ModX < p.ModX)
            {
                MoveRight();
            }
            if (ModX > p.ModX)
            {
                MoveLeft();
            }
            if (ModY < p.ModY)
            {
                MoveDown();
            }
            if (ModY > p.ModY)
            {
                MoveUp();
            }
        }
        public void DetectBullets(Entities bulletEntities)
        {
            if (Hostility != ObjectType.neutral)
            {
                foreach (Bullet bullet in bulletEntities.EntitiesList)
                {
                    if (bullet.GetType() == typeof(FireBall))
                    {
                        continue;
                    }
                    else
                    {
                        bool collisionX = Sprite.Width / 2 + ModX >= bullet.ModX && bullet.ModX + bullet.Sprite.Width / 2 >= ModX;
                        bool collisionY = Sprite.Height / 2 + ModY >= bullet.ModY && bullet.ModY + bullet.Sprite.Height / 2 >= ModY;
                        bool condition = collisionX && collisionY;

                        //hitbox scan in case the bullet is shooting vertically
                        if (bullet.FlyingDirection == Direction.bullet)
                        {
                            //i suck
                            if (condition)
                            {
                                TakeDamage(bullet.HP);
                                bullet.TakeDamage(bullet.HP);
                            }
                        }
                    }

                }
            }
        }
        public void AddBlood(Entities bloodEntities)
        {
            if (HP <= 0)
            {
                BloodyEffect = new(ModX, ModY);
                bloodEntities.AddObject(BloodyEffect);
            }
        }
        public virtual void StartFire(Entities bullet)
        {
            //only fire if the enemy is the Giant type 
            FireStrategy.Fire(this, bullet);
        }
    }
}
