using RPG_Game_Classes;
using RPG_Game_Classes.MapSquares;
using RPG_Game_Classes.ShopItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game_Tests
{
    public class RPGTests
    {
        private RPGGame _game = new("Leanna");

        [Fact]
        public void RPG_CreateMap_CreatesValidMap()
        {
            IMapSquare[,] map = _game.CreateMap(10, 15);
            Assert.NotNull(map);
            Assert.Equal(10, map.GetLength(0));
            Assert.Equal(15, map.GetLength(1));
        }

        [Fact]
        public void RPG_CreateMap_OnSmallMap_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => { IMapSquare[,] map = _game.CreateMap(4, 2); });
        }

        [Fact]
        public void RPG_PurchaseFromShop_BuysItemCorrectly()
        {
            _game.Player.Money = 100;
            EquipmentShopItem item = (EquipmentShopItem)_game.Shop[0];
            _game.PurchaseFromShop(item);
            Assert.Equal(100 - item.Price, _game.Player.Money);
            Assert.Contains(item.Equipment, _game.Player.Equipment);
        }

        [Fact]
        public void RPG_PurchaseFromShop_NotEnoughMoney_DoesNotPurchase()
        {
            _game.Player.Money = 10;
            EquipmentShopItem item = (EquipmentShopItem)_game.Shop[0];

            Assert.Equal(10, _game.Player.Money);
            Assert.DoesNotContain(item.Equipment, _game.Player.Equipment);
        }
    }
}