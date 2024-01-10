namespace RPG_Game_WinForms_UI
{
    partial class TitlePage
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
            NameInputTextBox = new TextBox();
            TitleLabel = new Label();
            label1 = new Label();
            NameSubmitButton = new Button();
            ErrorLabel = new Label();
            SuspendLayout();
            // 
            // NameInputTextBox
            // 
            NameInputTextBox.Location = new Point(304, 292);
            NameInputTextBox.Name = "NameInputTextBox";
            NameInputTextBox.Size = new Size(501, 27);
            NameInputTextBox.TabIndex = 0;
            // 
            // TitleLabel
            // 
            TitleLabel.AutoSize = true;
            TitleLabel.BackColor = Color.Transparent;
            TitleLabel.Font = new Font("Showcard Gothic", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TitleLabel.Location = new Point(359, 123);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(406, 86);
            TitleLabel.TabIndex = 1;
            TitleLabel.Text = "The Magic Of Farming\r\n\r\n";
            TitleLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(480, 260);
            label1.Name = "label1";
            label1.Size = new Size(148, 20);
            label1.TabIndex = 2;
            label1.Text = "What is your name?";
            // 
            // NameSubmitButton
            // 
            NameSubmitButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NameSubmitButton.Location = new Point(480, 398);
            NameSubmitButton.Name = "NameSubmitButton";
            NameSubmitButton.Size = new Size(139, 59);
            NameSubmitButton.TabIndex = 3;
            NameSubmitButton.Text = "Let's Go";
            NameSubmitButton.UseVisualStyleBackColor = true;
            NameSubmitButton.Click += NameSubmitButton_Click;
            // 
            // ErrorLabel
            // 
            ErrorLabel.AutoSize = true;
            ErrorLabel.BackColor = Color.Transparent;
            ErrorLabel.Location = new Point(34, 324);
            ErrorLabel.Name = "ErrorLabel";
            ErrorLabel.Size = new Size(0, 20);
            ErrorLabel.TabIndex = 4;
            ErrorLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // TitlePage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackgroundImage = Properties.Resources.Designer_3_;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1132, 558);
            Controls.Add(ErrorLabel);
            Controls.Add(NameSubmitButton);
            Controls.Add(label1);
            Controls.Add(TitleLabel);
            Controls.Add(NameInputTextBox);
            Name = "TitlePage";
            Text = "TitlePage";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox NameInputTextBox;
        private Label TitleLabel;
        private Label label1;
        private Button NameSubmitButton;
        private Label ErrorLabel;
    }
}