using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class
{
    internal class Player
    {
        private int health;
        public int damage;
        public string name;
        private Random rng;

        public Player (int health, int damage, string name)
        {
            SetHealth(health);
            this.damage = damage;
            this.name = name;
        }

        public void SetHealth(int value)
        {
            health = value;
            if (health > 0)
            {
                health = 0;
            }
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
            float randomizedDamage = damage * rng.Next(5, 15) / 10;
            return (int) randomizedDamage;
        }

        public void Hurt(int amount)
        {
            health -= amount;
            Console.WriteLine("The player took " + amount + " damage");
            if (health <= 0)
            {
                Console.WriteLine("The player is dead");
            }
        }

        public bool IsDead()
        {
            /* To same
            if (health <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }*/

            return health <= 0;
        }


    }
}
