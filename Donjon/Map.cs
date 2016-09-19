using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donjon
{
    class Map
    {
        public int Width { get; }
        public int Height { get; }

        public readonly Cell[,] Cells;
        public List<Monster> Monsters { get; } = new List<Monster>();

        public List<Monster> LivingMonsters
        {
            get { return Monsters.Where(m => m.Health > 0).ToList(); }
        }

        public List<Monster> DeadMonsters
            => Monsters.Where(m => m.Health <= 0).ToList();

        public List<Troll> Trolls {
            get {
                return LivingMonsters
                  .Where(m => m is Troll)
                  .Select(m => m as Troll)
                  .ToList();
            }
        } 


        public Map(int width, int height)
        {
            Width = width;
            Height = height;

            Cells = new Cell[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Cells[x, y] = new Cell();
                }
            }
        }
    }
}
