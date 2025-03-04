using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vlastni_hra
{
    internal class NPC
    {
        public string name;
        public int addedDamage;
        public int addedHealth;
        public int partnership;
        public int index;

        public NPC(string name, int addedDamage, int addedHealth, int partnership, int index)
        {
            this.name = name;
            this.addedDamage = addedDamage;
            this.addedHealth = addedHealth;
            this.partnership = partnership;
            this.index = index;
        }
    }
}
