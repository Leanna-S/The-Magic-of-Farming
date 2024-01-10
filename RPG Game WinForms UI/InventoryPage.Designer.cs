namespace RPG_Game_WinForms_UI
{
    partial class InventoryPage
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
            label1 = new Label();
            Abilities = new Label();
            BackButton = new Button();
            EquipmentListBox = new ListBox();
            AbilitiesListBox = new ListBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(131, 31);
            label1.TabIndex = 1;
            label1.Text = "Equipment";
            // 
            // Abilities
            // 
            Abilities.AutoSize = true;
            Abilities.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Abilities.Location = new Point(12, 270);
            Abilities.Name = "Abilities";
            Abilities.Size = new Size(103, 31);
            Abilities.TabIndex = 3;
            Abilities.Text = "Abilities";
            // 
            // BackButton
            // 
            BackButton.Location = new Point(633, 544);
            BackButton.Name = "BackButton";
            BackButton.Size = new Size(166, 56);
            BackButton.TabIndex = 17;
            BackButton.Text = "Back To Game";
            BackButton.UseVisualStyleBackColor = true;
            BackButton.Click += BackButton_Click;
            // 
            // EquipmentListBox
            // 
            EquipmentListBox.FormattingEnabled = true;
            EquipmentListBox.Location = new Point(12, 43);
            EquipmentListBox.Name = "EquipmentListBox";
            EquipmentListBox.Size = new Size(1052, 204);
            EquipmentListBox.TabIndex = 20;
            EquipmentListBox.SelectedIndexChanged += EquipmentListBox_SelectedIndexChanged;
            // 
            // AbilitiesListBox
            // 
            AbilitiesListBox.FormattingEnabled = true;
            AbilitiesListBox.Location = new Point(12, 304);
            AbilitiesListBox.Name = "AbilitiesListBox";
            AbilitiesListBox.SelectionMode = SelectionMode.MultiSimple;
            AbilitiesListBox.Size = new Size(1052, 204);
            AbilitiesListBox.TabIndex = 21;
            AbilitiesListBox.SelectedIndexChanged += AbilitiesListBox_SelectedIndexChanged;
            // 
            // InventoryPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1078, 612);
            Controls.Add(AbilitiesListBox);
            Controls.Add(EquipmentListBox);
            Controls.Add(BackButton);
            Controls.Add(Abilities);
            Controls.Add(label1);
            Name = "InventoryPage";
            Text = "Inventory";
            Load += InventoryPage_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label Abilities;
        private Button BackButton;
        private ListBox EquipmentListBox;
        private ListBox AbilitiesListBox;
    }
}