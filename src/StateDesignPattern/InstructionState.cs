using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class InstructionState : State
    {
        private Game _gameState;
        public InstructionState(Game game)
        {
            _gameState = game;
        }
        public void PreviousState()
        {
            _gameState.SetState(new MenuState(_gameState));
            _gameState.GameState.Update();
        }
        public override void Update()
        {
            while (!SplashKit.QuitRequested())
            {
                SplashKit.ProcessEvents();
                //clearing screen to white
                SplashKit.ClearScreen(Color.White);
                SplashKit.DrawText("In this game, you are a black block.", Color.Black, "optimusFont", 30, 50, 50);
                SplashKit.DrawText("Basically you just shoot anything that's not you.", Color.Black, "optimusFont", 30, 50, 100);
                SplashKit.DrawText("If you touch zombies, you lose HP equal to theirs", Color.Black, "optimusFont", 30, 50, 150);
                SplashKit.DrawText("ESC - Pause", Color.Black, "optimusFont", 30, 50, 200);
                SplashKit.DrawText("W A S D - Move", Color.Black, "optimusFont", 30, 50, 250);
                SplashKit.DrawText("Space Key - shoot at a direction created by Mouse Position", Color.Black, "optimusFont", 30, 50, 300);
                SplashKit.DrawText("R - reload", Color.Black, "optimusFont", 30, 50, 350);
                SplashKit.DrawText("W/A/S/D + LEFT SHIFT - teleport", Color.Black, "optimusFont", 30, 50, 400);
                SplashKit.DrawText("The range of teleportation is the green circle around you", Color.Black, "optimusFont", 30, 50, 450);
                SplashKit.DrawText("Teleportation cooldown: 1.5s | Reload time: 1s", Color.Black, "optimusFont", 30, 50, 500);
                SplashKit.DrawText("Press H again or ESC to return to the main screen", Color.Black, "optimusFont", 30, 50, 550);
                //drawing things out
                SplashKit.RefreshScreen(60);
                if (SplashKit.KeyTyped(KeyCode.HKey) || SplashKit.KeyTyped(KeyCode.EscapeKey))
                {
                    PreviousState();
                }
            }
        }
    }
}
