using System.Xml.Linq;

namespace RPG_Game_Classes.ShopItems
{
    public interface IShopItem
    {
        public string Type { get; init; }
        public int Price { get; set; }
        public string Details { get; init; }

        public RPGGame Game { get; init; }

        public void Purchase();
    }
}