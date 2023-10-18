using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class GameMechanism
    {
        private Game _gameContext;


        private Font optimusFont;

        private SoundEffect pewFX;
        private SoundEffect oofFX;
        public GameMechanism(Game gameContext)
        {
            _gameContext = gameContext;


            //audio and font initialization
            optimusFont = SplashKit.LoadFont("optimusFont", "Optimus.otf"); //size = 30


            SplashKit.OpenAudio();
            pewFX = SplashKit.LoadSoundEffect("pewpew", "pew.ogg");
            oofFX = SplashKit.LoadSoundEffect("oof", "oof.ogg");
        }

        public void PlayerController()
        {
            //PLAYER ROTATION
            _gameContext.P.Rotate(SplashKit.MouseX(), SplashKit.MouseY());

            //PLAYER MOVEMENT
            if (SplashKit.KeyDown(KeyCode.WKey))
            {
                if (SplashKit.KeyTyped(KeyCode.LeftShiftKey))
                    _gameContext.P.Teleport(Direction.up);
                else
                {
                    _gameContext.P.MoveUp();
                }
            }
            if (SplashKit.KeyDown(KeyCode.AKey))
            {
                if (SplashKit.KeyTyped(KeyCode.LeftShiftKey))
                    _gameContext.P.Teleport(Direction.left);
                else
                {
                    _gameContext.P.MoveLeft();
                }
            }
            if (SplashKit.KeyDown(KeyCode.SKey))
            {
                if (SplashKit.KeyTyped(KeyCode.LeftShiftKey))
                    _gameContext.P.Teleport(Direction.down);
                else
                {
                    _gameContext.P.MoveDown();
                }
            }
            if (SplashKit.KeyDown(KeyCode.DKey))
            {
                if (SplashKit.KeyTyped(KeyCode.LeftShiftKey))
                    _gameContext.P.Teleport(Direction.right);
                else
                {
                    _gameContext.P.MoveRight();
                }
            }

            //player regen
            _gameContext.P.Regenerate();

            //telling player to draw out its details
            foreach (Player Ps in _gameContext.PlayerEntity.EntitiesList)
                Ps.DisplayPlayerDetails(optimusFont);
        }
        public void PlayerShootingController()
        {
            //player shooting
            if (SplashKit.KeyTyped(KeyCode.SpaceKey) && _gameContext.P.Weapon.Round != 0)
            {
                Point2D target = SplashKit.MousePosition();
                _gameContext.BulletEntities.AddObject(_gameContext.P.Weapon.Shoot(Direction.bullet, _gameContext.P.ModX, _gameContext.P.ModY, pewFX, target));
            }

            //player reloading
            if (SplashKit.KeyTyped(KeyCode.RKey) && !_gameContext.P.Weapon.Reloading)
            {
                _gameContext.ReloadTimer.Start();
                _gameContext.P.Weapon.Reloading = true;
            }

            //reloading delay handler
            if (_gameContext.ReloadTimer.Ticks > 1000)
            {
                _gameContext.ReloadTimer.Stop();
                _gameContext.P.Weapon.Reload();
            }

        }
        public void EnemyController()
        {
            //bot control
            foreach (Enemy e in _gameContext.EnemyEntities.EntitiesList)
            {
                if (e.Hostility == ObjectType.hostile)
                {
                    e.SpecialMove();
                    e.Rotate();
                }
            }
        }
        public void BulletFlyingController()
        {
            //bullet shot flying physics
            foreach (Bullet b in _gameContext.BulletEntities.EntitiesList)
            {
                b.Fly();
            }
        }
        
        public void GiantEnemyShootingController()
        {
                foreach (Enemy g in _gameContext.EnemyEntities.EntitiesList)
                {
                    g.StartFire(_gameContext.BulletEntities);
                }
        }

        public void WaveCountingDownController()
        {
            //wave starting countdown
            if (_gameContext.Horde.EnemyList[0].SpawnTimer.Ticks > 0 && _gameContext.Horde.EnemyList[0].SpawnTimer.Ticks < 1000)
            {
                SplashKit.DrawText("3", Color.DarkGray, "optimusFont", 30, 492, 332);
                SplashKit.DrawText("3", Color.Yellow, "optimusFont", 30, 490, 330);
            }
            if (_gameContext.Horde.EnemyList[0].SpawnTimer.Ticks >= 1000 && _gameContext.Horde.EnemyList[0].SpawnTimer.Ticks < 2000)
            {
                SplashKit.DrawText("2", Color.DarkGray, "optimusFont", 30, 492, 332);  
                SplashKit.DrawText("2", Color.Orange, "optimusFont", 30, 490, 330);
            }
            if (_gameContext.Horde.EnemyList[0].SpawnTimer.Ticks >= 2000 && _gameContext.Horde.EnemyList[0].SpawnTimer.Ticks < 3000)
            {
                SplashKit.DrawText("1", Color.DarkGray, "optimusFont", 30, 492, 332);
                SplashKit.DrawText("1", Color.Red, "optimusFont", 30, 490, 330);
                _gameContext.BloodEntities.EntitiesList.Clear();
            }
        }

        public void DrawGame()
        {
            foreach (Bullet bullet in _gameContext.BulletEntities.EntitiesList)
            {
                if (bullet.FlyingDirection != Direction.none)
                    bullet.DisplayObject();
            }
            _gameContext.BloodEntities.Display();
            _gameContext.PowerBoostEntities.Display();
            _gameContext.EnemyEntities.Display();
            _gameContext.PlayerEntity.Display();
            //display current wave
            SplashKit.DrawText("Wave: " + _gameContext.WaveCount.ToString(), Color.Black, "optimusFont", 15, 850, 20);
        }
        public void ObjectRemoveController()
        {
            //Body remover (0 HP entities or timed out power ups will be removed)

            _gameContext.EnemyEntities.DeathCheck();
            _gameContext.BulletEntities.DeathCheck();
            foreach (Enemy e in _gameContext.Horde.EnemyList.ToList())
            {
                e.AddBlood(_gameContext.BloodEntities);
                if (e.HP <= 0)
                    _gameContext.Horde.EnemyList.Remove(e);
            }
        }
        public void CollisionController()
        {
            //enemy collision handler - collide with player
            foreach (Enemy e in _gameContext.Horde.EnemyList)
            {
                if (e.Collision(_gameContext.P))
                {
                    _gameContext.P.TakeDamage(e.HP);
                    e.TakeDamage(e.HP);
                }
            }
            foreach (Player _p in _gameContext.PlayerEntity.EntitiesList)
            {
                if (_p != null)
                    //bullet hit handler
                    _p.DetectBullets(_gameContext.BulletEntities);
            }
            foreach (Enemy e in _gameContext.EnemyEntities.EntitiesList)
            {
                if (e != null)
                    //bullet hit handler
                    e.DetectBullets(_gameContext.BulletEntities);

                //enemy death sound effect and kill counting
                if (e.HP <= 0)
                {
                    SplashKit.PlaySoundEffect(oofFX);
                    _gameContext.P.Kill++;
                }
            }

        }
        public void PowerBoostController()
        {
            _gameContext.PowerBoostSpawner.SpawnPowerBoosts(_gameContext.PowerBoostEntities);

            foreach (PowerBoost pwr in _gameContext.PowerBoostEntities.EntitiesList.ToList())
            {

                if (pwr.EffectTimedOut())
                {
                    pwr.RevertEffect();
                    _gameContext.PowerBoostEntities.EntitiesList.Remove(pwr);
                }
            }
        }
        public void MainGameRun()
        {
            WaveCountingDownController();

            PlayerController();

            PlayerShootingController();

            GiantEnemyShootingController();

            BulletFlyingController();

            EnemyController();

            CollisionController();

            ObjectRemoveController();

            PowerBoostController();

            DrawGame();

            EnemyController();
        }
    }
}
