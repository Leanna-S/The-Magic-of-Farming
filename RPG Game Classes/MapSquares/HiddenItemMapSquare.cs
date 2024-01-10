using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game_Classes.MapSquares
{
    public class HiddenItemMapSquare : IMapSquare
    {
        public Color Color { get; set; }

        public RPGGame Game { get; set; }

        public int X { get; init; }
        public int Y { get; init; }

        public Equipment HiddenItem { get; set; }

        private bool _equipmentFound = false;

        public void MapAction()
        {
            // give player item if it has not been found
            if (!_equipmentFound)
            {
                Output.AddDialogs($"You have found something!", HiddenItem.ToString(), "You can select it in your inventory!!");
                Game.Player.Equipment.Add(HiddenItem);
                _equipmentFound = true;
            }
        }

        public HiddenItemMapSquare(RPGGame game, int x, int y, Equipment hiddenItem)
        {
            Random rng = new();

            switch (rng.Next(3))
            {
                case 0:
                    Color = Color.Green;
                    break;

                case 1:
                    Color = Color.ForestGreen;
                    break;

                case 2:
                    Color = Color.LimeGreen;
                    break;
            }
            Game = game;
            X = x;
            Y = y;
            HiddenItem = hiddenItem;
        }

        public override string ToString()
        {
            return " ";
        }
    }
}