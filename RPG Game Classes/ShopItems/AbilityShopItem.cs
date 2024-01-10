using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG_Game_Classes.Abilities;

namespace RPG_Game_Classes.ShopItems
{
    public class AbilityShopItem : IShopItem
    {
        public string Type { get; init; }
        public IAbility Ability { get; init; }
        public string Details { get; init; }
        public int Price { get; set; }
        public RPGGame Game { get; init; }

        public AbilityShopItem(RPGGame game, int price, IAbility ability)
        {
            Game = game;
            Price = price;
            Ability = ability;

            Details = Ability.ToString() ?? "";
            Type = "Ability";
        }

        public void Purchase()
        {
            Output.AddDialogs($"Bought {Ability.Name} for {Price} coins");
            Game.Player.Abilities.Add(Ability);
        }
    }
}