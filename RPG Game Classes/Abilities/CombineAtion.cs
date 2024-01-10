using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG_Game_Classes.FarmFields;

namespace RPG_Game_Classes.Abilities
{
    public class CombineAtion : Ability, IAbility
    {
        public CombineAtion(bool selected) : base(2, "Combine-ation", "Attack and debuff your opponent, all with one mighty combine", 45, selected)
        {
        }

        public void PerformAbility(IPerson attacker, IPerson defender)
        {
            try
            {
                Random rng = new Random();
                var aliveFieldsDefender = defender.Fields.Where((field) => !field.IsDead).ToList();
                int attackAmount = GetTotalPower(attacker);
                int debuffAmount = GetTotalPower(attacker) / 5;
                foreach (IFarmField field in aliveFieldsDefender)
                {
                    field.DebuffDefence(debuffAmount);
                    field.TakeDamage(attackAmount);
                }
                Output.AddDialogs($"Attacked all fields for {attackAmount}, debuffed all fields for {debuffAmount}");
            }
            catch (Exception ex)
            {
                Output.AddDialogs(ex.Message);
            }
        }
    }
}