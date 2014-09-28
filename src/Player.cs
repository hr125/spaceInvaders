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
    class Player
    {
        private int xLocationPlayer;//location of where both the shot and the player are
        private int xDir;//this is only for the keybords movements
        private int xLocationShot;
        private int ylocationshot;//shot should be reset using this
        private bool readyToFire;
        private int yDirShot = 5;

        private PictureBox player;
        private PictureBox shot;

        public Player(PictureBox p, PictureBox s)
        {
            player = p;
            shot = s;

            xLocationPlayer = player.Location.X;//xLocation will move along with the shot as well
            xLocationShot = player.Location.X + (player.Size.Width / 2) - (shot.Size.Width / 2);
            ylocationshot = player.Location.Y;

            shot.Visible = false;
        }

        //setters and getters
        public PictureBox Shot
        {
            get { return shot; }
            set { shot = value; }
        }
        public int XLocationPlayer
        {
            get { return xLocationPlayer; }
            set { xLocationPlayer = value; }
        }
        public int XLocationShot
        {
            get { return xLocationShot; }
            set { xLocationShot = value; }
        }

        public int XDirection//where the player moves
        {
            get { return xDir; }
            set { xDir = value; }
        }
        
        public int YlocationShot
        {
            get { return ylocationshot; }
            set { ylocationshot = value; }
        }

        public bool ReadyToFire
        {
            get { return readyToFire; }
            set { readyToFire = value; }
        }

        //methods
        
        //boundary detection
        public bool PlayerBoundaryRight(int panelSizeWidth)
        {
            if (player.Location.X + player.Size.Width >= panelSizeWidth)
                return true;
            else
                return false;
        }
        public bool PlayerBoundaryLeft()
        {
            if (player.Location.X <= 0)
                return true;
            else
                return false;
        }

        public void IfPlayerMeetsRightBounds(int panelSizeWidth)
        {
            xLocationPlayer = panelSizeWidth - player.Size.Width;
        }
        public void IfPlayerMeetsLeftBounds()
        {
            xLocationPlayer = 0;
        }

        //players shot
        public void MoveShotWithPlayer()
        {
            xLocationShot = player.Location.X + (player.Size.Width / 2) - (shot.Size.Width / 2); 
        }
        public void ResetShotYPos()
        {
            ylocationshot = player.Top;
        }
        public void MoveShotUp()
        {
            YlocationShot -= yDirShot;
        }
        public void ShowShotWhenFired()
        {
            if (readyToFire)
                shot.Visible = true;
            else
                shot.Visible = false;
        }
    }
}
