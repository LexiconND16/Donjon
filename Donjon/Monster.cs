using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donjon
{
    interface IRegenerating {
        void Regenerate();
    }

    class Monster
    {
        private int health;
        public int Health
        {
            get { return health; }
            set { health = Math.Min(value, MaxHealth); }
        }

        public string MapSymbol { get; }
        public string Name { get; }

        protected int MaxHealth;
        protected int Damage = 20;

        public Monster(string mapSymbol, string name, int maxHealth)
        {
            MapSymbol = mapSymbol;
            Name = name;
            MaxHealth = maxHealth;
            Health = maxHealth;
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
        public Orc() : base("O", "orc", 40)
        {
            Damage = 40;
        }
    }
    class Troll : Monster, IRegenerating
    {
        public Troll() : base("T", "troll", 50) { }
        
        public void Regenerate()
        {
            Health += 2;
        }
    }
}
