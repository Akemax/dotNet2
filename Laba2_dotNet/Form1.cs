using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba2_dotNet
{
    public partial class Form1 : Form
    {
        // Create Player
        Player currentPlayer;
        bool isX = false;
        bool isO = false;

        public Form1()
        {
            InitializeComponent();
        }

        public enum Player
        {
            X,
            O
        }

        private void buttonClick(object sender, EventArgs e)
        {
            var button = (Button)sender;

            if (isX == true)
            {
                currentPlayer = Player.X;
            }
            if (isO == true)
            {
                currentPlayer = Player.O;
            }

            button.Text = currentPlayer.ToString();
            button.Enabled = false;
            button.BackColor = System.Drawing.Color.LightGreen;
            Check();
            AImoves.Start();
        }

        private void playAI(object sender, EventArgs e)
        {
            foreach (Control x in this.Controls)
            {
                
                if (x is Button && x.Text == "" && x.Enabled)
                {
                    x.Enabled = false;
                    if (isX == true)
                    {
                        currentPlayer = Player.O;
                    }
                    if (isO == true)
                    {
                        currentPlayer = Player.X;
                    }
                    x.Text = currentPlayer.ToString();
                    x.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                    AImoves.Stop();
                    Check();
                    break;
                }
                else
                {
                    AImoves.Stop();
                }
            }
        }

        private void resetGame(object sender, EventArgs e)
        {
            foreach (Control x in this.Controls)
            {
                if (x is Button && x.Tag == "playable")
                {
                    ((Button)x).Enabled = true;
                    ((Button)x).Text = "";
                    ((Button)x).BackColor = default(Color);
                }

            }
            buttonX.Enabled = true;
            buttonO.Enabled = true;
            isX = false;
            isO = false;
            label1.Text = "";

            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            button10.Enabled = false;

        }

        private void Check()
        {
            if (
            button1.Text == "X" && button2.Text == "X" && button3.Text == "X" ||
            button4.Text == "X" && button5.Text == "X" && button6.Text == "X" ||
            button7.Text == "X" && button8.Text == "X" && button9.Text == "X" ||
            button1.Text == "X" && button4.Text == "X" && button7.Text == "X" ||
            button2.Text == "X" && button5.Text == "X" && button8.Text == "X" ||
            button3.Text == "X" && button6.Text == "X" && button9.Text == "X" ||
            button1.Text == "X" && button5.Text == "X" && button9.Text == "X" ||
            button3.Text == "X" && button5.Text == "X" && button7.Text == "X"
                )
            {
                WON();
                label1.Text = "X Wins!";
            }
            else if (
            button1.Text == "O" && button2.Text == "O" && button3.Text == "O" ||
            button4.Text == "O" && button5.Text == "O" && button6.Text == "O" ||
            button7.Text == "O" && button8.Text == "O" && button9.Text == "O" ||
            button1.Text == "O" && button4.Text == "O" && button7.Text == "O" ||
            button2.Text == "O" && button5.Text == "O" && button8.Text == "O" ||
            button3.Text == "O" && button6.Text == "O" && button9.Text == "O" ||
            button1.Text == "O" && button5.Text == "O" && button9.Text == "O" ||
            button3.Text == "O" && button5.Text == "O" && button7.Text == "O"
                )
            {
                WON();
                label1.Text = "O Wins!";
            }
            else
            {
                if (button1.Enabled == false && button2.Enabled == false && button3.Enabled == false && button4.Enabled == false && button5.Enabled == false
                    && button6.Enabled == false && button7.Enabled == false && button8.Enabled == false && button9.Enabled == false) 
                {
                    WON();
                    label1.Text = "Draw!";
                }
            }
        }

        private void WON()
        {
            foreach (Control x in this.Controls)
            {

                if (x is Button && x.Tag == "playable")
                {
                    ((Button)x).Enabled = false;
                    ((Button)x).BackColor = default(Color);

                }

            }
            button10.Enabled = true;
        }

        private void buttonX_Click(object sender, EventArgs e)
        {
            currentPlayer = Player.X;
            isX = true;
            buttonX.Enabled = false;
            buttonO.Enabled = false;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
        }

        private void buttonO_Click(object sender, EventArgs e)
        {
            currentPlayer = Player.O;
            isO = true;
            buttonX.Enabled = false;
            buttonO.Enabled = false;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
        }
    }
}
