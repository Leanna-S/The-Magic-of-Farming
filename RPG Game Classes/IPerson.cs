using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using RPG_Game_Classes.Abilities;
using RPG_Game_Classes.FarmFields;

namespace RPG_Game_Classes
{
    public interface IPerson
    {
        public string Name { get; set; }

        public int Level { get; set; }
        public int MaximumMana { get; set; }
        public int CurrentMana { get; set; }
        public int Strength { get; set; }
        public Equipment EquippedItem { get; set; }
        public List<IAbility> Abilities { get; set; }

        public BindingList<IFarmField> Fields { get; set; }

        public void DecreaseMana(int amount);

        public void IncreaseMana(int amount);
    }
}