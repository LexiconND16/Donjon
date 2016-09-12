using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donjon
{
    class Monster
    {
        public int Health { get; set; }
        public string MapSymbol { get; }
        public string Name { get; }

        public Monster(string mapSymbol, string name, int health)
        {
            MapSymbol = mapSymbol;
            Name = name;
            Health = health;
        }
    }

    class Goblin : Monster
    {
        public Goblin() : base("G", "goblin", 20) { }
    }

    class Orc : Monster
    {
        public Orc() : base("O", "orc", 40) { }
    }
}
