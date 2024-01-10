using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG_Game_Classes.Abilities;
using RPG_Game_Classes.FarmFields;

namespace RPG_Game_Classes
{
    public class NPC : Person, IPerson
    {
        public string[] AfterDefeatDialogs { get; init; }
        public string[] BeforeDefeatDialogs { get; init; }
        public int Level { get; set; }
        public bool HasBeenDefeated { get; set; }

        public Equipment EquippedItem { get; set; }

        public NPC(string name, int level, int strength, Equipment equippedItem, List<IAbility> abilities, string[] beforeDefeatDialogs, string[] afterDefeatDialogs) : base(name, _initialMana + level * _manaPerLevel, strength, abilities)
        {
            BeforeDefeatDialogs = beforeDefeatDialogs;
            AfterDefeatDialogs = afterDefeatDialogs;
            HasBeenDefeated = false;
            Level = level;
            EquippedItem = equippedItem;
            for (int i = 1; i <= Level + _initialFarms; i++)
            {
                Fields.Add(new FarmField(_farmHealthPerStrength * Strength));
            }
        }

        public IAbility GetAbility()
        {
            Random rng = new();
            return Abilities[rng.Next(Abilities.Count)];
        }
    }
}