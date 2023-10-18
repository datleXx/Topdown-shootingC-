using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace MyGame
{
    public abstract class GameObject
    {
        private Color _color;
        private int _width, _height;
        private double _x, _y;
        private ObjectType _hostility;
        private Bitmap _bitmap;
        private Sprite _sprite;
        private SplashKitSDK.Timer _spawnTimer; 

        public GameObject(double x, double y, string filepath, string name)
        {
            _spawnTimer = new SplashKitSDK.Timer(new Random().Next().ToString());
            ModX = x;
            ModY = y;
            Hostility = ObjectType.neutral;
            Bitmap = SplashKit.LoadBitmap(name, filepath);
            Sprite = SplashKit.CreateSprite(Bitmap);

        }
        public SplashKitSDK.Timer SpawnTimer
        {
            get
            {
                return _spawnTimer;
            }
        }
        public Bitmap Bitmap 
        { get { return _bitmap; } 
          set { _bitmap = value; }
        }
        public Sprite Sprite 
        { get { return _sprite; }
          set { _sprite = value; }
        }

        public ObjectType Hostility
        {
            get
            {
                return _hostility;
            }
            set
            {
                _hostility = value;
            }
        }

        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }

        public int Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
            }
        }

        public Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }
        
        public double ModX
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }

        public double ModY
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }


        //cordinate is from the outliner
        public virtual void DisplayObject()
        {
            SplashKit.DrawSprite(Sprite, ModX, ModY);
            //Bitmap hero = SplashKit.LoadBitmap("hero", "hero.png");
            //SplashKit.DrawBitmap(hero, 100, 100);
        }

        public bool Collision(Player p)
        {
            if (Hostility == ObjectType.hostile )
            {
                //if collide from the left
                bool collisionX = Sprite.Width + ModX >= p.ModX && p.ModX + p.Sprite.Width >= ModX;
                bool collisionY = Sprite.Height + ModY >= p.ModY && p.ModY + p.Sprite.Height >= ModY;
                return collisionX && collisionY;
            }
            return false;
        }
    }
}
