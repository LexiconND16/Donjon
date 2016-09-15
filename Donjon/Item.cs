using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donjon
{
    class Item
    {
        public string MapSymbol { get; set; }
        public string Name { get; set; }

        public Item(string mapSymbol, string name)
        {
            MapSymbol = mapSymbol;
            Name = name;
        }
    }

    class Sword : Item
    {
        public Sword() : base("s", "sword") { }
    }

    class Gem : Item
    {
        public Gem() : base("g", "gem") { }
    }
    class Nugget : Item
    {
        public Nugget() : base("n", "gold nugget") { }
    }
    class Sock : Item
    {
        public Sock() : base("d", "old dirty sock") { }
    }
}
