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
        public Sword() : base("S", "sword") { }
    }
}
