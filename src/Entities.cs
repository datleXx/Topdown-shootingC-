using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace MyGame
{
    public class Entities
    {
        private List<GameObject> _entities;

        public Entities()
        {
            EntitiesList = new List<GameObject>();
        }

        public List<GameObject> EntitiesList
        {
            get
            {
                return _entities;
            }
            set
            {
                _entities = value;
            }
        }

        public void AddObject(GameObject a)
        {
            EntitiesList.Add(a);
        }

        public void Display()
        {
            foreach(GameObject a in EntitiesList)
            {
                a.DisplayObject();
            }
        }

        public void DeathCheck()
        {
            foreach (MovableObject a in EntitiesList.ToList())
            {
                if (a.HP <= 0)
                {
                    if (a.GetType() == typeof(Enemy))
                    {
                        Blood blood = new(a.ModX, a.ModY);
                        blood.DisplayObject();
                    }
                    EntitiesList.Remove(a);
                }
            }
        }
    }
}
