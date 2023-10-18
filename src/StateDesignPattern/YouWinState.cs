﻿using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class WinState : State
    {
        private Game _gameContext; 
        public WinState(Game gameContext)
        {
            _gameContext = gameContext;
        }

        public void NextState()
        {
            _gameContext = new();
            _gameContext.Run();
        }
        public override void Update()
        {
            var optimusFont = SplashKit.LoadFont("optimusFont", "Optimus.otf"); //size = 30

            var titleFont = SplashKit.LoadFont("titleFont", "Optimus.otf"); // size = 100 

            SplashKit.OpenAudio();
            var pewFX = SplashKit.LoadSoundEffect("pewpew", "pew.ogg");
            var oofFX = SplashKit.LoadSoundEffect("oof", "oof.ogg");
            var fortnitededFX = SplashKit.LoadSoundEffect("fortniteded", "fortniteded.ogg");
            while (!SplashKit.QuitRequested())
            {
                SplashKit.PlaySoundEffect(fortnitededFX);
                SplashKit.ClearScreen(Color.White);
                SplashKit.DrawText("CONGRATULATION! YOU WONNNNN !!!", Color.Black, "optimusFont", 30, 249, 279);
                SplashKit.DrawText("CONGRATULATION! YOU WONNNNN !!!", Color.Red, "optimusFont", 30, 250, 280);
                SplashKit.DrawText("You survived " + _gameContext.WaveCount.ToString() + " waves", Color.Black, "optimusFont", 30, 330, 349);
                SplashKit.DrawText("You survived " + _gameContext.WaveCount.ToString() + " waves", Color.Gray, "optimusFont", 30, 331, 350);
                SplashKit.DrawText("You destroyed " + _gameContext.P.Kill.ToString() + " blocks", Color.Black, "optimusFont", 30, 330, 399);
                SplashKit.DrawText("You destroyed " + _gameContext.P.Kill.ToString() + " blocks", Color.Gray, "optimusFont", 30, 331, 400);
                SplashKit.FreeResourceBundle("soundFX.txt");
                SplashKit.RefreshScreen(60);
                SplashKit.Delay(3000);
                SplashKit.ClearScreen(Color.White);
                NextState();
            }
        }
    }
}
