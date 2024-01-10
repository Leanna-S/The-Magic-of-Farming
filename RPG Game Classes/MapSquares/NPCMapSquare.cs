using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game_Classes.MapSquares
{
    public class NPCMapSquare : IMapSquare
    {
        public Color Color { get; set; }
        public NPC NPC { get; set; }
        public RPGGame Game { get; set; }

        public int X { get; init; }
        public int Y { get; init; }

        public NPCMapSquare(NPC npc, RPGGame game, int x, int column)
        {
            Color = Color.DarkBlue;
            NPC = npc;
            Game = game;
            X = x;
            Y = column;
        }

        public void MapAction()
        {
            // request a duel
            if (NPC.HasBeenDefeated)
            {
                Output.AddDialogs([$"Name: {NPC.Name}", $"Level: {NPC.Level}", " ", .. NPC.AfterDefeatDialogs]);
            }
            else
            {
                Output.AddDialogs([$"Name: {NPC.Name}", $"Level: {NPC.Level}", " ", .. NPC.BeforeDefeatDialogs]);
            }

            Game.RequestDuel(NPC);
        }

        public override string ToString()
        {
            return " ";
        }
    }
}