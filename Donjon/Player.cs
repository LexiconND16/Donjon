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

        public Player(int health)
        {
            this.health = health;
        }

        public void Fight(Monster monster) {
            monster.Health -= 20;
        }
    }
}