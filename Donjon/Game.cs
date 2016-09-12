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
            PrintStats();
            bool quit = false;
            do
            {
                // get input from player and process it
                ConsoleKey key = GetKey();
                quit = Process(quit, key);

                // print map & other info
                Console.Clear();
                PrintMap();
                PrintStats();

                var cell = map.Cells[player.X, player.Y];                
                if (cell.Monster?.Health <= 0)
                {
                    cell.Monster = null;
                }


            } while (!quit && player.Health > 0);

            // game over
            Console.WriteLine("Game Over");
            Console.ReadKey();
        }

        private bool Process(bool quit, ConsoleKey key)
        {
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
                case ConsoleKey.F:
                    Fight();
                    break;
                default:
                    break;
            }

            return quit;
        }

        private void Fight()
        {
            var cell = map.Cells[player.X, player.Y];
            if (cell.Monster != null)
            {
                Console.WriteLine("You attack the " + cell.Monster.Name);
                player.Fight(cell.Monster);
                if (cell.Monster.Health <= 0)
                {
                    Console.WriteLine("You defeated the " + cell.Monster.Name);
                }
            }
        }

        private static ConsoleKey GetKey()
        {
            Console.WriteLine();
            Console.WriteLine("Press a key, Q to quit");
            var keyInfo = Console.ReadKey(true);
            var key = keyInfo.Key;
            return key;
        }

        private void PrintStats()
        {
            Console.WriteLine("HP: " + player.Health);
            Console.WriteLine($"X: {player.X}, Y: {player.Y}");

            Console.WriteLine("In this room you see:");
            var cell = map.Cells[player.X, player.Y];
            if (cell.Monster == null)
            {
                Console.WriteLine("  nothing");
            }
            else if (cell.Monster.Health > 0)
            {
                Console.WriteLine($"  {cell.Monster.Name} ({cell.Monster.Health} hp)");
            }
            else {
                Console.WriteLine("  A dead " + cell.Monster.Name);
            }
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
                        Console.Write(cell.Monster.MapSymbol);  // polymorfism, regel 2, typ
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