using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class WaveTransitionState : State
    {
        private Game _gameContext;
        public WaveTransitionState(Game game)
        {
            _gameContext = game;
        }
        public void PreviousState()
        {
            _gameContext.SetState(new InGameState(_gameContext));
            _gameContext.GameState.Update();
        }

        public override void Update() 
        { 
            _gameContext.WaveCount++;
            _gameContext.EnemyEntities.EntitiesList.Clear();
            _gameContext.PowerBoostEntities.EntitiesList.Clear();
            _gameContext.Horde.NewWave(_gameContext.P);
            foreach (Enemy e in _gameContext.Horde.EnemyList)
                _gameContext.EnemyEntities.AddObject(e);

            SplashKit.RefreshScreen(60);
            PreviousState();
        }
    }
}
