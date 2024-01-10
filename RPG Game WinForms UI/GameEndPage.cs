using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPG_Game_WinForms_UI
{
    public partial class GameEndPage : Form
    {
        public GameEndPage()
        {
            InitializeComponent();
            GameEndLabel.Text = "You have won! Maybe...\nYou won against everyone but...\nThey won't let you back into MITT\nIt'll be hard to accept but... you're okay with it.\nYou've started to like it here in Small Townville\nWith the delicious food... maybe being a magical farmer is a good thing.";
        }

        private void ExitProgramButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PlayAgainButton_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}