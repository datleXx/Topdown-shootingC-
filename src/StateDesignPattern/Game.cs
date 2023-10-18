using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Game
    {
        private State _state;
        private int _waveCount;
        private Player _player;
        private SplashKitSDK.Timer _reloadTimer;
        private Entities _enemyEntities;
        private Entities _playerEntities;
        private EnemyWave _horde;
        private Entities _bulletEntities;
        private Entities _powerUpEntities;
        private Entities _bloodEntities; 
        private PowerBoostSpawner _powerBoostSpawner;
        private int _difficulty; 
        public Game() 
        {
            GameState = new MenuState(this);
            WaveCount = 1;
            P = new Player();
            ReloadTimer = new SplashKitSDK.Timer("Reload Timer");
            EnemyEntities = new Entities();
            PlayerEntity = new Entities();
            BulletEntities = new Entities();
            PowerBoostEntities = new Entities();
            PowerBoostSpawner = new PowerBoostSpawner(P, EnemyEntities);
            BloodEntities = new Entities();
            PlayerEntity.AddObject(P);
        }
        public int Difficulty
        {
            get
            {
                return _difficulty; 
            }
            set
            {
                _difficulty = value; 
            }
        }
        public int WaveCount
        {
            get
            {
                return _waveCount;
            }
            set
            {
                _waveCount = value;
            }
        }

        public Player P
        {
            get
            {
                return _player;
            }
            set
            {
                _player = value;
            }
        }

        public Entities BloodEntities
        {
            get
            {
                return _bloodEntities;
            }
            set
            {
                _bloodEntities = value; 
            }
        }
        public Entities BulletEntities
        {
            get
            {
                return _bulletEntities;
            }
            set
            {
                _bulletEntities = value;
            }
        }
        public SplashKitSDK.Timer ReloadTimer
        {
            get
            {
                return _reloadTimer;
            }
            set
            {
                _reloadTimer = value;
            }
        }
        public Entities EnemyEntities
        {
            get
            {
                return _enemyEntities;
            }
            set
            {
                _enemyEntities = value;
            }
        }
        public EnemyWave Horde
        {
            get
            {
                return _horde;
            }
            set
            {
                _horde = value;
            }
        }
        public Entities PlayerEntity
        {
            get
            {
                return _playerEntities; 
            }
            set
            {
                _playerEntities = value;
            }
        }
        public Entities PowerBoostEntities
        {
            get
            {
                return _powerUpEntities;
            }
            set
            {
                _powerUpEntities = value;
            }
        }
        public PowerBoostSpawner PowerBoostSpawner
        {
            get
            {
                return _powerBoostSpawner;
            }
            set
            {
                _powerBoostSpawner = value;
            }
        }
        public State GameState
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
            }
        }

        public void SetState(State state)
        {
            GameState = state;
        }
        public void Run()
        {
            if (GameState == null)
            {
                GameState = new MenuState(this);
                GameState.Update();
            }
            else
            {
                GameState.Update();
            }
        }
    }
}
