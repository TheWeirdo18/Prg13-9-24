using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vlastni_hra
{
    internal class BasicEnemy
    {
        public int baseHealth;
        public int health;
        public int baseDamage;
        public int damage;
        public int level;
        public string name;
        public int baseGainEXP;
        public int gainEXP;
        public int baseGainCoins;
        public int gainCoins;
        

        public BasicEnemy(int baseHealth, int baseDamage, int level, string name, int baseGainEXP, int baseGainCoins)
        {
            this.baseHealth = baseHealth;
            health = this.baseHealth + ((level - 1) * 1 / 2 * baseHealth);
            this.baseDamage = baseDamage;
            damage = this.baseDamage + (level - 1);
            this.level = level;
            this.name = name;
            this.baseGainEXP = baseGainEXP;
            gainEXP = this.baseGainEXP + ((level - 1) * 5);
            this.baseGainCoins = baseGainCoins;
            gainCoins = this.baseGainCoins + ((level - 1) * 5);
        }

        public int GetHealth()
        {
            return health;
        }       
        public int DoDamage()
        {
            return damage;
        }
        public int GainEXP()
        {
            return gainEXP;
        }
        public void Hurt(int amount)
        {            
            if (health <= amount)
            {
                health -= amount;
                Console.WriteLine("You hit the enemy for " + amount + " damage.");
                Console.WriteLine("The enemy has died. Good job!");
            }
            else
            {
                health -= amount;
                Console.WriteLine("You hit the enemy for " + amount + " damage.");
            }
        }        
        public bool IsDead()
        {
            return health <= 0;
        }
    }
}
