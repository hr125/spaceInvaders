using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceInvaders_v1
{
    public partial class Form1 : Form
    {
        SpaceInvaders spGame;

        public Form1()
        {
            InitializeComponent();

            spGame = new SpaceInvaders(pictureBoxPlayer,pictureBoxFiredShot,40,25,
                pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5,
                pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10,
                pictureBox11, pictureBox12, pictureBox13, pictureBox14, pictureBox15);

            spGame.UpdateEnemyPosition();
            
            
            spGame.ReadyToFire = false;
            Cursor.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //boundarys
            if (spGame.PlayerBoundaryRight(panel1.Size.Width))
                spGame.IfPlayerMeetsRightBounds(panel1.Size.Width);
            if (spGame.PlayerBoundaryLeft())
                spGame.IfPlayerMeetsLeftBounds();

            //move the player based on keyboard
            spGame.XLocationPlayer += spGame.XDirectionPlayer;//the x location changes based on xDirection which changes based on events
            
            //firing related stuff
            if (spGame.ReadyToFire)
                spGame.MoveShotUp();
            else
                spGame.MoveShotWithPlayer();

            //shots fired
            spGame.Collision();
            spGame.ShotOutOfBounds();

            spGame.ShowShotWhenFired();

            //set the images last
            pictureBoxFiredShot.Left = spGame.XLocationShot;
            pictureBoxFiredShot.Top = spGame.YlocationShot;
            pictureBoxPlayer.Left = spGame.XLocationPlayer;

            
        }
        private void timer2_Tick(object sender, EventArgs e)
        {//this timer is for only enemy movement
            spGame.MoveAllEnemies();
            spGame.UpdateEnemyPosition();

            if (spGame.AllEnemiesDead())
                timer2.Enabled = false;
            
        }

        #region KeyPress
        //key press stuff
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();

            if (e.KeyCode == Keys.Space)
                spGame.ReadyToFire = true;

            if (e.KeyCode == Keys.A)
                spGame.XDirectionPlayer = -2;
            if (e.KeyCode == Keys.D)
                spGame.XDirectionPlayer = 2;
        }


        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.D)
                spGame.XDirectionPlayer = 0;

        } 
        #endregion
    
    }
}
