using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game_Classes.MoveActions
{
    public class MoveRight : PlayerMovementAction, IPlayerMovement
    {
        public MoveRight(Player player, RPGGame game) : base(player, game)
        {
        }

        public void MovePlayer()
        {
            MovePlayerBase(true, Game.Map.GetLength(1) - 1, 1);
        }
    }
}