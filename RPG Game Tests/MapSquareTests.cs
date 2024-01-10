using RPG_Game_Classes;
using RPG_Game_Classes.MapSquares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game_Tests
{
    public class MapSquareTests
    {
        private RPGGame _game = new("Leanna");

        [Fact]
        public void HiddenItemMapSquare_MapAction_GivesItem()
        {
            var result = _game.Map.OfType<HiddenItemMapSquare>();
            if (result.FirstOrDefault() != null)
            {
                result.First().MapAction();
                Assert.Contains(result.First().HiddenItem, _game.Player.Equipment);
            }
            else
            {
                Assert.Fail("No map item found");
            }
        }
    }
}