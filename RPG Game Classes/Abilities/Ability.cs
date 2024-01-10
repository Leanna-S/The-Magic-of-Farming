using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game_Classes.Abilities
{
    // you are going to find some of the most interesting abilities
    // as each perform ability is custom!
    public abstract class Ability
    {
        public int BasePower { get; init; }
        public string Name { get; init; }
        public bool Selected { get; set; }
        public string Description { get; init; }
        public int ManaCost { get; init; }

        public Ability(int basePower, string name, string description, int manaCost, bool selected)
        {
            BasePower = basePower;
            Name = name;
            Description = description;
            Selected = selected;
            ManaCost = manaCost;
        }

        // determines the power of the ability (yes, its basically some random formula i made up but whatever)
        protected int GetTotalPower(IPerson person)
        {
            Random rng = new Random();
            return BasePower * rng.Next(person.Strength + person.EquippedItem.Power);
        }

        // determines whether you can afford the ability
        public bool CanAfford(IPerson attacker)
        {
            if (attacker.CurrentMana >= ManaCost)
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"{Name} - {Description} | Power: {BasePower} | Mana Cost: {ManaCost}";
        }
    }
}