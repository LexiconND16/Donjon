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

            do
            {
                // get input from player
                // process input
                // print map
            } while (player.Health > 0);

            // game over
        }
    }
}