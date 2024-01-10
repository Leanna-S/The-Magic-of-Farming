using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game_Classes.Abilities
{
    public class BurningDay : Ability, IAbility
    {
        public BurningDay(bool selected) : base(1, "Burning Day", "Summon a phoenix to cry tears upon the soil and revive up to three farms with mimimal health", 100, selected)
        {
        }

        public void PerformAbility(IPerson attacker, IPerson defender)
        {
            try
            {
                Random rng = new Random();
                int revivedFields = 0;

                int healAmount = GetTotalPower(attacker);
                do
                {
                    var deadFields = attacker.Fields.Where((field) => field.IsDead).ToList();
                    if (deadFields.Count > 0)
                    {
                        var field = deadFields[rng.Next(deadFields.Count)];
                        field.IsDead = false;
                        field.RecoverHealth(healAmount);
                        revivedFields++;
                    }
                    else
                    {
                        throw new InvalidOperationException("No fields left to revive!");
                    }
                } while (rng.Next(2) != 0 && revivedFields < 3);
                Output.AddDialogs($"Revived and healed {revivedFields} field(s) for {healAmount}");
            }
            catch (Exception ex)
            {
                Output.AddDialogs(ex.Message);
            }
        }
    }
}