using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RPG_Game_Classes;
using RPG_Game_Classes.FarmFields;

namespace RPG_Game_WinForms_UI
{
    public partial class DuelPage : Form
    {
        public MainGamePage BaseForm { get; init; }
        public RPGGame Game { get; init; }
        public Duel? Duel { get; init; }

        public DuelPage(MainGamePage form)
        {
            InitializeComponent();
            InitializeDialog();
            BaseForm = form;

            Game = BaseForm.Game;
            if (BaseForm.Game.CurrentDuel == null)
            {
                BaseForm.Show();
                this.Close();
                return;
            }

            Duel = BaseForm.Game.CurrentDuel;
            Duel.RoundStarted += EnableSpells;

            InitializeFarm(NPCFarmDataGrid, Duel.NPC, RenderNPCField);
            InitializeFarm(PlayerFarmDataGrid, Game.Player, RenderPlayerField);
            InitializeButtons();
            InitializeNames();
            Duel.Player.ManaChanged += Player_ManaChanged;
            Duel.NPC.ManaChanged += NPC_ManaChanged;
            Game.DuelChange += Game_AskingToDuel;
        }

        private void NPC_ManaChanged(object? sender, EventArgs e)
        {
            if (Duel != null)
            {
                NPCManaLabel.Text = Duel.NPC.CurrentMana + "/" + Duel.NPC.MaximumMana;
            }
        }

        private void Player_ManaChanged(object? sender, EventArgs e)
        {
            if (Duel != null)
            {
                PlayerManaLabel.Text = Duel.Player.CurrentMana + "/" + Duel.Player.MaximumMana;
            }
        }

        private void Game_AskingToDuel(object? sender, EventArgs e)
        {
            BaseForm.Show();
            this.Close();
        }

        private void InitializeNames()
        {
            if (Duel != null)
            {
                PlayerNameLabel.Text = Duel.Player.Name;
                NPCNameLabel.Text = Duel.NPC.Name;
                NPCManaLabel.Text = Duel.NPC.CurrentMana + @"/" + Duel.NPC.MaximumMana;
                PlayerManaLabel.Text = Duel.Player.CurrentMana + @"/" + Duel.Player.MaximumMana;
            }
        }

        private void InitializeButtons()
        {
            if (Duel != null)
            {
                var selectedAbilities = Duel.Player.Abilities.Where((ability) => ability.Selected).ToList();
                if (selectedAbilities.Count >= 1)
                {
                    Spell1.Visible = true;

                    Spell1.Text = $"{selectedAbilities[0].Name}\nMana Cost: {selectedAbilities[0].ManaCost}";
                }
                if (selectedAbilities.Count >= 2)
                {
                    Spell2.Visible = true;
                    Spell2.Text = $"{selectedAbilities[1].Name}\nMana Cost: {selectedAbilities[1].ManaCost}";
                }
                if (selectedAbilities.Count >= 3)
                {
                    Spell3.Visible = true;
                    Spell3.Text = $"{selectedAbilities[2].Name}\nMana Cost: {selectedAbilities[2].ManaCost}";
                }
                if (selectedAbilities.Count >= 4)
                {
                    Spell4.Visible = true;

                    Spell4.Text = $"{selectedAbilities[3].Name}\nMana Cost: {selectedAbilities[3].ManaCost}";
                }
                if (selectedAbilities.Count >= 5)
                {
                    Spell5.Visible = true;

                    Spell5.Text = $"{selectedAbilities[4].Name}\nMana Cost: {selectedAbilities[4].ManaCost}";
                }
            }
        }

        private void InitializeFarm(DataGridView grid, IPerson person, EventHandler handler)
        {
            DataTable dt = new DataTable();
            grid.DataSource = dt;
            for (int i = 0; i < Game.FarmFieldDimentions.width; i++)
            {
                dt.Columns.Add("Column" + (i + 1));
            }

            for (var i = 0; i < Game.FarmFieldDimentions.height; ++i)
            {
                DataRow row = dt.NewRow();
                for (var j = 0; j < Game.FarmFieldDimentions.width; ++j)
                {
                    if (person.Fields.ElementAtOrDefault(i * Game.FarmFieldDimentions.width + j) != null)
                    {
                        row[j] = person.Fields[i * Game.FarmFieldDimentions.width + j];
                        person.Fields[(i * Game.FarmFieldDimentions.width) + j].ColorChanged += handler;
                    }
                }
                dt.Rows.Add(row);
            }
            grid.ColumnHeadersVisible = false;
            grid.RowHeadersVisible = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
        }

        private void OutputDialogs_ListChanged(object? sender, EventArgs e)
        {
            DialogListBox.TopIndex = Output.Dialogs.Count - 1 - Output.AmountAdded;
        }

        private void InitializeDialog()
        {
            DialogListBox.DataSource = Output.Dialogs;

            Output.Dialogs.ListChanged += OutputDialogs_ListChanged;
        }

        private void RenderPlayerField(object? sender, EventArgs e)
        {
            if (Duel != null)
            {
                IFarmField? item = Duel.Player.Fields.FirstOrDefault((field) => field == sender);
                if (item == null)
                {
                    return;
                }
                if (PlayerFarmDataGrid.Rows.Count == 0)
                {
                    return;
                }

                int index = Duel.Player.Fields.IndexOf(item);
                int column = index % Game.FarmFieldDimentions.width;
                int row = index / Game.FarmFieldDimentions.width;
                PlayerFarmDataGrid.Rows[row].Cells[column].Style.BackColor = item.Color;
            }
        }

        private void RenderNPCField(object? sender, EventArgs e)
        {
            if (Duel != null)
            {
                IFarmField? item = Duel.NPC.Fields.FirstOrDefault((field) => field == sender);
                if (item == null)
                {
                    return;
                }
                if (NPCFarmDataGrid.Rows.Count == 0)
                {
                    return;
                }

                int index = Duel.NPC.Fields.IndexOf(item);
                int column = index % Game.FarmFieldDimentions.width;
                int row = index / Game.FarmFieldDimentions.width;

                NPCFarmDataGrid.Rows[row].Cells[column].Style.BackColor = item.Color;
            }
        }

        private void EnableSpells(object? sender, EventArgs e)
        {
            if (sender != null)
            {
                Duel duel = (Duel)sender;
                if (duel.IsPlayerTurn)
                {
                    Spell1.Enabled = true;
                    Spell2.Enabled = true;
                    Spell3.Enabled = true;
                    Spell4.Enabled = true;
                    Spell5.Enabled = true;
                    SkipTurnButton.Enabled = true;
                }
                else
                {
                    Spell1.Enabled = false;
                    Spell2.Enabled = false;
                    Spell3.Enabled = false;
                    Spell4.Enabled = false;
                    Spell5.Enabled = false;
                    SkipTurnButton.Enabled = false;
                }
            }
        }

        private void NPCFarmDataGrid_SelectionChanged(object sender, EventArgs e)
        {
            NPCFarmDataGrid.ClearSelection();
        }

        private void PlayerFarmDataGrid_SelectionChanged(object sender, EventArgs e)
        {
            PlayerFarmDataGrid.ClearSelection();
        }

        private void NPCFarmDataGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (Duel != null)
            {
                int column = e.ColumnIndex;
                int row = e.RowIndex;
                if (Duel.NPC.Fields.ElementAtOrDefault(row * Game.FarmFieldDimentions.width + column) != null)
                {
                    NPCFarmDataGrid.Rows[row].Cells[column].Style.BackColor = Duel.NPC.Fields[row * Game.FarmFieldDimentions.width + column].Color;
                }
                else
                {
                    NPCFarmDataGrid.Rows[row].Cells[column].Style.BackColor = Color.Gray;
                }
            }
        }

        private void PlayerFarmDataGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (Duel != null)
            {
                int column = e.ColumnIndex;
                int row = e.RowIndex;
                if (Duel.Player.Fields.ElementAtOrDefault(row * Game.FarmFieldDimentions.width + column) != null)
                {
                    PlayerFarmDataGrid.Rows[row].Cells[column].Style.BackColor = Duel.Player.Fields[row * Game.FarmFieldDimentions.width + column].Color;
                }
                else
                {
                    PlayerFarmDataGrid.Rows[row].Cells[column].Style.BackColor = Color.Gray;
                }
            }
        }

        private void RunAbility(int index)
        {
            if (Duel != null)
            {
                var selectedAbilities = Duel.Player.Abilities.Where((ability) => ability.Selected).ToList();
                Duel.InvokeAbility(selectedAbilities[index]);
            }
        }

        private void DuelPage_Load(object sender, EventArgs e)
        {
            if (Duel != null)
            {
                DialogListBox.TopIndex = Output.Dialogs.Count - 1 - Output.AmountAdded;
                Duel.StartDuel();
            }
        }

        private void Spell1_Click(object sender, EventArgs e)
        {
            RunAbility(0);
        }

        private void Spell2_Click(object sender, EventArgs e)
        {
            RunAbility(1);
        }

        private void Spell3_Click(object sender, EventArgs e)
        {
            RunAbility(2);
        }

        private void Spell4_Click(object sender, EventArgs e)
        {
            RunAbility(3);
        }

        private void Spell5_Click(object sender, EventArgs e)
        {
            RunAbility(4);
        }

        private void SkipTurnButton_Click(object sender, EventArgs e)
        {
            if (Duel != null)
            {
                Duel.SkipTurn();
            }
        }
    }
}