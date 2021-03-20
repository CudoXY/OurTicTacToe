using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OurTicTacToe
{
    public partial class Main : Form
    {
        private string _currentSymbol;
        private Button[][] _winningCombination;
        private List<Button> _buttonList;
        private Color _defaultColor;

        public Main()
        {
            InitializeComponent();

            _defaultColor = Button11.BackColor;

            _winningCombination = new[]
            {
                // Row combination
                new[] { Button11, Button12, Button13 },
                new[] { Button21, Button22, Button23 },
                new[] { Button31, Button32, Button33 },
                
                // Column combination
                new[] { Button11, Button21, Button31 },
                new[] { Button12, Button22, Button32 },
                new[] { Button13, Button23, Button33 },

                // Diagonal
                new[] { Button11, Button22, Button33 },
                new[] { Button13, Button22, Button31 }
            };

            // Button List
            _buttonList = new List<Button>
            {
                Button11
            };

            _buttonList.Add(Button12);
            _buttonList.Add(Button13);
            _buttonList.Add(Button21);
            _buttonList.Add(Button22);
            _buttonList.Add(Button23);
            _buttonList.Add(Button31);
            _buttonList.Add(Button32);
            _buttonList.Add(Button33);

            InitializeGame();
        }

        private void InitializeGame()
        {
            _currentSymbol = "O";

            // Reset board
            foreach (var button in _buttonList)
            {
                button.Enabled = true;
                button.Text = "";
                button.BackColor = _defaultColor;
            }
        }

        private void SwitchSymbol()
        {
            if (_currentSymbol == "O")
            {
                _currentSymbol = "X";
            }
            else
            {
                _currentSymbol = "O";
            }
        }

        private void PerformTurn(Button button)
        {
            // Display the current symbol
            button.Text = _currentSymbol;
            button.Enabled = false;

            // Change colors
            if (_currentSymbol == "O")
            {
                button.BackColor = Color.LimeGreen;
            }
            else if (_currentSymbol == "X")
            {
                button.BackColor = Color.Red;
            }

            // Switches the symbol.
            SwitchSymbol();

            var winningSymbol = GetWinningSymbol();
            if (winningSymbol == "")
            {
                return;
            }

            // Display winner
            MessageBox.Show("Player " + winningSymbol + " wins!");

            // Disable board
            for (var i = 0; i < _buttonList.Count; i++)
            {
                _buttonList[i].Enabled = false;
            }
        }

        private string GetWinningSymbol()
        {
            // Scan through the winning combinations
            foreach (var buttons in _winningCombination)
            {
                // Check if button 1 = button 2 = button
                if (buttons[0].Text == buttons[1].Text && buttons[1].Text == buttons[2].Text)
                {
                    return buttons[0].Text;
                }
            }

            return "";
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            PerformTurn((Button)sender);
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            PerformTurn((Button)sender);
        }

        private void Button13_Click(object sender, EventArgs e)
        {
            PerformTurn((Button)sender);
        }

        private void Button21_Click(object sender, EventArgs e)
        {
            PerformTurn((Button)sender);
        }

        private void Button22_Click(object sender, EventArgs e)
        {
            PerformTurn((Button)sender);
        }

        private void Button23_Click(object sender, EventArgs e)
        {
            PerformTurn((Button)sender);
        }

        private void Button31_Click(object sender, EventArgs e)
        {
            PerformTurn((Button)sender);
        }

        private void Button32_Click(object sender, EventArgs e)
        {
            PerformTurn((Button)sender);
        }

        private void Button33_Click(object sender, EventArgs e)
        {
            PerformTurn((Button)sender);
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            InitializeGame();
        }
    }
}
