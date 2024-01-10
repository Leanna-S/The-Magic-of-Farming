using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game_Classes.MoveActions
{
    public class MoveDown : PlayerMovementAction, IPlayerMovement
    {
        public MoveDown(Player player, RPGGame game) : base(player, game)
        {
        }

        public void MovePlayer()
        {
            MovePlayerBase(false, Game.Map.GetLength(0) - 1, 1);
        }
    }
}