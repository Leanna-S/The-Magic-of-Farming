using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game_Classes.Abilities
{
    public class AttackOfTheCrows : Ability, IAbility
    {
        public AttackOfTheCrows(bool selected) : base(2, "Attack Of The Crows", "Summon crows to pick at three of your enemies farms", 30, selected)
        {
        }

        public void PerformAbility(IPerson attacker, IPerson defender)
        {
            try
            {
                Random rng = new Random();
                var aliveFields = defender.Fields.Where((field) => !field.IsDead).ToList();
                int attackAmount = GetTotalPower(attacker);
                for (int i = 0; i < 3; i++)
                {
                    aliveFields[rng.Next(aliveFields.Count)].TakeDamage(attackAmount);
                }
                Output.AddDialogs($"Attacked 3 times for {attackAmount}");
            }
            catch (Exception ex)
            {
                Output.AddDialogs(ex.Message);
            }
        }
    }
}