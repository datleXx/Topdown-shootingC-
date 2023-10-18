using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class MenuState : State
    {
        private Game _gameContext; 
        public MenuState(Game gameContext)
        {
            _gameContext = gameContext;
        }

        public override void Update()
        {
            var optimusFont = SplashKit.LoadFont("optimusFont", "Optimus.otf"); //size = 30

            var titleFont = SplashKit.LoadFont("titleFont", "Optimus.otf"); // size = 100 

            while (!SplashKit.QuitRequested())
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen(Color.White);
                int a = 50;
                SplashKit.DrawText("S", Color.Black, "titleFont", 100, 323 - a, 153);
                SplashKit.DrawText("H", Color.Black, "titleFont", 100, 388 - a, 163);
                SplashKit.DrawText("O", Color.Black, "titleFont", 100, 453 - a, 153);
                SplashKit.DrawText("O", Color.Black, "titleFont", 100, 518 - a, 163);
                SplashKit.DrawText("T", Color.Black, "titleFont", 100, 583 - a, 153);
                SplashKit.DrawText("ER", Color.Black, "titleFont", 100, 648 - a, 163);
                SplashKit.DrawText("S", Color.Gray, "titleFont", 100, 320 - a, 150);
                SplashKit.DrawText("H", Color.Gray, "titleFont", 100, 385 - a, 160);
                SplashKit.DrawText("O", Color.Gray, "titleFont", 100, 450 - a, 150);
                SplashKit.DrawText("O", Color.Gray, "titleFont", 100, 515 - a, 160);
                SplashKit.DrawText("T", Color.Gray, "titleFont", 100, 580 - a, 150);
                SplashKit.DrawText("ER", Color.Gray, "titleFont", 100, 645 - a, 160);
                SplashKit.DrawText("Press H to open up the tutorial", Color.Gray, "optimusFont", 30, 80, 400);
                SplashKit.DrawText("This game has 3 difficulties - Easy, Normal or Hard.", Color.Black, "optimusFont", 30, 80, 450);
                SplashKit.DrawText("Press 1 (Easy), 2 (Normal) or 3 (Hard) to start!", Color.Black, "optimusFont", 30, 80, 500);
                SplashKit.RefreshScreen(60);
                if (SplashKit.KeyTyped(KeyCode.HKey))
                {
                    PreviousState();
                }
                if (SplashKit.KeyTyped(KeyCode.Num1Key))
                {
                    _gameContext.Difficulty = 1;
                    _gameContext.Horde = new EnemyWave(_gameContext.Difficulty, _gameContext.P);
                    foreach (Enemy e in _gameContext.Horde.EnemyList.ToList())
                        _gameContext.EnemyEntities.AddObject(e);
                    NextState();
                }
                if (SplashKit.KeyTyped(KeyCode.Num2Key))
                {
                    _gameContext.Difficulty = 2;
                    _gameContext.Horde = new EnemyWave(_gameContext.Difficulty, _gameContext.P);
                    foreach (Enemy e in _gameContext.Horde.EnemyList.ToList())
                        _gameContext.EnemyEntities.AddObject(e);
                    NextState();
                }
                if (SplashKit.KeyTyped(KeyCode.Num3Key))
                {
                    _gameContext.Difficulty = 3;
                    _gameContext.Horde = new EnemyWave(_gameContext.Difficulty, _gameContext.P);
                    foreach (Enemy e in _gameContext.Horde.EnemyList.ToList())
                        _gameContext.EnemyEntities.AddObject(e);
                    NextState();
                }
            }
        }
        public void PreviousState()
        {
            _gameContext.SetState(new InstructionState(_gameContext));
            _gameContext.GameState.Update();
        }

        public void NextState()
        {
            _gameContext.SetState(new InGameState(_gameContext));
            _gameContext.GameState.Update();
        }
    }
}
