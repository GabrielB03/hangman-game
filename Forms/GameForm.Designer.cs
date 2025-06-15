namespace HangmanGame.Forms
{
    partial class GameForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelHangman;
        private System.Windows.Forms.Label labelWord;
        private System.Windows.Forms.Button[] letterButtons;
        private System.Windows.Forms.Button buttonToggleTheme;
        private System.Windows.Forms.Panel panelLetters;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelHangman = new System.Windows.Forms.Panel();
            this.labelWord = new System.Windows.Forms.Label();
            this.letterButtons = new System.Windows.Forms.Button[26];
            this.buttonToggleTheme = new System.Windows.Forms.Button();
            this.panelLetters = new System.Windows.Forms.Panel();
            this.SuspendLayout();

            // panelHangman
            this.panelHangman.Location = new System.Drawing.Point(30, 30);
            this.panelHangman.Name = "panelHangman";
            this.panelHangman.Size = new System.Drawing.Size(200, 500);
            this.panelHangman.TabIndex = 0;
            this.panelHangman.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelHangman.Paint += new System.Windows.Forms.PaintEventHandler(this.panelHangman_Paint);
            this.panelHangman.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Bottom;

            // labelWord
            this.labelWord.Font = new System.Drawing.Font("Consolas", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelWord.Location = new System.Drawing.Point(250, 40);
            this.labelWord.Name = "labelWord";
            this.labelWord.Size = new System.Drawing.Size(700, 60);
            this.labelWord.TabIndex = 1;
            this.labelWord.Text = "_ _ _ _ _";
            this.labelWord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelWord.BackColor = System.Drawing.Color.LightYellow;
            this.labelWord.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelWord.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            // panelLetters
            this.panelLetters.Location = new System.Drawing.Point(250, 120);
            this.panelLetters.Name = "panelLetters";
            this.panelLetters.Size = new System.Drawing.Size(700, 400);
            this.panelLetters.TabIndex = 2;
            this.panelLetters.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Bottom;
            this.panelLetters.AutoScroll = true;

            int startX = 0;
            int startY = 0;
            int btnWidth = 60;
            int btnHeight = 60;
            int margin = 12;

            for (int i = 0; i < 26; i++)
            {
                this.letterButtons[i] = new System.Windows.Forms.Button();
                var btn = this.letterButtons[i];
                btn.Name = "btn" + (char)('A' + i);
                btn.Text = ((char)('A' + i)).ToString();
                btn.Size = new System.Drawing.Size(btnWidth, btnHeight);

                int col = i % 7;
                int row = i / 7;

                btn.Location = new System.Drawing.Point(startX + col * (btnWidth + margin), startY + row * (btnHeight + margin));
                btn.TabIndex = 3 + i;
                btn.BackColor = System.Drawing.Color.White;
                btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btn.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
                btn.UseVisualStyleBackColor = true;
                btn.Click += new System.EventHandler(this.buttonClick);

                this.panelLetters.Controls.Add(btn);
            }

            // buttonToggleTheme
            this.buttonToggleTheme.Location = new System.Drawing.Point(965, 10);  // <-- aqui está o ajuste para a direita
            this.buttonToggleTheme.Name = "buttonToggleTheme";
            this.buttonToggleTheme.Size = new System.Drawing.Size(130, 35);
            this.buttonToggleTheme.TabIndex = 100;
            this.buttonToggleTheme.Text = "🌙 Dark Mode";
            this.buttonToggleTheme.UseVisualStyleBackColor = true;
            this.buttonToggleTheme.Click += new System.EventHandler(this.ToggleTheme);
            this.buttonToggleTheme.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.buttonToggleTheme.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonToggleTheme.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);

            // GameForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1100, 600);
            this.Controls.Add(this.panelLetters);
            this.Controls.Add(this.labelWord);
            this.Controls.Add(this.panelHangman);
            this.Controls.Add(this.buttonToggleTheme);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hangman Game";
            this.KeyPreview = true;
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GameForm_KeyPress);
            this.ResumeLayout(false);
        }

        #endregion
    }
}