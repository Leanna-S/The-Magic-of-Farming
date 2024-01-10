using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game_Classes.Abilities
{
    public class HolyCornyWheatpire : Ability, IAbility
    {
        public HolyCornyWheatpire(bool selected) : base(4, "Holy Corny Wheatpire", "Ask for the gods to heal one of your fields... for the good of the Holy Corny Empire", 25, selected)
        {
        }

        public void PerformAbility(IPerson attacker, IPerson defender)
        {
            try
            {
                var lowestHealthField = attacker.Fields.Where((field) => !field.IsDead).MinBy((field) => field.Health);
                if (lowestHealthField == null)
                {
                    throw new ArgumentNullException("Couldn't get lowest health field");
                }
                int healAmount = GetTotalPower(attacker);
                lowestHealthField.RecoverHealth(healAmount);
                Output.AddDialogs($"Healed 1 time for {healAmount}");
            }
            catch (Exception ex)
            {
                Output.AddDialogs(ex.Message);
            }
        }
    }
}