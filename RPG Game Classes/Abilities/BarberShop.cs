using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG_Game_Classes.FarmFields;

namespace RPG_Game_Classes.Abilities
{
    public class BarberShop : Ability, IAbility
    {
        public BarberShop(bool selected) : base(1, "Barber Shop", "Give all your opponents farms a trim", 50, selected)
        {
        }

        public void PerformAbility(IPerson attacker, IPerson defender)
        {
            try
            {
                var aliveFields = defender.Fields.Where((field) => !field.IsDead).ToList();
                int attackAmount = GetTotalPower(attacker);
                foreach (IFarmField field in aliveFields)
                {
                    field.TakeDamage(attackAmount);
                }
                Output.AddDialogs($"Attacked all fields for {attackAmount}");
            }
            catch (Exception ex)
            {
                Output.AddDialogs(ex.Message);
            }
        }
    }
}