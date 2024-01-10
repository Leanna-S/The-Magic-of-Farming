using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game_Classes.MoveActions
{
    public interface IPlayerMovement
    {
        public RPGGame Game { get; init; }

        public void MovePlayer();
    }
}