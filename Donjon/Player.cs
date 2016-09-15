using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donjon
{
    class Player
    {
        private int health; // backing field for Health
        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        public int X { get; set; }
        public int Y { get; set; }

        public bool HasSword { get; private set; }
        public int Damage
        {
            get { return HasSword ? 30 : 10; }
        }

        public LimitedList<Item> Backpack { get; } = new LimitedList<Item>(2);

        public Player(int health)
        {
            this.health = health;            
        }

        public void Fight(Monster monster)
        {
            monster.Health -= Damage;
        }

        public bool PickUp(Item item)
        {
            if (item is Sword && !HasSword)
            {
                HasSword = true;
                return true;
            }
            return Backpack.Add(item);
        }
    }
}