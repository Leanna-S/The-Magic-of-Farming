using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG_Game_Classes.FarmFields;

namespace RPG_Game_Classes.Abilities
{
    public class PumpkinPatchUp : Ability, IAbility
    {
        public PumpkinPatchUp(bool selected) : base(3, "Pumpkin Patch-Up", "Heal all farms", 60, selected)
        {
        }

        public void PerformAbility(IPerson attacker, IPerson defender)
        {
            try
            {
                var aliveFields = attacker.Fields.Where((field) => !field.IsDead).ToList();
                int healAmount = GetTotalPower(attacker);
                foreach (IFarmField field in aliveFields)
                {
                    field.DebuffDefence(healAmount);
                }
                Output.AddDialogs($"Healed all fields for {healAmount}");
            }
            catch (Exception ex)
            {
                Output.AddDialogs(ex.Message);
            }
        }
    }
}