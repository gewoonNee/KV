using System;

namespace KV
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (KV game = new KV())
            {
                game.Run();
            }
        }
    }
}

