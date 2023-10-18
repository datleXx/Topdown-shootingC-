﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public abstract class EnemyWaveFactory : IEnemyFactory
    {
        public abstract Enemy CreateEnemies(Player p);
    }
}
