using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe_Game_Soletion
{
    public partial class Form1 : Form
    {
        stGameStatus GameStatus;
        enPlayer PlayerTurn = enPlayer.player1;
        enum enPlayer
        {
            player1,
            player2
        }

        enum enWinner
        {
            player1,
            player2,
            Draw,
            GameInPeogess
        }

        struct stGameStatus
        {
            public enWinner Winner;
            public bool GameOver;
            public short GameCount;
        }

        public Form1()
        {
            InitializeComponent();
        }

        public void EndGame()
        {
            labelWinner.Text = "Game Over";
            switch (GameStatus.Winner)
            {
                case enWinner.player1:
                    labelWinner.Text = "Player 1";
                    break;
                case enWinner.player2:
                    labelWinner.Text = "Player 2";
                    break;
                case enWinner.Draw:
                    labelWinner.Text = "Draw";
                    break;
            }

           MessageBox.Show("GameOver", "GameOver", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public bool CheckValues(Button btn1, Button btn2, Button btn3)
        {
            if (btn1.Tag.ToString() != "?" && btn1.Tag.ToString() == btn2.Tag.ToString() && btn1.Tag.ToString() == btn3.Tag.ToString())
            {
                btn1.BackColor = Color.GreenYellow;
                btn2.BackColor = Color.GreenYellow;
                btn3.BackColor = Color.GreenYellow;

                Form Frm2 = new Form3();
                Frm2.Show();

                if (btn1.Tag.ToString() == "X")
                {
                    GameStatus.Winner = enWinner.player1;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }
                else
                {
                    GameStatus.Winner = enWinner.player2;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }
            }
            GameStatus.GameOver = false;
            return false;
        }
        public void CheckWinner()
        {
            if (CheckValues(button1, button2, button3))
                return;

            if (CheckValues(button1, button4, button7))
                return;

            if (CheckValues(button1, button5, button9))
                return;

            if (CheckValues(button2, button5, button8))
                return;

            if (CheckValues(button3, button6, button9))
                return;

            if (CheckValues(button3, button5, button7))
                return;

            if (CheckValues(button4, button5, button6))
                return;

            if (CheckValues(button7, button8, button9))
                return;
        }

        public void ChangeImage(Button btn)
        {
            if (btn.Tag.ToString() == "?")
            {
                switch (PlayerTurn)
                {
                    case enPlayer.player1:
                        btn.Image = Properties.Resources.X;
                        PlayerTurn = enPlayer.player2;
                        labelTurn.Text = "Player 2";
                        GameStatus.GameCount++;
                        btn.Tag = "X";
                        CheckWinner();
                        break; // Terminate case with break
                    case enPlayer.player2:
                        btn.Image = Properties.Resources.O;
                        PlayerTurn = enPlayer.player1;
                        labelTurn.Text = "Player 1";
                        GameStatus.GameCount++;
                        btn.Tag = "O";
                        CheckWinner();
                        break; // Terminate case with break
                }
            }
            else
            {
                MessageBox.Show("Wrong Choice", "Worng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (GameStatus.GameCount == 9)
            {
                Form Frm1 = new Form2();
                Frm1.Show();

                GameStatus.GameOver = true;
                GameStatus.Winner = enWinner.Draw;
                EndGame();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangeImage(button1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChangeImage(button2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChangeImage(button3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ChangeImage(button4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ChangeImage(button5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ChangeImage(button6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ChangeImage(button7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ChangeImage(button8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ChangeImage(button9);
        }

        public void RestartButton(Button btn)
        {
            btn.Image = Properties.Resources.question_mark_96;
            btn.Tag = "?";
            btn.BackColor = Color.Transparent;
        }

        public void RestartGame()
        {
            RestartButton(button1);
            RestartButton(button2);
            RestartButton(button3);
            RestartButton(button4);
            RestartButton(button5);
            RestartButton(button6);
            RestartButton(button7);
            RestartButton(button8);
            RestartButton(button9);

            PlayerTurn = enPlayer.player1;
            GameStatus.GameCount = 0;
            GameStatus.Winner = enWinner.GameInPeogess;
            GameStatus.GameOver = false;
            labelTurn.Text = "Player 1";
            labelWinner.Text = "In Progress";

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Color green = Color.FromArgb(250, 0, 250, 0);
            Pen pen = new Pen(green)
            {
                Width = 10,
                StartCap = System.Drawing.Drawing2D.LineCap.Round,
                EndCap = System.Drawing.Drawing2D.LineCap.Round
            };

            e.Graphics.DrawLine(pen, 400, 200, 700, 200);
            e.Graphics.DrawLine(pen, 400, 300, 700, 300);
            e.Graphics.DrawLine(pen, 500, 200, 500, 500);
            e.Graphics.DrawLine(pen, 600, 200, 600, 500);
            e.Graphics.DrawLine(pen, 400, 400, 700, 400);
            e.Graphics.DrawLine(pen, 400, 200, 400, 500);
            e.Graphics.DrawLine(pen, 700, 200, 700, 500);
            e.Graphics.DrawLine(pen, 400, 500, 700, 500);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
