using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game_Classes.MapSquares
{
    public class EmptyMapSquare : IMapSquare
    {
        public Color Color { get; set; }

        public RPGGame Game { get; set; }

        public int X { get; init; }
        public int Y { get; init; }

        public void MapAction()
        {
        }

        public EmptyMapSquare(RPGGame game, int x, int y)
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
        }

        public override string ToString()
        {
            return " ";
        }
    }
}