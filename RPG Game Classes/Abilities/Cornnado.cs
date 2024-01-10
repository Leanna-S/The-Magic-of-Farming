using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game_Classes.Abilities
{
    public class Cornnado : Ability, IAbility
    {
        public Cornnado(bool selected) : base(4, "Corn-Nado", "Summon a tornado made of corm that will randomly throw debris that will leave your opponents saying: 'Aww, shucks'", 60, selected)
        {
        }

        public void PerformAbility(IPerson attacker, IPerson defender)
        {
            try
            {
                Random rng = new();
                var aliveFields = defender.Fields.Where((field) => !field.IsDead).ToList();
                int attackAmount = GetTotalPower(attacker);
                int attacks = 0;
                do
                {
                    aliveFields[rng.Next(aliveFields.Count)].TakeDamage(attackAmount);
                    attacks++;
                } while (rng.Next(10 - attacks) != 0);
                Output.AddDialogs($"Attacked {attacks} time(s) for {attacks}");
            }
            catch (Exception ex)
            {
                Output.AddDialogs(ex.Message);
            }
        }
    }
}