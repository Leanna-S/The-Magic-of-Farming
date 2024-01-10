using RPG_Game_Classes;
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
    public partial class TitlePage : Form
    {
        public TitlePage()
        {
            InitializeComponent();
        }

        private void NameSubmitButton_Click(object sender, EventArgs e)
        {
            try
            {
                // verify the name is valid
                if (TextVerification.VerifyName(NameInputTextBox.Text))
                {
                    // hide page and open main game
                    MainGamePage mainGame = new MainGamePage(NameInputTextBox.Text);

                    mainGame.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                // if not, show user the error
                ErrorLabel.Text = ex.Message;
            }
        }
    }
}