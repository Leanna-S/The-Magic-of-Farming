using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG_Game_Classes.FarmFields;

namespace RPG_Game_Classes.Abilities
{
    public class Every17Years : Ability, IAbility
    {
        public Every17Years(bool selected) : base(4, "Every 17 Years", "Summon a swarm of cicadas to make it easier to damage your opponents farm", 40, selected)
        {
        }

        public void PerformAbility(IPerson attacker, IPerson defender)
        {
            try
            {
                var aliveFields = defender.Fields.Where((field) => !field.IsDead).ToList();
                int enemyDebuff = GetTotalPower(attacker) / 5;
                foreach (IFarmField field in aliveFields)
                {
                    field.DebuffDefence(enemyDebuff);
                }
                Output.AddDialogs($"Debuffed defence of all fields by {enemyDebuff}");
            }
            catch (Exception ex)
            {
                Output.AddDialogs(ex.Message);
            }
        }
    }
}