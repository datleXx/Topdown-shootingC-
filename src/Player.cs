using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace MyGame
{
    public class Player : MovableObject
    {
        private bool _charged;
        private bool _charging;
        private Gun _gun;
        private int _killCount;
        SplashKitSDK.Timer _skillRechargeTimer;
        SplashKitSDK.Timer _regenTimer; 
        private Entities _bulletGroup = new Entities();

       

        public Player() : base(999 , 480, 300, "rsz_hero.png", "hero")
        {
            Weapon = new Gun();
            Speed = 2;
            _regenTimer = new SplashKitSDK.Timer("Regen Timer");
            _skillRechargeTimer = new SplashKitSDK.Timer("Skill Recharge Timer");
            _regenTimer.Start();
            SkillCharged = true;
            SkillState = false;
            Kill = 0;
        }
        public Entities BulletGroup
        {
            get
            {
                return _bulletGroup;
            }
        }
        public Gun Weapon
        {
            get
            {
                return _gun;
            }
            set
            {
                _gun = value;
            }
        }

        public bool SkillCharged
        {
            get
            {
                return _charged;
            }
            set
            {
                _charged = value;
            }
        }

        public bool SkillState
        {
            get
            {
                return _charging;
            }
            set
            {
                _charging = value;
            }
        }

        public int Kill
        {
            get
            {
                return _killCount;
            }
            set
            {
                _killCount = value;
            }
        }


        public void DisplayPlayerDetails(Font optimusFont)
        {
            //HP gauge
            SplashKit.FillRectangle(Color.Red, ModX + 25, ModY - 15, 25, 5);
            //current HP
            SplashKit.FillRectangle(Color.Green, ModX + 25, ModY - 15, (float)(25 / BaseHP) * HP, 5);
            //kill counter
            SplashKit.DrawText("Kills: " + _killCount.ToString(), Color.Black, "optimusFont",15, 925, 20);
            //ammo
            if(Weapon.Reloading == false)
                SplashKit.DrawText("Ammo: " + Weapon.Round.ToString() + "/" + Weapon.RoundCapacity.ToString(), Color.Black, "optimusFont", 15, 15, 20);
            else
                SplashKit.DrawText("Reloading", Color.Black, "optimusFont", 15, 15, 20);
            //skill cooldown
            if (!SkillCharged)
                SplashKit.DrawText("Skill: " + ((1500 - _skillRechargeTimer.Ticks) / 100).ToString(), Color.Black, "optimusFont", 15, 450, 20);
            if (SkillCharged == false && SkillState == false)
            {
                SkillState = true;
                _skillRechargeTimer.Start();
            }
            if (_skillRechargeTimer.Ticks >= 1500 && SkillCharged == false && SkillState == true)
            {
                _skillRechargeTimer.Stop();
                RechargeSkill();
                SkillState = false;
                _skillRechargeTimer.Start();
            }
            if(SkillCharged)
                SplashKit.DrawText("Skill: READY", Color.Black, "optimusFont", 15, 450, 20);
        }

        public void Regenerate()
        {
            //player HP regen (every 5 sec restores 1HP out of 20HP)
            if (_regenTimer.Ticks >= 5000 && HP > 0)
            {
                if (HP < BaseHP)
                    HP++;
                _regenTimer.Stop();
                _regenTimer.Start();
            }
        }

        public void RechargeSkill()
        {
            SkillCharged = true;
        }
        public void Rotate(double mouseX, double mouseY)
        {
            double angle = Math.Atan2(mouseY - ModY, mouseX - ModX);
            Sprite.Rotation = (float)(angle * (180.0 / 3.14));
        }
        public override void DisplayObject()
        {
            //base.DisplayObject();
            SplashKit.DrawSprite(Sprite, ModX, ModY);
            
            //SplashKit.DrawBitmap(hero, ModX, ModY);
            //displaying the range of the teleportation skill
            if(SkillCharged)
                SplashKit.DrawCircle(Color.Green, ModX + Sprite.Width/2, ModY + Sprite.Height/2, 70);
            else
                SplashKit.DrawCircle(Color.DarkOrange, ModX + Sprite.Width/2, ModY + Sprite.Height/2, 70);
        }
        
        public void Teleport(Direction direction)
        {
            if (SkillCharged == true)
            {
                SkillCharged = false;
                switch (direction)
                {
                    case Direction.up:
                        if (ModY < 250)
                            ModY = 50;
                        else
                            ModY -= 200;
                        break;
                    case Direction.left:
                        if (ModX < 200)
                            ModX = 0;
                        else
                            ModX -= 200;
                        break;
                    case Direction.down:
                        if (ModY >= 460)
                            ModY = 610;
                        else
                            ModY += 200;
                        break;
                    case Direction.right:
                        if (ModX > 810)
                            ModX = 960;
                        else
                            ModX += 200;
                        break;
                }
            }
        }
        public void DetectBullets(Entities bulletEntities)
        {
                foreach (Bullet bullet in bulletEntities.EntitiesList)
                {
                    if (bullet.GetType() == typeof(FireBall))
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
                    else
                    {
                        continue;
                    }

                }
        }
     
    }
}
