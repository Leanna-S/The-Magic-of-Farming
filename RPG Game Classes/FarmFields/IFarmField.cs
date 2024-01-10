using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game_Classes.FarmFields
{
    public interface IFarmField
    {
        public int MaxHealth { get; set; }
        public int Health { get; set; }
        public bool IsDead { get; set; }
        public int DefenceModifier { get; set; }
        public Color Color { get; set; }

        //event for when color changed

        public event EventHandler? ColorChanged;

        public void OnColorChanged(EventArgs e);

        public void RecoverHealth(int amount);

        public void TakeDamage(int amount);

        public void BuffDefence(int amount);

        public void DebuffDefence(int amount);

        public void SetColorByHealth();
    }
}