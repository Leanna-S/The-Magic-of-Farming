using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game_Classes.MoveActions
{
    public class MoveUp : PlayerMovementAction, IPlayerMovement
    {
        public MoveUp(Player player, RPGGame game) : base(player, game)
        {
        }

        public void MovePlayer()
        {
            MovePlayerBase(false, 0, -1);
        }
    }
}