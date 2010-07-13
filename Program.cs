using System;
using multiplayerships;

namespace multiplayerships
{
    
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        static KeyboardInputHandler keyboardInputHandler;
        static void Main(string[] args)
        {
            
            
            using (Game1 game = new Game1())
            {
                game.Run();
            }


        }
    }
}

