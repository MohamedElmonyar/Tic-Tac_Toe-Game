using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Properties;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string NamePlayer,PictureOfPlayer;
        private void DefaultSystem() 
        {
            plPictures.Enabled = true;
            pictureBox1.Image = Resources.question;
            pictureBox2.Image = Resources.question;
            pictureBox3.Image = Resources.question;
            pictureBox4.Image = Resources.question;
            pictureBox5.Image = Resources.question;
            pictureBox6.Image = Resources.question;
            pictureBox7.Image = Resources.question;
            pictureBox8.Image = Resources.question;
            pictureBox9.Image = Resources.question;
            chkPlayers.Checked = true;
            NamePlayer = "Player 1"; 
            PictureOfPlayer = @"C:\Users\Mohamed Elmonaier\Pictures\O.JPG";
            laCurrentPlayer.Text = "Player 1";
            laPlayerWinner.Text = "In Progress";
        }

        enum GameResult
        {
            Draw,
            Win,
            Continue
        }
        private bool CheckWinner(PictureBox Picture)
        {
            Image playerImage = Picture.Image;

            if (playerImage == Resources.question)
                return false;

            return
                (playerImage.Width == pictureBox1.Image.Width && playerImage.Width  == pictureBox2.Image.Width && playerImage.Width == pictureBox3.Image.Width) ||
                (playerImage.Width == pictureBox4.Image.Width && playerImage.Width == pictureBox5.Image.Width && playerImage.Width == pictureBox6.Image.Width) ||
                (playerImage.Width == pictureBox7.Image.Width && playerImage.Width == pictureBox8.Image.Width && playerImage.Width == pictureBox9.Image.Width) ||

                (playerImage.Width == pictureBox1.Image.Width && playerImage.Width == pictureBox4.Image.Width && playerImage.Width == pictureBox7.Image.Width) ||
                (playerImage.Width == pictureBox2.Image.Width && playerImage.Width == pictureBox5.Image.Width && playerImage.Width == pictureBox8.Image.Width) ||
                (playerImage.Width == pictureBox3.Image.Width && playerImage.Width == pictureBox6.Image.Width && playerImage.Width == pictureBox9.Image.Width) ||

                (playerImage.Width == pictureBox1.Image.Width && playerImage.Width == pictureBox5.Image.Width && playerImage.Width == pictureBox9.Image.Width) ||
                (playerImage.Width == pictureBox3.Image.Width && playerImage.Width == pictureBox5.Image.Width && playerImage.Width == pictureBox7.Image.Width);
        }
        private GameResult CheckDraw(PictureBox Picture)
        {
            if (CheckWinner(Picture))
            {
                return GameResult.Win;
            }
            else if (pictureBox1.Image.Width != Resources.question.Width &&
                     pictureBox2.Image.Width != Resources.question.Width &&
                     pictureBox3.Image.Width != Resources.question.Width &&
                     pictureBox4.Image.Width != Resources.question.Width &&
                     pictureBox5.Image.Width != Resources.question.Width &&
                     pictureBox6.Image.Width != Resources.question.Width &&
                     pictureBox7.Image.Width != Resources.question.Width &&
                     pictureBox8.Image.Width != Resources.question.Width &&
                     pictureBox9.Image.Width != Resources.question.Width)
            {
                return GameResult.Draw;
            }
            else
            {
                return GameResult.Continue;
            }
        }
        private void CheckPlayer() 
        {
            if (chkPlayers.Checked)
            {
                NamePlayer = "Player 1";
                PictureOfPlayer = @"C:\Users\Mohamed Elmonaier\Pictures\O.JPG";
                laCurrentPlayer.Text = "Player 1";
            }
            else 
            {
               NamePlayer = "Player 2";
               PictureOfPlayer = @"C:\Users\Mohamed Elmonaier\Pictures\X.JPG";
               laCurrentPlayer.Text = "Player 2";
            }
        }
        private void CheckEnable()
        {
            if (chkPlayers.Checked)

                chkPlayers.Checked = false;
            else
                chkPlayers.Checked = true;
        }
        private void MessageWinner() 
        {
            MessageBox.Show(NamePlayer + " Winner", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);        
        }
        private void MessageDraw()
        {
            MessageBox.Show("Enter Restart if You Want Play Again", "Draw", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void MessageError()
        {
            MessageBox.Show("Wrong Choice", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void WhoWin(PictureBox Picture)
        {
            GameResult result = CheckDraw(Picture);

            if (result == GameResult.Draw)
            {
                plPictures.Enabled = false;
                laPlayerWinner.Text = "Draw";
                MessageDraw();
            }
            else if (result == GameResult.Win)
            {
                laPlayerWinner.Text = NamePlayer;
                MessageWinner();
                plPictures.Enabled = false;
            }
        }
        private void runChangePictures(PictureBox Picture) 
        {
            if (Picture.Image.Width == Resources.question.Width)
            {
                Picture.Image = Image.FromFile(PictureOfPlayer);
                WhoWin(Picture);           
                CheckEnable();
                CheckPlayer();
            }
            else
                MessageError();
        }
        private void pictureBox_Click(object sender, EventArgs e)
        {
            if(plPictures.Enabled)
            runChangePictures((PictureBox)sender);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            DefaultSystem();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            DefaultSystem();
        }
      

       




    }
}
