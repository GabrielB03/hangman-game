using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace HangmanGame.Forms
{
    public partial class GameForm : Form
    {
        private string secretWord;
        private string displayWord;
        private int errors = 0;
        private const int MaxErrors = 6;
        private bool darkMode = false;

        public GameForm()
        {
            InitializeComponent();
            this.ClientSize = new Size(1100, 600);
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            StartNewGame();
            ApplyTheme();
            this.KeyPreview = true;
            this.KeyPress += GameForm_KeyPress;
        }

        private void StartNewGame()
        {
            var words = File.ReadAllLines(@"Data\\words.txt");
            var random = new Random();
            secretWord = words[random.Next(words.Length)].ToUpper();
            displayWord = new string('_', secretWord.Length);
            errors = 0;

            EnableAllLetterButtons();
            UpdateDisplay();
            panelHangman.Invalidate();
        }

        private void UpdateDisplay()
        {
            labelWord.Text = string.Join(" ", displayWord.ToCharArray());
        }

        private void CheckLetter(char letter)
        {
            bool found = false;
            for (int i = 0; i < secretWord.Length; i++)
            {
                if (secretWord[i] == letter)
                {
                    displayWord = displayWord.Remove(i, 1).Insert(i, letter.ToString());
                    found = true;
                }
            }

            if (!found)
            {
                errors++;
                panelHangman.Invalidate();

                if (errors > MaxErrors)
                {
                    MessageBox.Show($"You lost! The word was: {secretWord}", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    StartNewGame();
                    return;
                }
            }

            if (!displayWord.Contains('_'))
            {
                MessageBox.Show("Congratulations! You won!", "Victory", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StartNewGame();
                return;
            }

            UpdateDisplay();
        }

        private void buttonClick(object sender, EventArgs e)
        {
            var btn = sender as Button;
            btn.Enabled = false;
            CheckLetter(btn.Text[0]);
        }

        private void EnableAllLetterButtons()
        {
            foreach (Control ctrl in panelLetters.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.Enabled = true;
                }
            }
        }

        private void panelHangman_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Black, 2);

            // Draw gallows
            g.DrawLine(pen, 10, 200, 100, 200);
            g.DrawLine(pen, 55, 200, 55, 20);
            g.DrawLine(pen, 55, 20, 130, 20);
            g.DrawLine(pen, 130, 20, 130, 40);

            // Draw hangman body parts
            if (errors >= 1)
                g.DrawEllipse(pen, 110, 40, 40, 40);      // Head
            if (errors >= 2)
                g.DrawLine(pen, 130, 80, 130, 140);        // Body
            if (errors >= 3)
                g.DrawLine(pen, 130, 90, 100, 120);        // Left arm
            if (errors >= 4)
                g.DrawLine(pen, 130, 90, 160, 120);        // Right arm
            if (errors >= 5)
                g.DrawLine(pen, 130, 140, 110, 180);       // Left leg
            if (errors >= 6)
                g.DrawLine(pen, 130, 140, 150, 180);       // Right leg
        }

        private void GameForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            char inputChar = char.ToUpper(e.KeyChar);

            if (inputChar >= 'A' && inputChar <= 'Z')
            {
                var btn = panelLetters.Controls.OfType<Button>().FirstOrDefault(b => b.Text == inputChar.ToString());
                if (btn != null && btn.Enabled)
                {
                    btn.PerformClick();
                }
            }
        }

        private void ToggleTheme(object sender, EventArgs e)
        {
            darkMode = !darkMode;
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            Color bgColor = darkMode ? Color.FromArgb(30, 30, 30) : Color.Azure;
            Color fgColor = darkMode ? Color.White : Color.Black;
            Color panelColor = darkMode ? Color.FromArgb(50, 50, 50) : Color.WhiteSmoke;
            Color btnColor = darkMode ? Color.FromArgb(70, 70, 70) : Color.White;

            this.BackColor = bgColor;
            panelHangman.BackColor = panelColor;
            labelWord.BackColor = btnColor;
            labelWord.ForeColor = fgColor;
            panelLetters.BackColor = panelColor;

            foreach (Control ctrl in panelLetters.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.BackColor = btnColor;
                    btn.ForeColor = fgColor;
                    btn.FlatStyle = FlatStyle.Flat;
                }
            }

            buttonToggleTheme.Text = darkMode ? "☀️ Light Mode" : "🌙 Dark Mode";
        }
    }
}