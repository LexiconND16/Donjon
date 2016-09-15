using System;
using System.Threading;

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
            Console.ReadKey(true);
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
                case ConsoleKey.P:
                    PickUp();
                    break;
                default:
                    break;
            }

            return quit;
        }

        private void PickUp()
        {
            var cell = map.Cells[player.X, player.Y];
            if (cell.Item != null)
            {
                var pickedUp = player.PickUp(cell.Item);
                if (pickedUp)
                {
                    Console.WriteLine("You pick up the " + cell.Item.Name);
                    cell.Item = null;
                }
                else
                {
                    Console.WriteLine("You didn't pick up the " + cell.Item.Name);
                }
            }
            Thread.Sleep(3000);
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
                else {
                    Console.WriteLine("The " + cell.Monster.Name + " attacks you");
                    cell.Monster.Fight(player);
                }
            }
            Thread.Sleep(3000);
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
            Console.WriteLine("Weapon: " + (player.HasSword ? "sword" : "no"));

            Console.WriteLine("In this room you see:");
            var cell = map.Cells[player.X, player.Y];
            if (cell.Monster == null)
            {
                Console.WriteLine("  no monster");
            }
            else if (cell.Monster.Health > 0)
            {
                Console.WriteLine($"  {cell.Monster.Name} ({cell.Monster.Health} hp)");
            }
            else {
                Console.WriteLine("  A dead " + cell.Monster.Name);
            }
            if (cell.Item == null)
            {
                Console.WriteLine("  no item");
            }
            else {
                Console.WriteLine("  A " + cell.Item.Name);
            }
            Console.WriteLine("Your backpack contains:");
            foreach (var item in player.Backpack)
            {
                Console.WriteLine("  " + item.Name);
            }
            if (player.Backpack.Count == 0) Console.WriteLine("  nothing");
        }

        private void PopulateMap()
        {
            var random = new Random();
            foreach (var cell in map.Cells)
            {
                var chance = random.Next(100);
                if (chance < 20)
                {
                    // monster
                    var whichMonster = random.Next(3);

                    switch (whichMonster)
                    {
                        case 0:
                            cell.Monster = new Goblin();
                            break;
                        case 1:
                            cell.Monster = new Orc();
                            break;
                        case 2:
                            cell.Monster = new Troll();
                            break;
                    }
                }
                else if (chance < 30)
                {
                    // item
                    var whichItem = random.Next(7);
                    switch (whichItem)
                    {
                        case 0:
                            cell.Item = new Sword();
                            break;
                        case 1:
                            cell.Item = new Gem();
                            break;
                        case 2:
                        case 3:
                            cell.Item = new Nugget();
                            break;
                        case 4:
                        case 5:
                        case 6:
                            cell.Item = new Sock();
                            break;
                    }
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
                        Console.Write(cell.Monster.MapSymbol);
                    }
                    else if (cell.Item != null)
                    {
                        Console.Write(cell.Item.MapSymbol);
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