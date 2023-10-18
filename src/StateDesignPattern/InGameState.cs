using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class InGameState : State
    {
        private Game _gameContext;
        private GameMechanism _mechanism;
        public InGameState(Game game) 
        {
            _gameContext = game;
            _mechanism = new(_gameContext);
        }
        public void Pause()
        {
            _gameContext.SetState(new PauseState(_gameContext));
            (_gameContext.GameState as PauseState).Update();
        }
        public void GameOver()
        {
            _gameContext.SetState(new GameOverState(_gameContext));
            _gameContext.GameState.Update();
        }
        public override void Update()
        {
            while (!SplashKit.QuitRequested())
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen(Color.White);

                _mechanism.MainGameRun();

                SplashKit.RefreshScreen(60);

                //game over screen
                if (_gameContext.P.HP <= 0)
                {
                    GameOver();
                }

                //new horde when no enemy is left
                if (_gameContext.EnemyEntities.EntitiesList.Count == 0)
                {
                    //_gameContext.BloodEntities.EntitiesList.Clear();
                    switch (_gameContext.Difficulty)
                    {
                        case 1:
                            if (_gameContext.WaveCount == 1)
                            {
                                Win();
                            }
                            break;
                        case 2:
                            if (_gameContext.WaveCount == 10)
                            {
                                Win();
                            }
                            break;
                        case 3:
                            if (_gameContext.WaveCount == 4)
                            {
                                Win();
                            }
                            break;
                    }
                    Transition();
                }

                if (SplashKit.KeyTyped(KeyCode.EscapeKey))
                {
                    Pause();
                }
            }
        }
        public void Transition()
        {
            _gameContext.SetState(new WaveTransitionState(_gameContext));
            _gameContext.GameState.Update();
        }
        public void Win()
        {
            _gameContext.SetState(new WinState(_gameContext)); 
            _gameContext.GameState.Update();
        }
    }
}
