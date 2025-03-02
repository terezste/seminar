using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class Enemy
    {
        int healthBase;
        int health;
        int damageBase;
        int damage;

        public Enemy(int healthBase, int damageBase)
        {
            this.healthBase = healthBase;
            health = this.healthBase;

            this.damageBase = damageBase;
            damage = this.damageBase;
        }

        public void Hurt(int amount)
        {
            health -= amount;
            Console.WriteLine("Nepřítel utrpěl " + amount + " zranění.");
            if (health <= 0)
            {
                Console.WriteLine("Nepřítel je mrtvý.");
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
        public bool IsDead()
        {
            return health <= 0;
        }
    }

}
