using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vlastni_hra
{
    internal class Food
    {
        public string name;
        public int addedHealth;
        public int amount;


        public Food(string name, int addedHealth, int amount)
        {
            this.name = name;
            this.addedHealth = addedHealth;     
            this.amount = amount;
        }

        public void Eaten(int eaten)
        {
            amount -= eaten;
        }
    }
}
