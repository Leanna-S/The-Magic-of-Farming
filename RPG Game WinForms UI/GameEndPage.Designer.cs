namespace RPG_Game_WinForms_UI
{
    partial class GameEndPage
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
            GameEndLabel = new Label();
            label1 = new Label();
            PlayAgainButton = new Button();
            ExitProgramButton = new Button();
            SuspendLayout();
            // 
            // GameEndLabel
            // 
            GameEndLabel.BackColor = SystemColors.Control;
            GameEndLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            GameEndLabel.ForeColor = Color.Black;
            GameEndLabel.Location = new Point(-9, -4);
            GameEndLabel.Name = "GameEndLabel";
            GameEndLabel.Size = new Size(820, 184);
            GameEndLabel.TabIndex = 0;
            GameEndLabel.Text = "Sample text";
            GameEndLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Image = Properties.Resources.Designer_4_;
            label1.ImageAlign = ContentAlignment.TopCenter;
            label1.Location = new Point(-10, 18);
            label1.Name = "label1";
            label1.Size = new Size(821, 528);
            label1.TabIndex = 1;
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // PlayAgainButton
            // 
            PlayAgainButton.Location = new Point(92, 453);
            PlayAgainButton.Name = "PlayAgainButton";
            PlayAgainButton.Size = new Size(158, 54);
            PlayAgainButton.TabIndex = 2;
            PlayAgainButton.Text = "Play Again";
            PlayAgainButton.UseVisualStyleBackColor = true;
            PlayAgainButton.Click += PlayAgainButton_Click;
            // 
            // ExitProgramButton
            // 
            ExitProgramButton.Location = new Point(553, 453);
            ExitProgramButton.Name = "ExitProgramButton";
            ExitProgramButton.Size = new Size(158, 54);
            ExitProgramButton.TabIndex = 3;
            ExitProgramButton.Text = "Exit Program";
            ExitProgramButton.UseVisualStyleBackColor = true;
            ExitProgramButton.Click += ExitProgramButton_Click;
            // 
            // GameEndPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 519);
            Controls.Add(ExitProgramButton);
            Controls.Add(PlayAgainButton);
            Controls.Add(GameEndLabel);
            Controls.Add(label1);
            Name = "GameEndPage";
            Text = "GameEndPage";
        
            ResumeLayout(false);
        }

        #endregion

        private Label GameEndLabel;
        private Label label1;
        private Button PlayAgainButton;
        private Button ExitProgramButton;
    }
}