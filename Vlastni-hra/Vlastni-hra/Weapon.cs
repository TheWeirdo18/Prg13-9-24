using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vlastni_hra
{
    internal class Weapon
    {
        public string name;
        public string type;
        public int baseDamage;
        public int damage;
        public int level;
        public int price;
        public int owned;
        public int index;

        public Weapon(string name, string type, int baseDamage, int level, int price, int owned, int index)
        {
            this.name = name;
            this.type = type;
            this.baseDamage = baseDamage;
            damage = this.baseDamage + (level + 1);
            this.level = level;
            this.price = price;
            this.owned = owned;
            this.index = index;
        }
        public int DoDamage()
        {
            return damage;
        }
    }
}
