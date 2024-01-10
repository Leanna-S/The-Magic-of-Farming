using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG_Game_Classes.FarmFields;

namespace RPG_Game_Classes.Abilities
{
    public class BeesKnees : Ability, IAbility
    {
        public BeesKnees(bool selected) : base(4, "Bees Knees", "Summon a colony of bees to pollinate and protect all fields of your farm", 40, selected)
        {
        }

        public void PerformAbility(IPerson attacker, IPerson defender)
        {
            try
            {
                Random rng = new Random();
                var aliveFields = defender.Fields.Where((field) => !field.IsDead).ToList();
                int defenceBuff = GetTotalPower(attacker) / 5;
                foreach (IFarmField field in aliveFields)
                {
                    field.BuffDefence(defenceBuff);
                }
                Output.AddDialogs($"Buffed defence of all fields by {defenceBuff}");
            }
            catch (Exception ex)
            {
                Output.AddDialogs(ex.Message);
            }
        }
    }
}