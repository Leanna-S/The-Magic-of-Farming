namespace RPG_Game_WinForms_UI
{
    partial class MainGamePage
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ShopButton = new Button();
            InventoryButton = new Button();
            MapDataGrid = new DataGridView();
            FarmDataGrid = new DataGridView();
            DialogListBox = new ListBox();
            ExitButton = new Button();
            PlayerExperienceBar = new ProgressBar();
            PlayerNameLabel = new Label();
            PlayerLevelLabel = new Label();
            LeftArrow = new Button();
            UpArrow = new Button();
            RightArrow = new Button();
            DownArrow = new Button();
            RejectDuel = new Button();
            AcceptDuel = new Button();
            PrintStats = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)MapDataGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)FarmDataGrid).BeginInit();
            SuspendLayout();
            // 
            // ShopButton
            // 
            ShopButton.Location = new Point(12, 81);
            ShopButton.Name = "ShopButton";
            ShopButton.Size = new Size(108, 56);
            ShopButton.TabIndex = 15;
            ShopButton.Text = "Shop";
            ShopButton.UseVisualStyleBackColor = true;
            ShopButton.Click += ShopButton_Click;
            // 
            // InventoryButton
            // 
            InventoryButton.Location = new Point(12, 143);
            InventoryButton.Name = "InventoryButton";
            InventoryButton.Size = new Size(108, 56);
            InventoryButton.TabIndex = 16;
            InventoryButton.Text = "Inventory";
            InventoryButton.UseVisualStyleBackColor = true;
            InventoryButton.Click += InventoryButton_Click;
            // 
            // MapDataGrid
            // 
            MapDataGrid.AllowUserToAddRows = false;
            MapDataGrid.AllowUserToDeleteRows = false;
            MapDataGrid.AllowUserToResizeColumns = false;
            MapDataGrid.AllowUserToResizeRows = false;
            MapDataGrid.BackgroundColor = SystemColors.ControlLightLight;
            MapDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            MapDataGrid.Location = new Point(572, 9);
            MapDataGrid.Name = "MapDataGrid";
            MapDataGrid.ReadOnly = true;
            MapDataGrid.RowHeadersWidth = 51;
            MapDataGrid.Size = new Size(436, 291);
            MapDataGrid.TabIndex = 19;
            MapDataGrid.CellFormatting += MapDataGrid_CellFormatting;
            MapDataGrid.SelectionChanged += MapDataGrid_SelectionChanged;
            // 
            // FarmDataGrid
            // 
            FarmDataGrid.AllowUserToAddRows = false;
            FarmDataGrid.AllowUserToDeleteRows = false;
            FarmDataGrid.BackgroundColor = SystemColors.ControlLightLight;
            FarmDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            FarmDataGrid.Location = new Point(126, 104);
            FarmDataGrid.MultiSelect = false;
            FarmDataGrid.Name = "FarmDataGrid";
            FarmDataGrid.ReadOnly = true;
            FarmDataGrid.RowHeadersWidth = 51;
            FarmDataGrid.Size = new Size(316, 219);
            FarmDataGrid.TabIndex = 20;
            FarmDataGrid.CellFormatting += FarmDataGrid_CellFormatting;
            FarmDataGrid.CellMouseClick += FarmDataGrid_CellMouseClick;
            FarmDataGrid.SelectionChanged += FarmDataGrid_SelectionChanged;
            // 
            // DialogListBox
            // 
            DialogListBox.FormattingEnabled = true;
            DialogListBox.Location = new Point(12, 370);
            DialogListBox.Name = "DialogListBox";
            DialogListBox.SelectionMode = SelectionMode.None;
            DialogListBox.Size = new Size(996, 224);
            DialogListBox.TabIndex = 21;
            // 
            // ExitButton
            // 
            ExitButton.Location = new Point(12, 267);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(108, 56);
            ExitButton.TabIndex = 24;
            ExitButton.Text = "Exit";
            ExitButton.UseVisualStyleBackColor = true;
            ExitButton.Click += ExitButton_Click;
            // 
            // PlayerExperienceBar
            // 
            PlayerExperienceBar.Location = new Point(73, 32);
            PlayerExperienceBar.Name = "PlayerExperienceBar";
            PlayerExperienceBar.Size = new Size(379, 29);
            PlayerExperienceBar.TabIndex = 25;
            // 
            // PlayerNameLabel
            // 
            PlayerNameLabel.AutoSize = true;
            PlayerNameLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PlayerNameLabel.Location = new Point(73, 9);
            PlayerNameLabel.Name = "PlayerNameLabel";
            PlayerNameLabel.Size = new Size(51, 20);
            PlayerNameLabel.TabIndex = 26;
            PlayerNameLabel.Text = "label1";
            // 
            // PlayerLevelLabel
            // 
            PlayerLevelLabel.Font = new Font("Showcard Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PlayerLevelLabel.Location = new Point(12, 32);
            PlayerLevelLabel.Name = "PlayerLevelLabel";
            PlayerLevelLabel.Size = new Size(55, 29);
            PlayerLevelLabel.TabIndex = 27;
            PlayerLevelLabel.Text = "000";
            PlayerLevelLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // LeftArrow
            // 
            LeftArrow.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LeftArrow.Location = new Point(595, 308);
            LeftArrow.Name = "LeftArrow";
            LeftArrow.Size = new Size(97, 56);
            LeftArrow.TabIndex = 28;
            LeftArrow.Text = "←";
            LeftArrow.UseVisualStyleBackColor = true;
            LeftArrow.Click += LeftArrow_Click;
            // 
            // UpArrow
            // 
            UpArrow.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            UpArrow.Location = new Point(698, 308);
            UpArrow.Name = "UpArrow";
            UpArrow.Size = new Size(95, 56);
            UpArrow.TabIndex = 29;
            UpArrow.Text = "↑";
            UpArrow.UseVisualStyleBackColor = true;
            UpArrow.Click += UpArrow_Click;
            // 
            // RightArrow
            // 
            RightArrow.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RightArrow.Location = new Point(799, 308);
            RightArrow.Name = "RightArrow";
            RightArrow.Size = new Size(95, 56);
            RightArrow.TabIndex = 30;
            RightArrow.Text = "→";
            RightArrow.UseVisualStyleBackColor = true;
            RightArrow.Click += RightArrow_Click;
            // 
            // DownArrow
            // 
            DownArrow.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DownArrow.Location = new Point(900, 308);
            DownArrow.Name = "DownArrow";
            DownArrow.Size = new Size(95, 56);
            DownArrow.TabIndex = 31;
            DownArrow.Text = "↓";
            DownArrow.UseVisualStyleBackColor = true;
            DownArrow.Click += DownArrow_Click;
            // 
            // RejectDuel
            // 
            RejectDuel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RejectDuel.Location = new Point(454, 143);
            RejectDuel.Name = "RejectDuel";
            RejectDuel.Size = new Size(112, 56);
            RejectDuel.TabIndex = 32;
            RejectDuel.Text = "Reject Duel";
            RejectDuel.UseVisualStyleBackColor = true;
            RejectDuel.Visible = false;
            RejectDuel.Click += RejectDuel_Click;
            // 
            // AcceptDuel
            // 
            AcceptDuel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AcceptDuel.Location = new Point(454, 81);
            AcceptDuel.Name = "AcceptDuel";
            AcceptDuel.Size = new Size(112, 56);
            AcceptDuel.TabIndex = 33;
            AcceptDuel.Text = "Accept Duel";
            AcceptDuel.UseVisualStyleBackColor = true;
            AcceptDuel.Visible = false;
            AcceptDuel.Click += AcceptDuel_Click;
            // 
            // PrintStats
            // 
            PrintStats.Location = new Point(12, 205);
            PrintStats.Name = "PrintStats";
            PrintStats.Size = new Size(108, 56);
            PrintStats.TabIndex = 34;
            PrintStats.Text = "Print Stats";
            PrintStats.UseVisualStyleBackColor = true;
            PrintStats.Click += PrintStats_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(227, 70);
            label1.Name = "label1";
            label1.Size = new Size(78, 31);
            label1.TabIndex = 35;
            label1.Text = "FARM";
            // 
            // MainGamePage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1033, 599);
            Controls.Add(label1);
            Controls.Add(PrintStats);
            Controls.Add(AcceptDuel);
            Controls.Add(RejectDuel);
            Controls.Add(DownArrow);
            Controls.Add(RightArrow);
            Controls.Add(UpArrow);
            Controls.Add(LeftArrow);
            Controls.Add(PlayerLevelLabel);
            Controls.Add(PlayerNameLabel);
            Controls.Add(PlayerExperienceBar);
            Controls.Add(ExitButton);
            Controls.Add(DialogListBox);
            Controls.Add(FarmDataGrid);
            Controls.Add(MapDataGrid);
            Controls.Add(InventoryButton);
            Controls.Add(ShopButton);
            Name = "MainGamePage";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)MapDataGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)FarmDataGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button ShopButton;
        private Button InventoryButton;
        private DataGridView MapDataGrid;
        private DataGridView FarmDataGrid;
        private ListBox DialogListBox;
        private Button ExitButton;
        private ProgressBar PlayerExperienceBar;
        private Label PlayerNameLabel;
        private Label PlayerLevelLabel;
        private Button LeftArrow;
        private Button UpArrow;
        private Button RightArrow;
        private Button DownArrow;
        private Button RejectDuel;
        private Button AcceptDuel;
        private Button PrintStats;
        private Label label1;
    }
}
