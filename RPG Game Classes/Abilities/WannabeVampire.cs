using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game_Classes.Abilities
{
    public class WannabeVampire : Ability, IAbility
    {
        public WannabeVampire(bool selected) : base(4, "Wannabe Vampire", "Steal some of your opponents field seeds for yourself, healing three farms of yours while damaging and weakening your opponent", 45, selected)
        {
        }

        public void PerformAbility(IPerson attacker, IPerson defender)
        {
            try
            {
                Random rng = new Random();
                var aliveFieldsDefender = defender.Fields.Where((field) => !field.IsDead).ToList();
                var aliveFieldsAttacker = attacker.Fields.Where((field) => !field.IsDead).ToList();

                int attackAmount = GetTotalPower(attacker);

                for (int i = 0; i < 3; i++)
                {
                    int randomDefender = rng.Next(aliveFieldsDefender.Count);
                    aliveFieldsDefender[randomDefender].TakeDamage(attackAmount);
                    aliveFieldsDefender[randomDefender].DebuffDefence(attackAmount / 5);
                    aliveFieldsAttacker[rng.Next(aliveFieldsAttacker.Count)].RecoverHealth(attackAmount);
                }
                Output.AddDialogs($"Attacked 3 times for {attackAmount}, debuffed 3 times for {attackAmount / 5}, gained health 3 times for {attackAmount}");
            }
            catch (Exception ex)
            {
                Output.AddDialogs(ex.Message);
            }
        }
    }
}