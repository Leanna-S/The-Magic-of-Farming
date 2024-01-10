using RPG_Game_Classes.Abilities;
using RPG_Game_Classes.FarmFields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game_Classes
{
    public class Player : Person, IPerson
    {
        public int X { get; set; }

        public int Y { get; set; }
        public int Money { get; set; }
        public int ExperienceToNextLevel { get; private set; }
        private int _experience;

        private static readonly int _experienceMultiplierPerLevel = 1000;
        public Equipment EquippedItem { get; set; }

        public int Experience
        {
            get
            {
                return _experience;
            }
            private set
            {
                if (_experience != value)
                {
                    _experience = value;
                    OnExperienceChanged(new EventArgs());
                }
            }
        }

        private int _level;

        public int Level
        {
            get
            {
                return _level;
            }
            set
            {
                if (_level != value)
                {
                    // update experience on level
                    _level = value;
                    OnExperienceChanged(new EventArgs());
                }
            }
        }

        public List<Equipment> Equipment { get; set; }

        public event EventHandler? ExperienceChanged;

        public void OnExperienceChanged(EventArgs e)
        {
            if (ExperienceChanged != null)
            {
                ExperienceChanged(this, e);
            }
        }

        public Player(string name) : base(name, _initialMana + 1 * _manaPerLevel, 1, [new ThrowHands(true)])
        {
            Level = 1;
            X = 0;
            Y = 0;
            Experience = 0;
            Money = 0;
            Equipment = [new("Hands", 1, "For a simple wizard-turned-farmer", 0), new("A Stick", 1, "A stick you found on the ground", 0), new("Leaf", 1, "Won't really help you fight but it looks... like a leaf, honestly", 0), new("Sun Hat", 1, "You look dumb but at least it keeps the sun from your eyes", 0), new("Old Journal", 1, "'Dear diary, why am I still here just to suffer?'", 0)];
            EquippedItem = Equipment[0];
            ExperienceToNextLevel = _experienceMultiplierPerLevel * Level;
            for (int i = 1; i <= Level + _initialFarms; i++)
            {
                Fields.Add(new PlayerFarmField(_farmHealthPerStrength * Strength, this));
            }
        }

        private void LevelUp()
        {
            // level up player
            Experience = 0;
            Level++;
            Strength++;
            Fields.Add(new PlayerFarmField(Fields[0].MaxHealth, this));
            MaximumMana = _initialMana + _manaPerLevel * Level;

            foreach (IFarmField field in Fields)
            {
                field.MaxHealth = _farmHealthPerStrength * Strength;
            }
            Output.AddDialogs($"You leveled up! You are now level {Level}.");
        }

        public void AddExperience(int amount)
        {
            ExperienceToNextLevel = _experienceMultiplierPerLevel * Level;

            // if added experience will trigger a level up
            if (Experience + amount >= ExperienceToNextLevel)
            {
                // calculate experience after leveling
                int experienceAfterLeveling = amount - (ExperienceToNextLevel - Experience);
                LevelUp();

                // add the left over experience
                AddExperience(experienceAfterLeveling);
            }
            else
            {
                // otherwise just add experience
                Experience += amount;
            }
        }

        public int PercentOfLevelCompleted()
        {
            // get percent of level completed
            return (int)((decimal)Experience / (decimal)ExperienceToNextLevel * (decimal)100);
        }
    }
}