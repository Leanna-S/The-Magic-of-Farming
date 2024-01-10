using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace RPG_Game_Classes.FarmFields
{
    public class FarmField : IFarmField
    {
        public int MaxHealth { get; set; }
        public int _health;

        public int Health
        {
            get { return _health; }
            set
            {
                if (_health != value)
                {
                    _health = value;
                    SetColorByHealth();
                }
            }
        }

        public bool IsDead { get; set; }
        public int DefenceModifier { get; set; }

        public event EventHandler? ColorChanged;

        public void OnColorChanged(EventArgs e)
        {
            if (ColorChanged != null)
            {
                ColorChanged(this, e);
            }
        }

        private Color _color;

        public Color Color
        {
            get { return _color; }
            set
            {
                if (_color != value)
                {
                    _color = value;
                    OnColorChanged(new EventArgs());
                }
            }
        }

        public void SetColorByHealth()
        {
            // gets % of health and sets color appropriatly
            int percent = (int)(Health / (decimal)MaxHealth * 100);

            if (IsDead)
            {
                Color = Color.Black;
            }
            else if (percent < 15)
            {
                Color = Color.SaddleBrown;
            }
            else if (percent < 30)
            {
                Color = Color.Lime;
            }
            else if (percent < 45)
            {
                Color = Color.LimeGreen;
            }
            else if (percent < 60)
            {
                Color = Color.ForestGreen;
            }
            else if (percent < 75)
            {
                Color = Color.Olive;
            }
            else
            {
                Color = Color.Gold;
            }
        }

        public FarmField(int maxHealth)
        {
            MaxHealth = maxHealth;
            Health = MaxHealth;
            IsDead = false;
            Color = Color.SaddleBrown;
            DefenceModifier = 0;
        }

        public void TakeDamage(int amount)
        {
            // take damage minus the defence modifier
            amount -= DefenceModifier;

            if (amount < 0)
            {
                amount = 0;
            }

            if (Health - amount <= 0)
            {
                IsDead = true;
                Health = 0;
            }
            else
            {
                Health -= amount;
            }
        }

        public void RecoverHealth(int amount)
        {
            // adds health unless field is dead, in which case, cannot heal
            if (!IsDead)
            {
                if (Health + amount > MaxHealth)
                {
                    Health = MaxHealth;
                }
                else
                {
                    Health += amount;
                }
            }
            else
            {
                throw new InvalidOperationException("Cannot recover health, field is dead!");
            }
        }

        // adds or subtracts defence
        public void BuffDefence(int amount)
        {
            DefenceModifier += amount;
        }

        public void DebuffDefence(int amount)
        {
            DefenceModifier -= amount;
        }

        public override string ToString()
        {
            return " ";
        }
    }
}