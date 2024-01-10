using RPG_Game_Classes;
using RPG_Game_Classes.Abilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RPG_Game_WinForms_UI
{
    public partial class InventoryPage : Form
    {
        public MainGamePage BaseForm { get; init; }
        public RPGGame Game { get; init; }

        public InventoryPage(MainGamePage form)
        {
            BaseForm = form;
            Game = BaseForm.Game;
            InitializeComponent();
            InitializeEquipmentListBox();
            InitializeAbilityListBox();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            // show and close form
            BaseForm.Show();

            this.Close();
        }

        private void InitializeEquipmentListBox()
        {
            // the reason for the removing and adding of the event handler is...
            // to fix the lovely windows form issue where it runs an event when its not supposed to
            // (when you set the datasource, why does it set the index to 0?!?!? why!?!?)
            // That is, SelectedIndexChanged, (a bug that caused me lots of rage)
            // if you want to know more i could go on a whole rant
            EquipmentListBox.HorizontalScrollbar = true;
            EquipmentListBox.SelectedIndexChanged -= EquipmentListBox_SelectedIndexChanged;
            EquipmentListBox.DataSource = Game.Player.Equipment;
            EquipmentListBox.SelectedIndexChanged += EquipmentListBox_SelectedIndexChanged;
        }

        private void InitializeAbilityListBox()
        {
            // the reason for the removing and adding of the event handler is:
            // to fix the lovely windows form issue where it runs an event when its not supposed to
            // That is, SelectedIndexChanged, (a bug that caused me lots of rage)
            AbilitiesListBox.HorizontalScrollbar = true;
            AbilitiesListBox.SelectedIndexChanged -= AbilitiesListBox_SelectedIndexChanged;
            AbilitiesListBox.DataSource = Game.Player.Abilities;
            AbilitiesListBox.SelectedIndex = -1;
            AbilitiesListBox.SelectedIndexChanged += AbilitiesListBox_SelectedIndexChanged;
        }

        private void EquipmentListBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            // if no index is selected, set it to the current selected item
            if (EquipmentListBox.SelectedIndex == -1)
            {
                EquipmentListBox.SelectedIndex = Game.Player.Equipment.IndexOf(Game.Player.EquippedItem);
                return;
            }

            // otherwise change equipment selection
            Equipment? newSelection = Game.Player.Equipment[EquipmentListBox.SelectedIndex];

            if (newSelection != null)
            {
                Game.Player.EquippedItem = newSelection;
            }
        }

        // makes sure that all loaded selections are inputted before rendering fully
        private bool isLoading = true;

        private void AbilitiesListBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (!isLoading)
            {
                // if there are more than 5 selections, purge the last item
                if (AbilitiesListBox.SelectedItems.Count > 5)
                {
                    IAbility? itemToRemove = (IAbility?)AbilitiesListBox.SelectedItems[^1];
                    if (itemToRemove != null)
                    {
                        AbilitiesListBox.SelectedItems.Remove(itemToRemove);
                    }
                }
                // if there are no selected items, add the first item
                if (AbilitiesListBox.SelectedItems.Count < 1)
                {
                    AbilitiesListBox.SelectedItems.Add(AbilitiesListBox.Items[0]);
                }

                SetSelectionState();
            }
        }

        private void SetSelectionState()
        {
            // then just set the selected states accordingly
            foreach (IAbility selection in Game.Player.Abilities)
            {
                if (AbilitiesListBox.SelectedItems.Contains(selection))
                {
                    selection.Selected = true;
                }
                else
                {
                    selection.Selected = false;
                }
            }
        }

        private void InventoryPage_Load(object sender, EventArgs e)
        {
            // selects correct inventory on load
            // select equipment
            EquipmentListBox.SelectedIndex = Game.Player.Equipment.IndexOf(Game.Player.EquippedItem);

            var selected = Game.Player.Abilities.Where(ability => ability.Selected);
            // select abilities
            foreach (Ability ability in selected)
            {
                AbilitiesListBox.SelectedItems.Add(ability);
            }
            isLoading = false;
            SetSelectionState();
        }
    }
}