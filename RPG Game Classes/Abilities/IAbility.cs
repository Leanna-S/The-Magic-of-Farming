using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game_Classes.Abilities
{
    public interface IAbility
    {
        public string Name { get; init; }
        public bool Selected { get; set; }
        public string Description { get; init; }
        public int BasePower { get; init; }
        public int ManaCost { get; init; }

        public void PerformAbility(IPerson attacker, IPerson defender);

        public bool CanAfford(IPerson attacker);
    }
}