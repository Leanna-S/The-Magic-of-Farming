using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Drawing;

namespace RPG_Game_Classes.FarmFields
{
    public enum GrowthStage
    {
        Dirt = 0,
        Sprout = 1,
        Seedling = 2,
        Filling = 3,
        Budding = 4,
        FullyGrown = 5
    }

    public class PlayerFarmField : FarmField
    {
        public GrowthStage GrowthStage { get; set; }
        public Player Player { get; init; }

        //timer for field growth
        private readonly System.Timers.Timer _growthTimer = new System.Timers.Timer();

        private bool _inDuel = false;

        // simple constants for easy modification
        private static readonly int _harvestExperienceAmount = 200;

        private static readonly int _harvestMoneyAmount = 5;

        // basically turns growth and harvesting off/on whether you are in a duel
        public void InDuel()
        {
            _inDuel = true;
            _growthTimer.Stop();
            SetColorByHealth();
        }

        public void NotInDuel()
        {
            _inDuel = false;
            SetColorByGrowth();
            _growthTimer.Start();
        }

        public PlayerFarmField(int maxHealth, Player player) : base(maxHealth)
        {
            Player = player;
            GrowthStage = 0;
            // basically sets of an event every 2000ms that will grow the field
            _growthTimer.Elapsed += new ElapsedEventHandler(GrowField);
            _growthTimer.Interval = 2000;
            _growthTimer.Enabled = true;
        }

        public void SetColorByGrowth()
        {
            //uses growth stage for color
            switch (GrowthStage)
            {
                case GrowthStage.Dirt:
                    Color = Color.SaddleBrown;
                    break;

                case GrowthStage.Sprout:
                    Color = Color.Lime;
                    break;

                case GrowthStage.Seedling:
                    Color = Color.LimeGreen;
                    break;

                case GrowthStage.Filling:
                    Color = Color.ForestGreen;
                    break;

                case GrowthStage.Budding:
                    Color = Color.Olive;
                    break;

                case GrowthStage.FullyGrown:
                    Color = Color.Gold;
                    break;

                default:
                    Color = Color.SaddleBrown;
                    break;
            }
        }

        public void HarvestField()
        {
            if (_inDuel)
            {
                _growthTimer.Stop();
                throw new InvalidOperationException("Cannot harvest field while in duel");
            }
            if (GrowthStage != GrowthStage.FullyGrown)
            {
                throw new InvalidOperationException("Cannot harvest field - not fully grown yet!");
            }

            Output.AddDialogs($"Successfully harvested crops! +{_harvestExperienceAmount}exp, +{_harvestMoneyAmount} coins");

            // reset growth
            GrowthStage = GrowthStage.Dirt;
            // set the color
            SetColorByGrowth();
            //restart growth timer
            _growthTimer.Start();

            //get bonuses
            Player.Money += _harvestMoneyAmount;
            Player.AddExperience(_harvestExperienceAmount);
        }

        private void GrowField(object? sender, ElapsedEventArgs e)
        {
            // stop timer if at last growth stage
            if (GrowthStage == GrowthStage.FullyGrown)
            {
                _growthTimer.Stop();
            }
            else
            {
                GrowthStage++;
            }

            SetColorByGrowth();
        }
    }
}