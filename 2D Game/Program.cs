using System;

namespace _2D_Game
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new Core.Game())
                game.Run();
        }
    }
}
