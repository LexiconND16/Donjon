using System;

namespace Donjon
{
    public class Game
    {
        Map map;
        Player player;

        public Game(int width, int height)
        {
            map = new Map(width, height);
        }

        public void Run()
        {
            player = new Player(health: 100);

            PopulateMap();

            PrintMap();
            bool quit = false;
            do
            {
                // get input from player
                Console.WriteLine("Press a key, Q to quit");
                var keyInfo = Console.ReadKey(true);
                var key = keyInfo.Key;

                // process input
                switch (key)
                {
                    case ConsoleKey.Q:
                        quit = true;
                        break;
                    case ConsoleKey.UpArrow:
                        if (player.Y > 0) player.Y--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (player.Y < map.Height - 1) player.Y++;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (player.X > 0) player.X--;
                        break;
                    case ConsoleKey.RightArrow:
                        if (player.X < map.Width - 1) player.X++;
                        break;
                    default:
                        break;
                }

                // print map & other info
                Console.SetCursorPosition(0, 0);
                PrintMap();

            } while (!quit && player.Health > 0);

            // game over
        }

        private void PopulateMap()
        {
            var random = new Random();
            foreach (var cell in map.Cells)
            {
                if (random.Next(100) < 20)
                    if (random.Next(2) == 0)
                    {
                        cell.Monster = new Goblin(); // polymorfism, regel 1
                    }
                    else
                    {
                        cell.Monster = new Orc();
                    }
            }
        }

        private void PrintMap()
        {
            var cells = map.Cells;
            var height = map.Height;
            var width = map.Width;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    var cell = cells[x, y];
                    Console.Write(" ");
                    if (player.X == x && player.Y == y)
                    {
                        Console.Write("P");
                    }
                    else if (cell.Monster != null)
                    {
                        Console.Write(cell.Monster.MapSymbol);  // polymorfism, regel 2
                    }
                    else {
                        Console.Write(".");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}