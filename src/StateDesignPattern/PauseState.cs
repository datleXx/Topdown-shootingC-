using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class PauseState : State
    {
        private Game _gameState;
        public PauseState(Game game)
        {
            _gameState = game;
        }
        public override void Update()
        {
            var optimusFont = SplashKit.LoadFont("optimusFont", "Optimus.otf"); //size = 30

            var titleFont = SplashKit.LoadFont("titleFont", "Optimus.otf"); // size = 100 
            while (!SplashKit.QuitRequested())
            {
                SplashKit.ProcessEvents();
                SplashKit.DrawText("PAUSED", Color.Black, "optimusFont", 30, 439, 279);
                SplashKit.DrawText("PAUSED", Color.Blue, "optimusFont", 30, 440, 280);
                SplashKit.DrawText("Press SPACE to continue", Color.Black, "optimusFont", 30, 329, 319);
                SplashKit.DrawText("Press SPACE to continue", Color.Purple, "optimusFont", 30, 330, 320);
                SplashKit.RefreshScreen(60);
                SplashKit.ClearScreen(Color.White);
                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    PreviousState();
                }
            }
        }
        public void PreviousState()
        {
            _gameState.SetState(new InGameState(_gameState));
            _gameState.GameState.Update();
        }
    }
}
