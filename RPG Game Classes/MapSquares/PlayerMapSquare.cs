using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game_Classes.MapSquares
{
    public class PlayerMapSquare : IMapSquare
    {
        public Color Color { get; set; }
        public Player Player { get; set; }
        public RPGGame Game { get; set; }

        public int X { get; init; }
        public int Y { get; init; }

        public IMapSquare OriginalItem { get; init; }

        public PlayerMapSquare(Player player, IMapSquare originalItem, RPGGame game, int x, int y)
        {
            Player = player;
            Color = Color.Red;
            OriginalItem = originalItem;
            Game = game;
            X = x;
            Y = y;
        }

        public void MapAction()
        { }

        public override string ToString()
        {
            return " ";
        }
    }
}