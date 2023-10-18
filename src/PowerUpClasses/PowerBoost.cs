using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace MyGame
{
    public abstract class PowerBoost : GameObject
    {
        private float _duration;
        private Player _p;
        private SplashKitSDK.Timer _effectTimer;
        private Entities _targets;
        private IRevertStrategy _revertStrategy;
        private ITriggerEffectStrategy _triggerStrategy;
        public PowerBoost(double x, double y, Player p, float duration, string filepath, string name, string timerName, Entities targets) : base(x, y, filepath, name)
        {
            Hostility = ObjectType.hostile;
            _p = p;
            _duration = duration * 1000;
            Targets = targets;
            _effectTimer = new SplashKitSDK.Timer(timerName);

        }
        public IRevertStrategy RevertStrategy { 
            get
            {
                return _revertStrategy;
            }
            set
            {
                _revertStrategy = value;
            }
        }
        public ITriggerEffectStrategy TriggerStrategy
        {
            get
            {
                return _triggerStrategy;
            }
            set
            {
                _triggerStrategy = value;
            }
        }
        public SplashKitSDK.Timer PowerBoostTimer
        {
            get { return _effectTimer; }
        }

        public Player p
        {
            get
            {
                return _p;
            }
        }
        public Entities Targets { get => _targets; set => _targets = value; }

        public override void DisplayObject()
        {
            SplashKit.DrawSprite(Sprite, ModX + 1, ModY + 1);
            SplashKit.DrawRectangle(Color.DarkGreen, ModX, ModY, Sprite.Width, Sprite.Height);

            if (Collision(_p))
            {
                TriggerEffect();
                ModY = -100;
            }
        }

        public void RevertEffect()
        {
            RevertStrategy.Revert(this);
        }

        public bool EffectTimedOut()
        {
            if (PowerBoostTimer.Ticks > _duration)
            {
                return true;
            }

            return false;
        }

        public void TriggerEffect()
        {
            TriggerStrategy.Trigger(this);
        }
    }
}
