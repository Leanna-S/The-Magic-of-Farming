namespace RPG_Game_WinForms_UI
{
    partial class ShopPage
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
            ShopBuyButton = new Button();
            label1 = new Label();
            BackButton = new Button();
            ShopDataGridView = new DataGridView();
            MoneyLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)ShopDataGridView).BeginInit();
            SuspendLayout();
            // 
            // ShopBuyButton
            // 
            ShopBuyButton.Location = new Point(829, 448);
            ShopBuyButton.Name = "ShopBuyButton";
            ShopBuyButton.Size = new Size(105, 56);
            ShopBuyButton.TabIndex = 19;
            ShopBuyButton.Text = "Buy";
            ShopBuyButton.UseVisualStyleBackColor = true;
            ShopBuyButton.Click += ShopBuyButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 24);
            label1.Name = "label1";
            label1.Size = new Size(69, 31);
            label1.TabIndex = 21;
            label1.Text = "Shop";
            // 
            // BackButton
            // 
            BackButton.Location = new Point(940, 448);
            BackButton.Name = "BackButton";
            BackButton.Size = new Size(166, 56);
            BackButton.TabIndex = 18;
            BackButton.Text = "Back To Game";
            BackButton.UseVisualStyleBackColor = true;
            BackButton.Click += BackButton_Click;
            // 
            // ShopDataGridView
            // 
            ShopDataGridView.AllowUserToAddRows = false;
            ShopDataGridView.AllowUserToDeleteRows = false;
            ShopDataGridView.AllowUserToResizeColumns = false;
            ShopDataGridView.AllowUserToResizeRows = false;
            ShopDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            ShopDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            ShopDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ShopDataGridView.Location = new Point(12, 58);
            ShopDataGridView.MultiSelect = false;
            ShopDataGridView.Name = "ShopDataGridView";
            ShopDataGridView.ReadOnly = true;
            ShopDataGridView.RowHeadersWidth = 51;
            ShopDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ShopDataGridView.Size = new Size(1105, 384);
            ShopDataGridView.TabIndex = 22;
            // 
            // MoneyLabel
            // 
            MoneyLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            MoneyLabel.Location = new Point(816, 24);
            MoneyLabel.Name = "MoneyLabel";
            MoneyLabel.Size = new Size(301, 31);
            MoneyLabel.TabIndex = 23;
            MoneyLabel.Text = "0000";
            MoneyLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // ShopPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1129, 516);
            Controls.Add(MoneyLabel);
            Controls.Add(ShopDataGridView);
            Controls.Add(label1);
            Controls.Add(ShopBuyButton);
            Controls.Add(BackButton);
            Name = "ShopPage";
            Text = "ShopPage";
            ((System.ComponentModel.ISupportInitialize)ShopDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button ShopBuyButton;

        private Label label1;
        private Button BackButton;
        private DataGridView ShopDataGridView;
        private Label MoneyLabel;
    }
}