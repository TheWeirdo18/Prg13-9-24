using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vlastni_hra
{
    internal class Player
    {
        public int baseHealth;
        public int health;
        public int baseDamage;
        public int damage;
        public int level;
        public string name;
        public int currentEXP;
        public int currentCoins;
        public int maxHealth;
        

        /*this.baseHealth = baseHealth;
            health = this.baseHealth + ((level - 1) * 1 / 2 * baseHealth);
            this.baseDamage = baseDamage;
            damage = this.baseDamage + (level - 1);*/
        
        public Player (int baseHealth, int baseDamage, int level, string name, int currentEXP, int currentCoins)
        {
            this.baseHealth = baseHealth;
            health = this.baseHealth + (level * 5);
            maxHealth = this.baseHealth + (level * 5);
            this.baseDamage = baseDamage;
            damage = this.baseDamage + (level + 1);
            this.level = level;
            this.name = name;
            this.currentEXP = currentEXP;
            this.currentCoins = currentCoins;
        }

        
        public int GetHealth()
        {
            return health;
        }
        public int DoDamage()
        {
            return damage;
        }

        public void LevelUp(int amount)
        {
            level += amount;
        }
        public void Hurt(int amount)
        {
            health -= amount;
            if (health <= amount)
            {
                Console.WriteLine("You got hit for " + amount + " damage by the enemy.");
                Console.WriteLine("You have died. Game Over.");
            }
            else
            {
                Console.WriteLine("You got hit for " + amount + " damage by the enemy.");
            }
        }
        public bool IsDead()
        {
            return health <= 0; 
        }
        public void GetExperience(int amount)
        {
            currentEXP += amount;
        }
        public void UseExperience(int amount)
        {
            currentEXP -= amount;
        }

        public void GainDMG(int amount)
        {
            damage += amount;
        }
        public void LoseDMG(int amount)
        {
            damage -= amount;
        }
        public void GainHealth(int amount)
        {
            health += amount;
        }
        public void LoseHealth(int amount)
        {
            health -= amount;
        }
        public void GetCoins(int amount)
        {
            currentCoins += amount;
        }
        public void UseCoins(int amount)
        {
            currentCoins -= amount;
        }
    }
}
