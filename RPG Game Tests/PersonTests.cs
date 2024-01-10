using RPG_Game_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game_Tests
{
    public class PersonTests
    {
        private RPGGame _game = new("Leanna");

        [Fact]
        public void Player_IncreaseMana_WorksCorrectly()
        {
            _game.Player.DecreaseMana(10);
            _game.Player.IncreaseMana(5);
            Assert.Equal(_game.Player.MaximumMana - 5, _game.Player.CurrentMana);
        }

        [Fact]
        public void Player_DecreaseMana_WorksCorrectly()
        {
            _game.Player.DecreaseMana(10);
            Assert.Equal(_game.Player.MaximumMana - 10, _game.Player.CurrentMana);
        }

        [Fact]
        public void Player_AddExpeience_AddsLevelsCorrectly()
        {
            _game.Player.AddExperience(1500);
            Assert.Equal(500, _game.Player.Experience);
            Assert.Equal(2, _game.Player.Level);
            Assert.Equal(2, _game.Player.Strength);
            Assert.Equal(2000, _game.Player.ExperienceToNextLevel);
            Assert.Equal(7, _game.Player.Fields.Count);
            Assert.Equal(20, _game.Player.Fields[0].MaxHealth);
        }

        [Fact]
        public void Player_PercentOfLevelCompleted_GivesCorrectPercent()
        {
            _game.Player.AddExperience(500);
            Assert.Equal(50, _game.Player.PercentOfLevelCompleted());
        }

        [Fact]
        public void NPC_GetAbility_ReturnsValidAbility()
        {
            Assert.Contains(_game.NPCs[0].GetAbility(), _game.NPCs[0].Abilities);
        }
    }
}