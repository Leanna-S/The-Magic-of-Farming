using RPG_Game_Classes;
using RPG_Game_Classes.ShopItems;
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
    public partial class ShopPage : Form
    {
        public MainGamePage BaseForm { get; init; }
        public RPGGame Game { get; init; }

        public ShopPage(MainGamePage form)
        {
            // initialize form
            BaseForm = form;
            Game = BaseForm.Game;
            InitializeComponent();
            InitializeShop();
            MoneyLabel.Text = $"{Game.Player.Money.ToString("C2")}";
        }

        private void InitializeShop()
        {
            // update shop formatting
            ShopDataGridView.RowHeadersVisible = false;
            ShopDataGridView.DataSource = Game.Shop;
            ShopDataGridView.Columns["Game"].Visible = false;
            ShopDataGridView.Columns["Price"].DefaultCellStyle.Format = "C2";
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            // go bakc to base form and close page
            BaseForm.Show();
            this.Close();
        }

        private void ShopBuyButton_Click(object sender, EventArgs e)
        {
            // buy item from shop
            // get selected item
            IShopItem item = (IShopItem)ShopDataGridView.SelectedRows[0].DataBoundItem;
            Game.PurchaseFromShop(item);
            MoneyLabel.Text = Game.Player.Money.ToString("C2");
        }
    }
}