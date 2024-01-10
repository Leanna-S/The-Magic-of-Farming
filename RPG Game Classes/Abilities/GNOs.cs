using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG_Game_Classes.FarmFields;

namespace RPG_Game_Classes.Abilities
{
    public class GNOs : Ability, IAbility
    {
        public GNOs(bool selected) : base(6, "GNO's", "Use GNO's made by Geno on your farm to boost and heal your farm... or damage and destroy your farm. Has a 33% chance of backfiring.", 75, selected)
        {
        }

        public void PerformAbility(IPerson attacker, IPerson defender)
        {
            try
            {
                Random rng = new Random();

                var aliveFieldsAttacker = attacker.Fields.Where((field) => !field.IsDead).ToList();

                // buff
                if (rng.Next(3) != 0)
                {
                    Output.AddDialogs("Spell successful!");
                    int defenceBuff = GetTotalPower(attacker) / 5;
                    int healAmount = GetTotalPower(attacker);
                    foreach (IFarmField field in aliveFieldsAttacker)
                    {
                        field.BuffDefence(defenceBuff);
                        field.RecoverHealth(healAmount);
                    }
                    Output.AddDialogs($"Healed all fields for {healAmount}, buffed all fields for {defenceBuff}");
                }
                //debuff
                else
                {
                    Output.AddDialogs("Spell backfired!");
                    int defenceDebuff = GetTotalPower(attacker) / 2 / 5;
                    int attackAmount = GetTotalPower(attacker) / 2;
                    foreach (IFarmField field in aliveFieldsAttacker)
                    {
                        field.DebuffDefence(defenceDebuff);

                        field.TakeDamage(attackAmount);
                    }
                    Output.AddDialogs($"Attacked all fields for {attackAmount}, debuffed all fields for {defenceDebuff}");
                }
            }
            catch (Exception ex)
            {
                Output.AddDialogs(ex.Message);
            }
        }
    }
}