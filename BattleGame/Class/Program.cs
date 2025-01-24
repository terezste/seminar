using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class
{
    internal class Program
    {
        static void Duel(Player player, Enemy enemy)
        {
            while (!player.IsDead() && !enemy.IsDead())
            {
                enemy.Hurt(player.GetRandomizedDamage());
                Console.WriteLine("Player health: " + player.GetHealth());

                if (!enemy.IsDead())
                {
                    player.Hurt(enemy.GetRandomizedDamage());
                    Console.WriteLine("Enemy health: " + enemy.GetHealth() + "\n");
                }
            }

            Console.ReadKey();
        }

        static void Main(string[] args)
        {

            Player player = new Player(100, 10, "Pepa");
            Enemy enemy = new Enemy(20, 2, 1);

            Duel(player, enemy);

            Enemy enemy2 = new Enemy(20, 2, 1);
            Duel(player, enemy2);

        }
    }
}
