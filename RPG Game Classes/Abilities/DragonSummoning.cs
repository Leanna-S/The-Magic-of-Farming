using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG_Game_Classes.FarmFields;

namespace RPG_Game_Classes.Abilities
{
    public class DragonSummoning : Ability, IAbility
    {
        public DragonSummoning(bool selected) : base(8, "Dragon Summoning", "Summon a dragon that will burn your enemies fields with a 75% chance of backfiring. If unsuccessful, lights one of your fields on fire", 80, selected)
        {
        }

        public void PerformAbility(IPerson attacker, IPerson defender)
        {
            try
            {
                Random rng = new Random();
                var aliveFieldsDefender = defender.Fields.Where((field) => !field.IsDead).ToList();
                var aliveFieldsAttacker = attacker.Fields.Where((field) => !field.IsDead).ToList();

                // summon
                if (rng.Next(4) == 0)
                {
                    Output.AddDialogs($"Spell successful!");
                    int attackAmount = GetTotalPower(attacker);

                    foreach (IFarmField field in aliveFieldsDefender)
                    {
                        field.TakeDamage(attackAmount);
                    }
                    Output.AddDialogs($"Attacked all fields for {attackAmount}");
                }
                // backfire
                else
                {
                    Output.AddDialogs($"Spell backfired!");
                    int attackAmount = GetTotalPower(attacker);
                    aliveFieldsAttacker[rng.Next(aliveFieldsAttacker.Count)].TakeDamage(attackAmount);
                    Output.AddDialogs($"Attacked 1 field for {attackAmount}");
                }
            }
            catch (Exception ex)
            {
                Output.AddDialogs(ex.Message);
            }
        }
    }
}