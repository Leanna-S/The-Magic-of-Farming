using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG_Game_Classes.MapSquares;

namespace RPG_Game_Classes.MoveActions
{
    public abstract class PlayerMovementAction
    {
        public Player Player { get; init; }
        public RPGGame Game { get; init; }

        public PlayerMovementAction(Player player, RPGGame game)
        {
            Player = player;
            Game = game;
        }

        public void MovePlayerBase(bool affectsX, int stopPoint, int change)
        {
            // if you go out of range
            if (affectsX && Player.X == stopPoint || !affectsX && Player.Y == stopPoint)
            {
                throw new InvalidOperationException("Cannot move. Will go out of bounds!");
            }
            else
            {
                // if in range, set the current cell with the cell the player is on
                PlayerMapSquare currentPlayerSquare = (PlayerMapSquare)Game.Map[Player.Y, Player.X];
                Game.Map[Player.Y, Player.X] = currentPlayerSquare.OriginalItem;
                // move X/Y of player depending on movement
                if (affectsX)
                {
                    Player.X += change;
                }
                else
                {
                    Player.Y += change;
                }
                // do the map action of the new square the player has landed on
                Game.Map[Player.Y, Player.X].MapAction();

                // then create new player square, storing current square
                Game.Map[Player.Y, Player.X] = new PlayerMapSquare(Player, Game.Map[Player.Y, Player.X], Game.Map[Player.Y, Player.X].Game, Player.X, Player.Y);
            }
        }
    }
}