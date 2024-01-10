namespace RPG_Game_WinForms_UI
{
    partial class DuelPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            NPCNameLabel = new Label();
            PlayerNameLabel = new Label();
            DialogListBox = new ListBox();
            NPCFarmDataGrid = new DataGridView();
            PlayerFarmDataGrid = new DataGridView();
            Spell1 = new Button();
            Spell2 = new Button();
            Spell3 = new Button();
            Spell4 = new Button();
            Spell5 = new Button();
            PlayerManaLabel = new Label();
            NPCManaLabel = new Label();
            SkipTurnButton = new Button();
            ((System.ComponentModel.ISupportInitialize)NPCFarmDataGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PlayerFarmDataGrid).BeginInit();
            SuspendLayout();
            // 
            // NPCNameLabel
            // 
            NPCNameLabel.AutoSize = true;
            NPCNameLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NPCNameLabel.Location = new Point(13, 9);
            NPCNameLabel.Name = "NPCNameLabel";
            NPCNameLabel.Size = new Size(129, 31);
            NPCNameLabel.TabIndex = 23;
            NPCNameLabel.Text = "NPC Name";
            // 
            // PlayerNameLabel
            // 
            PlayerNameLabel.AutoSize = true;
            PlayerNameLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PlayerNameLabel.Location = new Point(543, 9);
            PlayerNameLabel.Name = "PlayerNameLabel";
            PlayerNameLabel.Size = new Size(149, 31);
            PlayerNameLabel.TabIndex = 24;
            PlayerNameLabel.Text = "Player Name";
            // 
            // DialogListBox
            // 
            DialogListBox.FormattingEnabled = true;
            DialogListBox.Location = new Point(12, 382);
            DialogListBox.Name = "DialogListBox";
            DialogListBox.SelectionMode = SelectionMode.None;
            DialogListBox.Size = new Size(847, 184);
            DialogListBox.TabIndex = 25;
            // 
            // NPCFarmDataGrid
            // 
            NPCFarmDataGrid.AllowUserToAddRows = false;
            NPCFarmDataGrid.AllowUserToDeleteRows = false;
            NPCFarmDataGrid.BackgroundColor = SystemColors.ControlLightLight;
            NPCFarmDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            NPCFarmDataGrid.Location = new Point(12, 72);
            NPCFarmDataGrid.MultiSelect = false;
            NPCFarmDataGrid.Name = "NPCFarmDataGrid";
            NPCFarmDataGrid.ReadOnly = true;
            NPCFarmDataGrid.RowHeadersWidth = 51;
            NPCFarmDataGrid.Size = new Size(316, 219);
            NPCFarmDataGrid.TabIndex = 26;
            NPCFarmDataGrid.CellFormatting += NPCFarmDataGrid_CellFormatting;
            NPCFarmDataGrid.SelectionChanged += NPCFarmDataGrid_SelectionChanged;
            // 
            // PlayerFarmDataGrid
            // 
            PlayerFarmDataGrid.AllowUserToAddRows = false;
            PlayerFarmDataGrid.AllowUserToDeleteRows = false;
            PlayerFarmDataGrid.BackgroundColor = SystemColors.ControlLightLight;
            PlayerFarmDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            PlayerFarmDataGrid.Location = new Point(543, 72);
            PlayerFarmDataGrid.MultiSelect = false;
            PlayerFarmDataGrid.Name = "PlayerFarmDataGrid";
            PlayerFarmDataGrid.ReadOnly = true;
            PlayerFarmDataGrid.RowHeadersWidth = 51;
            PlayerFarmDataGrid.Size = new Size(316, 219);
            PlayerFarmDataGrid.TabIndex = 27;
            PlayerFarmDataGrid.CellFormatting += PlayerFarmDataGrid_CellFormatting;
            PlayerFarmDataGrid.SelectionChanged += PlayerFarmDataGrid_SelectionChanged;
            // 
            // Spell1
            // 
            Spell1.Enabled = false;
            Spell1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Spell1.Location = new Point(13, 297);
            Spell1.Name = "Spell1";
            Spell1.Size = new Size(136, 79);
            Spell1.TabIndex = 34;
            Spell1.Text = "1";
            Spell1.UseVisualStyleBackColor = true;
            Spell1.Visible = false;
            Spell1.Click += Spell1_Click;
            // 
            // Spell2
            // 
            Spell2.Enabled = false;
            Spell2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Spell2.Location = new Point(155, 297);
            Spell2.Name = "Spell2";
            Spell2.Size = new Size(136, 79);
            Spell2.TabIndex = 35;
            Spell2.Text = "2";
            Spell2.UseVisualStyleBackColor = true;
            Spell2.Visible = false;
            Spell2.Click += Spell2_Click;
            // 
            // Spell3
            // 
            Spell3.Enabled = false;
            Spell3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Spell3.Location = new Point(297, 297);
            Spell3.Name = "Spell3";
            Spell3.Size = new Size(136, 79);
            Spell3.TabIndex = 36;
            Spell3.Text = "3";
            Spell3.UseVisualStyleBackColor = true;
            Spell3.Visible = false;
            Spell3.Click += Spell3_Click;
            // 
            // Spell4
            // 
            Spell4.Enabled = false;
            Spell4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Spell4.Location = new Point(439, 297);
            Spell4.Name = "Spell4";
            Spell4.Size = new Size(136, 79);
            Spell4.TabIndex = 37;
            Spell4.Text = "4";
            Spell4.UseVisualStyleBackColor = true;
            Spell4.Visible = false;
            Spell4.Click += Spell4_Click;
            // 
            // Spell5
            // 
            Spell5.Enabled = false;
            Spell5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Spell5.Location = new Point(581, 297);
            Spell5.Name = "Spell5";
            Spell5.Size = new Size(136, 79);
            Spell5.TabIndex = 38;
            Spell5.Text = "5";
            Spell5.UseVisualStyleBackColor = true;
            Spell5.Visible = false;
            Spell5.Click += Spell5_Click;
            // 
            // PlayerManaLabel
            // 
            PlayerManaLabel.Font = new Font("Showcard Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PlayerManaLabel.Location = new Point(543, 40);
            PlayerManaLabel.Name = "PlayerManaLabel";
            PlayerManaLabel.Size = new Size(316, 29);
            PlayerManaLabel.TabIndex = 40;
            PlayerManaLabel.Text = "000";
            // 
            // NPCManaLabel
            // 
            NPCManaLabel.Font = new Font("Showcard Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            NPCManaLabel.Location = new Point(13, 40);
            NPCManaLabel.Name = "NPCManaLabel";
            NPCManaLabel.Size = new Size(316, 29);
            NPCManaLabel.TabIndex = 41;
            NPCManaLabel.Text = "000";
            // 
            // SkipTurnButton
            // 
            SkipTurnButton.Enabled = false;
            SkipTurnButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SkipTurnButton.Location = new Point(723, 297);
            SkipTurnButton.Name = "SkipTurnButton";
            SkipTurnButton.Size = new Size(136, 79);
            SkipTurnButton.TabIndex = 42;
            SkipTurnButton.Text = "Skip Turn";
            SkipTurnButton.UseVisualStyleBackColor = true;
            SkipTurnButton.Click += SkipTurnButton_Click;
            // 
            // DuelPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(877, 585);
            Controls.Add(SkipTurnButton);
            Controls.Add(NPCManaLabel);
            Controls.Add(PlayerManaLabel);
            Controls.Add(Spell5);
            Controls.Add(Spell4);
            Controls.Add(Spell3);
            Controls.Add(Spell2);
            Controls.Add(Spell1);
            Controls.Add(PlayerFarmDataGrid);
            Controls.Add(NPCFarmDataGrid);
            Controls.Add(DialogListBox);
            Controls.Add(PlayerNameLabel);
            Controls.Add(NPCNameLabel);
            Name = "DuelPage";
            Text = "DuelPage";
            Load += DuelPage_Load;
            ((System.ComponentModel.ISupportInitialize)NPCFarmDataGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)PlayerFarmDataGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label NPCNameLabel;
        private Label PlayerNameLabel;
        private ListBox DialogListBox;
        private DataGridView NPCFarmDataGrid;
        private DataGridView PlayerFarmDataGrid;
        private Button Spell1;
        private Button Spell2;
        private Button Spell3;
        private Button Spell4;
        private Button Spell5;
        private Label PlayerManaLabel;
        private Label NPCManaLabel;
        private Button SkipTurnButton;
    }
}