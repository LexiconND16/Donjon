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

        protected int Damage = 20;

        public Monster(string mapSymbol, string name, int health)
        {
            MapSymbol = mapSymbol;
            Name = name;
            Health = health;
        }

        public virtual void Fight(Player player)
        {
            player.Health -= Damage;
        }
    }

    class Goblin : Monster
    {
        public Goblin() : base("G", "goblin", 20) { }
    }

    class Orc : Monster
    {
        public Orc() : base("O", "orc", 40) {
            Damage = 40;
        }
    }
    class Troll : Monster {
        public Troll() : base("T", "troll", 50) { }

        public override void Fight(Player player)
        {
            base.Fight(player);
            Health += 10;
        }
    }
}
