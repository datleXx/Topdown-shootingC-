using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace MyGame
{
    public abstract class MovableObject : GameObject
    {
        private int  _health, _baseHP;
        private float _spd;

        public MovableObject(int hp, double x, double y, string filepath, string name) : base(x, y, filepath, name)
        {
            HP = hp;
            _baseHP = hp;
            Speed = 1;
        }

        public int BaseHP
        {
            get
            {
                return _baseHP;
            }
        }

        public int HP
        {
            get
            {
                return _health;
            }
            set
            {
                _health = value;
            }
        }

        public float Speed
        {
            get
            {
                return _spd;
            }
            set
            {
                _spd = value;
            }
        }
        //movement cannot be made if the object would go pass the screen border
        public virtual void MoveUp()
        {
            if (ModY > 50 && Hostility != ObjectType.frozen)
                ModY -= Speed;
        }

        public virtual void MoveDown()
        {
            if (ModY < 610 && Hostility != ObjectType.frozen)
                ModY += Speed;
        }

        public virtual void MoveLeft()
        {
            if (ModX > 0 && Hostility != ObjectType.frozen)
                ModX -= Speed;
        }

        public virtual void MoveRight()
        {
            if (ModX < 950 && Hostility != ObjectType.frozen)
                ModX += Speed;
        }

        //take damage
        public void TakeDamage(int damage)
        {
            HP += -damage;
            if (HP < 0)
                HP = 0;
        }
    }
}
