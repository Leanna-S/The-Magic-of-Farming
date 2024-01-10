using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG_Game_Classes.Abilities;
using RPG_Game_Classes.FarmFields;

namespace RPG_Game_Classes
{
    public abstract class Person
    {
        public string Name { get; set; }

        public int MaximumMana { get; set; }

        private int _currentMana;

        public int CurrentMana
        {
            get
            {
                return _currentMana;
            }
            set
            {
                if (_currentMana != value)
                {
                    _currentMana = value;
                    OnManaChanged(new EventArgs());
                }
            }
        }

        public int Strength { get; set; }

        public List<IAbility> Abilities { get; set; }

        public BindingList<IFarmField> Fields { get; set; }

        public event EventHandler? ManaChanged;

        protected static readonly int _initialFarms = 5;
        protected static readonly int _farmHealthPerStrength = 10;
        protected static readonly int _initialMana = 100;
        protected static readonly int _manaPerLevel = 10;

        public void OnManaChanged(EventArgs e)
        {
            if (ManaChanged != null)
            {
                ManaChanged(this, e);
            }
        }

        public Person(string name, int maximumMana, int strength, List<IAbility> abilities)
        {
            Name = name;
            MaximumMana = maximumMana;
            CurrentMana = maximumMana;
            Strength = strength;

            Abilities = abilities;
            Fields = new();
        }

        public void DecreaseMana(int amount)
        {
            if (CurrentMana - amount < 0)
            {
                CurrentMana = 0;
                return;
            }
            CurrentMana -= amount;
        }

        public void IncreaseMana(int amount)
        {
            if (CurrentMana + amount > MaximumMana)
            {
                CurrentMana = MaximumMana;
                return;
            }
            CurrentMana += amount;
        }
    }
}