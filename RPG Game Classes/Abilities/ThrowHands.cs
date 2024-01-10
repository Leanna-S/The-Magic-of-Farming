using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game_Classes.Abilities
{
    public class ThrowHands : Ability, IAbility
    {
        public ThrowHands(bool selected) : base(1, "Throw Hands", "You rip out part of a field with your bare hands", 10, selected)
        {
        }

        public void PerformAbility(IPerson attacker, IPerson defender)
        {
            try
            {
                Random rng = new Random();

                int attackAmount = GetTotalPower(attacker);
                defender.Fields[rng.Next(defender.Fields.Count)].TakeDamage(attackAmount);
                Output.AddDialogs($"Attacked 1 time for {attackAmount}");
            }
            catch (Exception ex)
            {
                Output.AddDialogs(ex.Message);
            }
        }
    }
}