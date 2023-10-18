using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SplashKitSDK;

namespace MyGame
{
    public enum Direction { up, down, left, right, bullet, none }

    public enum ObjectType { neutral, hostile, frozen }

    public class Program
    {
        public static void Main()
        {
            //Open the game window
            Game gameContext = new Game();
            SplashKit.OpenWindow("Shooter", 1000, 650); 

            //Run the game loop
            gameContext.Run();
        }
    }
}