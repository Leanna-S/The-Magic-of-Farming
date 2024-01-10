using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game_Classes.MoveActions
{
    public class MoveLeft : PlayerMovementAction, IPlayerMovement
    {
        public MoveLeft(Player player, RPGGame game) : base(player, game)
        {
        }

        public void MovePlayer()
        {
            MovePlayerBase(true, 0, -1);
        }
    }
}