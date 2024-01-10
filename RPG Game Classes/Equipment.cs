using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game_Classes
{
    public class Equipment
    {
        public string Name { get; init; }
        public int Power { get; init; }
        public string Description { get; init; }

        public int ManaRegeneration { get; init; }

        public Equipment(string name, int power, string description, int manaRegeneration)
        {
            Name = name;
            Power = power;
            Description = description;
            ManaRegeneration = manaRegeneration;
        }

        public override string ToString()
        {
            return $"{Name} - {Description} | Power: {Power} | Mana Regeneration: {ManaRegeneration}";
        }
    }
}