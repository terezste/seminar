using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class Player
    {
        private int health;
        public int damage;

        public Player(int health, int damage)
        {
            SetHealth(health);
            this.damage = damage;
        }

        public Player()
        {
            health = 100;
            damage = 20;
        }

        public void SetHealth(int value)
        {
            health = value;
            if (health < 0)
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

        public void Hurt(int amount)
        {
            health -= amount;
            Console.WriteLine("Player got hit for " + amount + " damage");
            if (health <= 0)
            {
                Console.WriteLine("Player is dead");
            }
        }
        public bool IsDead()
        {
            return health <= 0;
        }
    }
}
