using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game_Classes.ShopItems
{
    public class EquipmentShopItem : IShopItem
    {
        public string Type { get; init; }
        public string Details { get; init; }

        public Equipment Equipment { get; init; }
        public int Price { get; set; }
        public RPGGame Game { get; init; }

        public EquipmentShopItem(RPGGame game, int price, Equipment equipment)
        {
            Game = game;
            Price = price;
            Equipment = equipment;
            Details = Equipment.ToString();
            Type = "Equipment";
        }

        public void Purchase()
        {
            Output.AddDialogs($"Bought {Equipment.Name} for {Price} coins");
            Game.Player.Equipment.Add(Equipment);
        }
    }
}