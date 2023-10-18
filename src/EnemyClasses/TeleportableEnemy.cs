using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace MyGame
{
    public class TeleportableEnemy : Enemy
    {
        private bool _cordLocked;
        private bool _idle;
        private Point2D _cordinate;
        private SplashKitSDK.Timer _skillChargeTime;
        private SplashKitSDK.Timer _skillSpacing;
        private int _spacingMultiplier;
        private Random _seed;

        public TeleportableEnemy(int hp, double x, double y, int multiplier, Player p) : base(hp, x, y, "tele.png", "teleportable enemy", p)
        {
            _seed = new Random();
            _skillChargeTime = new SplashKitSDK.Timer("Skill Charge Time " + _seed.Next().ToString());
            _skillSpacing = new SplashKitSDK.Timer("Skill Spacing Time " + _seed.Next().ToString());
            _cordLocked = false;
            _idle = true;
            _spacingMultiplier = multiplier;
            _skillChargeTime.Start();
            _skillSpacing.Start();
        }
        public override void DisplayObject()
        {
            //SplashKit.FillRectangle(Color.LightSkyBlue, ModX, ModY, 40, 40);
            if (SpawnTimer.Ticks > 3000)
            {
                SplashKit.FillRectangle(Color.Red, ModX + 25, ModY - 15, 30, 5);
                //current HP
                SplashKit.FillRectangle(Color.Blue, ModX + 25, ModY - 15, 30 / BaseHP * HP, 5);
                SpawnTimer.Pause();
                base.DisplayObject();
                Hostility = ObjectType.hostile;
                Speed = 0;

            }
            else
            {
                SplashKit.FillRectangle(Color.YellowGreen, ModX, ModY, 40, 40);
                _skillSpacing.Start();
            }
        }

        public override void SpecialMove()
        {
            if (_skillSpacing.Ticks > _spacingMultiplier * 500)
            {
                _skillSpacing.Stop();
                _idle = false;
                _skillChargeTime.Start();
            }
            if (!_idle)
            {
                if (_skillChargeTime.Ticks < 3000 && _cordLocked == false)
                {
                    Jump(1);
                }
                else if (_skillChargeTime.Ticks < 4000 && _cordLocked == false)
                {
                    Jump(2);
                }
                else if (_skillChargeTime.Ticks < 5000)
                {
                    if (_cordLocked == false)
                    {
                        _cordLocked = true;
                        _cordinate.X = p.ModX;
                        _cordinate.Y = p.ModY;
                    }
                    Jump(3);
                }
                else if (_cordLocked == true && _skillChargeTime.Ticks > 4000)
                {
                    _cordLocked = false;
                    Jump(4);
                }
            }
        }

        public void Jump(int state)
        {
            switch (state)
            {
                case 1:
                    SplashKit.DrawRectangle(Color.DarkGreen, p.ModX - 6, p.ModY - 6, p.Width + 20, p.Height + 20);
                    break;
                case 2:
                    SplashKit.DrawRectangle(Color.Orange, p.ModX - 4, p.ModY - 4, p.Width + 12, p.Height + 12);
                    break;
                case 3:
                    SplashKit.DrawRectangle(Color.Red, _cordinate.X - 2, _cordinate.Y - 2, p.Width + 8, p.Height + 8);
                    break;
                case 4:
                    ModX = (int)_cordinate.X;
                    ModY = (int)_cordinate.Y;
                    _skillChargeTime.Stop();
                    _skillChargeTime.Reset();
                    _skillChargeTime.Start();
                    break;
            }
        }
    }
}
