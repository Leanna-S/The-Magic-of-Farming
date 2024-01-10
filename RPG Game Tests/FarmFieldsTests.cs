using RPG_Game_Classes;
using RPG_Game_Classes.FarmFields;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game_Tests
{
    public class FarmFieldsTests
    {
        private RPGGame _game = new("Leanna");

        [Fact]
        public void FarmField_SetColorByHealth_WorksAsExpected()
        {
            _game.Player.Fields[0].TakeDamage(5);
            _game.Player.Fields[0].SetColorByHealth();
            Assert.Equal(Color.ForestGreen, _game.Player.Fields[0].Color);
        }

        [Fact]
        public void FarmField_TakeDamage_SubtractsHealthProperly()
        {
            _game.Player.Fields[0].TakeDamage(5);
            _game.Player.Fields[0].SetColorByHealth();
            Assert.Equal(Color.ForestGreen, _game.Player.Fields[0].Color);
        }

        [Fact]
        public void FarmField_TakeDamage_SubtractsAndKillsAtNoHealth()
        {
            _game.Player.Fields[0].TakeDamage(25);

            Assert.Equal(0, _game.Player.Fields[0].Health);
            Assert.True(_game.Player.Fields[0].IsDead);
        }

        [Fact]
        public void FarmField_TakeDamage_TakesDefenceModifierIntoAccount()
        {
            _game.Player.Fields[0].BuffDefence(2);
            _game.Player.Fields[0].TakeDamage(5);

            Assert.Equal(_game.Player.Fields[0].MaxHealth - 3, _game.Player.Fields[0].Health);
        }

        [Fact]
        public void FarmField_RecoverHealth_AddsHealthProperly()
        {
            _game.Player.Fields[0].TakeDamage(5);
            _game.Player.Fields[0].RecoverHealth(2);

            Assert.Equal(_game.Player.Fields[0].MaxHealth - 3, _game.Player.Fields[0].Health);
        }

        [Fact]
        public void FarmField_RecoverHealth_AddsHealthUntilAtMax()
        {
            _game.Player.Fields[0].TakeDamage(5);
            _game.Player.Fields[0].RecoverHealth(10);

            Assert.Equal(_game.Player.Fields[0].MaxHealth, _game.Player.Fields[0].Health);
        }

        [Fact]
        public void FarmField_RecoverHealth_FieldDead_ThrowsInvalidOperationException()
        {
            _game.Player.Fields[0].TakeDamage(50);

            Assert.Throws<InvalidOperationException>(() => { _game.Player.Fields[0].RecoverHealth(10); });
        }

        [Fact]
        public void FarmField_BuffDefence_AddDefenceProperly()
        {
            _game.Player.Fields[0].BuffDefence(5);
            Assert.Equal(5, _game.Player.Fields[0].DefenceModifier);
        }

        [Fact]
        public void FarmField_DebuffDefence_RemoveDefenceProperly()
        {
            _game.Player.Fields[0].DebuffDefence(5);
            Assert.Equal(-5, _game.Player.Fields[0].DefenceModifier);
        }

        [Fact]
        public void PlayerFarmField_SetColorByGrowthStage_SetExpectedColor()
        {
            ((PlayerFarmField)_game.Player.Fields[0]).GrowthStage = GrowthStage.Filling;
            ((PlayerFarmField)_game.Player.Fields[0]).SetColorByGrowth();
            Assert.Equal(Color.ForestGreen, _game.Player.Fields[0].Color);
        }

        [Fact]
        public void PlayerFarmField_HarvestField_Valid_WorksAsExpected()
        {
            ((PlayerFarmField)_game.Player.Fields[0]).GrowthStage = GrowthStage.FullyGrown;
            ((PlayerFarmField)_game.Player.Fields[0]).HarvestField();
            Assert.Equal(5, _game.Player.Money);
            Assert.Equal(200, _game.Player.Experience);
            Assert.Equal(0, ((int)((PlayerFarmField)_game.Player.Fields[0]).GrowthStage));
        }

        [Fact]
        public void PlayerFarmField_HarvestField_NotFullyGrown_ThrowsInvalidOperationException()
        {
            ((PlayerFarmField)_game.Player.Fields[0]).GrowthStage = GrowthStage.Filling;
            Assert.Throws<InvalidOperationException>(() => { ((PlayerFarmField)_game.Player.Fields[0]).HarvestField(); });
        }

        [Fact]
        public void PlayerFarmField_HarvestField_WhileInDuel_ThrowsInvalidOperationException()
        {
            ((PlayerFarmField)_game.Player.Fields[0]).GrowthStage = GrowthStage.FullyGrown;
            ((PlayerFarmField)_game.Player.Fields[0]).InDuel();

            Assert.Throws<InvalidOperationException>(() => { ((PlayerFarmField)_game.Player.Fields[0]).HarvestField(); });
        }
    }
}