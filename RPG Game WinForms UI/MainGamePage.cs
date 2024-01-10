using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Data;
using RPG_Game_Classes;
using System.Collections.Generic;
using System.Data.Common;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using RPG_Game_Classes.MapSquares;
using RPG_Game_Classes.FarmFields;
using RPG_Game_Classes.MoveActions;

namespace RPG_Game_WinForms_UI
{
    public partial class MainGamePage : Form
    {
        public MainGamePage(string playerName)
        {
            // initialize everythings
            Game = new(playerName);
            Map = Game.Map;
            FarmFields = Game.Player.Fields;
            InitializeComponent();
            InitializeMap();
            InitializeDialog();
            Game.StartGame();
            InitializeFarm(FarmDataGrid, Game.Player, RenderField);
            InitializePlayerStats();
            Game.GameEnded += Game_GameEnded;
        }

        private void Game_GameEnded(object? sender, EventArgs e)
        {
            // show end screen
            GameEndPage end = new();
            this.Hide();
            end.Show();
        }

        public RPGGame Game;
        public IMapSquare[,] Map;
        public BindingList<IFarmField> FarmFields;

        private void InitializePlayerStats()
        {
            // hok up events and data bind

            // experience bar
            Game.Player.ExperienceChanged += UpdateExperienceAndLevel;
            PlayerExperienceBar.Maximum = 100;
            PlayerExperienceBar.Value = (int)Game.Player.PercentOfLevelCompleted();

            // player name and level
            PlayerLevelLabel.Text = Game.Player.Level.ToString();
            PlayerNameLabel.Text = Game.Player.Name.ToString();

            // duel change event
            Game.DuelChange += Game_AskingToDuel;
        }

        private void Game_AskingToDuel(object? sender, EventArgs e)
        {
            // if there is a duel
            if (Game.CurrentDuel is not null)
            {
                // disable movement and show accept/reject button
                RightArrow.Enabled = false;
                LeftArrow.Enabled = false;
                UpArrow.Enabled = false;
                DownArrow.Enabled = false;
                AcceptDuel.Visible = true;
                RejectDuel.Visible = true;
            }
            else
            {
                // otherwise do the reverse
                RightArrow.Enabled = true;
                LeftArrow.Enabled = true;
                UpArrow.Enabled = true;
                DownArrow.Enabled = true;
                AcceptDuel.Visible = false;
                RejectDuel.Visible = false;
            }
        }

        private void UpdateExperienceAndLevel(object? sender, EventArgs e)
        {
            PlayerExperienceBar.Value = Game.Player.PercentOfLevelCompleted();
            PlayerLevelLabel.Text = Game.Player.Level.ToString();
        }

        private void OutputDialogs_ListChanged(object? sender, EventArgs e)
        {
            // auto scrolling! so when you get new dialog, it scrolls for you, very nice
            DialogListBox.TopIndex = Output.Dialogs.Count - 1 - Output.AmountAdded;
        }

        private void InitializeDialog()
        {
            DialogListBox.DataSource = Output.Dialogs;
            Output.Dialogs.ListChanged += OutputDialogs_ListChanged;
        }

        private void InitializeFarm(DataGridView grid, IPerson person, EventHandler handler)
        {
            // binds a list of farms to a datatable that is then bound to a datagrid view.

            DataTable dt = new DataTable();
            grid.DataSource = dt;

            // creates rows in the data table the will be bound to the Game.Map
            for (int i = 0; i < Game.FarmFieldDimentions.width; i++)
            {
                dt.Columns.Add("Column" + (i + 1));
            }

            for (var i = 0; i < Game.FarmFieldDimentions.height; ++i)
            {
                // create new row
                DataRow row = dt.NewRow();
                for (var j = 0; j < Game.FarmFieldDimentions.width; ++j)
                {
                    // if there is in fact a field there, set it
                    if (person.Fields.ElementAtOrDefault(i * Game.FarmFieldDimentions.width + j) != null)
                    {
                        row[j] = person.Fields[i * Game.FarmFieldDimentions.width + j];
                        // add handler for color change
                        person.Fields[(i * Game.FarmFieldDimentions.width) + j].ColorChanged += handler;
                    }
                }
                dt.Rows.Add(row);
            }
            // hide headers and auto size
            grid.ColumnHeadersVisible = false;
            grid.RowHeadersVisible = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
        }

        private void RenderField(object? sender, EventArgs e)

        {
            // get field that was clicked
            IFarmField? item = FarmFields.FirstOrDefault((field) => field == sender);
            if (item == null)
            {
                return;
            }
            if (FarmDataGrid.Rows.Count == 0)
            {
                return;
            }
            // set the color to the farm color
            int index = FarmFields.IndexOf(item);
            int column = index % Game.FarmFieldDimentions.width;
            int row = index / Game.FarmFieldDimentions.width;

            FarmDataGrid.Rows[row].Cells[column].Style.BackColor = item.Color;
        }

        private void InitializeMap()
        {
            // binds a list of farms to a datatable that is then bound to a datagrid view.

            // hide headers and auto size
            MapDataGrid.ColumnHeadersVisible = false;
            MapDataGrid.RowHeadersVisible = false;
            MapDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            MapDataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;

            //create datatable and bind it
            DataTable MapDataTable = new DataTable();
            MapDataGrid.DataSource = MapDataTable;

            // add columns to datatable
            for (int i = 0; i < Map.GetLength(1); i++)
            {
                MapDataTable.Columns.Add("Column" + (i + 1));
            }

            for (var i = 0; i < Map.GetLength(0); ++i)
            {
                DataRow row = MapDataTable.NewRow();
                // bind map item to datatable
                for (var j = 0; j < Map.GetLength(1); ++j)
                {
                    row[j] = Map[i, j];
                }
                MapDataTable.Rows.Add(row);
            }
        }

        private void MapDataGrid_SelectionChanged(object sender, EventArgs e)
        {
            MapDataGrid.ClearSelection();
        }

        private void RerenderMap()
        {
            // rerenders the colors for each grid square - you cant databind color so this is the best i can do
            for (var i = 0; i < Map.GetLength(0); ++i)
            {
                for (var j = 0; j < Map.GetLength(1); ++j)
                {
                    MapDataGrid.Rows[i].Cells[j].Style.BackColor = Map[i, j].Color;
                }
            }
        }

        private void ShopButton_Click(object sender, EventArgs e)
        {
            //show shop and hide maingame
            ShopPage shop = new(this);
            this.Hide();
            shop.Show();
        }

        private void FarmDataGrid_SelectionChanged(object sender, EventArgs e)
        {
            // makes its so you cant select anything
            FarmDataGrid.ClearSelection();
        }

        private void FarmDataGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int column = e.ColumnIndex;
            int row = e.RowIndex;
            // sees if the field you clicked is actually bound
            if (FarmFields.ElementAtOrDefault(row * Game.FarmFieldDimentions.width + column) != null && FarmFields[row * Game.FarmFieldDimentions.width + column] is PlayerFarmField)
            {
                try
                {
                    // if it is, try to harvest field
                    ((PlayerFarmField)FarmFields[row * Game.FarmFieldDimentions.width + column]).HarvestField();
                }
                catch (Exception ex)
                {
                    Output.AddDialogs(ex.Message);
                }
            }
        }

        private void MapDataGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // set color on load for each cell
            int column = e.ColumnIndex;
            int row = e.RowIndex;

            MapDataGrid.Rows[row].Cells[column].Style.BackColor = Map[row, column].Color;
        }

        private void FarmDataGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // do the same for the farms, but set color to gray if the field isnt bound
            int column = e.ColumnIndex;
            int row = e.RowIndex;
            if (FarmFields.ElementAtOrDefault(row * Game.FarmFieldDimentions.width + column) != null)
            {
                FarmDataGrid.Rows[row].Cells[column].Style.BackColor = FarmFields[row * Game.FarmFieldDimentions.width + column].Color;
            }
            else
            {
                FarmDataGrid.Rows[row].Cells[column].Style.BackColor = Color.Gray;
            }
        }

        // move player on click, rerendering map
        private void LeftArrow_Click(object sender, EventArgs e)
        {
            Game.MovePlayer(new MoveLeft(Game.Player, Game));
            RerenderMap();
        }

        private void UpArrow_Click(object sender, EventArgs e)
        {
            Game.MovePlayer(new MoveUp(Game.Player, Game));
            RerenderMap();
        }

        private void RightArrow_Click(object sender, EventArgs e)
        {
            Game.MovePlayer(new MoveRight(Game.Player, Game));
            RerenderMap();
        }

        private void DownArrow_Click(object sender, EventArgs e)
        {
            Game.MovePlayer(new MoveDown(Game.Player, Game));
            RerenderMap();
        }

        private void AcceptDuel_Click(object sender, EventArgs e)
        {
            try
            {
                DuelPage duelPage = new DuelPage(this);
                // hide current page and show duel
                duelPage.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                Output.AddDialogs(ex.Message);
            }
        }

        private void RejectDuel_Click(object sender, EventArgs e)
        {
            // end duel
            Game.EndDuel();
        }

        private void InventoryButton_Click(object sender, EventArgs e)
        {
            InventoryPage inventory = new(this);
            // hide current page and show inventory
            this.Hide();
            inventory.Show();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            // exit game
            Application.Exit();
        }

        private void PrintStats_Click(object sender, EventArgs e)
        {
            // print stats
            Game.PrintStats();
        }
    }
}