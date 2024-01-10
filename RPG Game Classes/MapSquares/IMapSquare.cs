using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game_Classes.MapSquares
{
    public interface IMapSquare
    {
        public Color Color { get; set; }
        public RPGGame Game { get; set; }

        public int X { get; init; }
        public int Y { get; init; }

        public void MapAction();
    }
}