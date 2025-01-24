using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class
{
    internal class Enemy
    {
        int healthBase;
        int health;
        int damageBase;
        int damage;
        int level;
        Random rng;

        public Enemy (int healthBase, int damageBase, int level)
        {
            int health = healthBase * level;
            int damage = damageBase * level;
            this.level = rng.Next(0,5);
        }

        public int GetHealth()
        {
            return health;
        }

        public int GetDamage()
        {
            return damage;
        }

        public int GetRandomizedDamage()
        {
            return rng.Next(damage / 2, damage + 1);
        }

        public void Hurt(int amount)
        {
            health -= amount;
            Console.WriteLine("The enemy took " + amount + " damage");
            if (health <= 0)
            {
                Console.WriteLine("The enemy is dead");
            }
        }

        public bool IsDead()
        {
            return health <= 0;
        }

    }
}
