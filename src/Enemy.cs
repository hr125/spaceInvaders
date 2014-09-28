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
    class Enemy
    {
        private int xLoc;
        private int yLoc;

        private PictureBox enemyPic;
        private bool isDead;

        public Enemy(PictureBox e, int _xLoc, int _yLoc)
        {
            enemyPic = e;
            xLoc = _xLoc;
            yLoc = _yLoc;

            isDead = false;
        }
        //setters and getters
        public int XLocationEnemy
        {
            get { return xLoc; }
            set { xLoc = value; }
        }
        public int YLocationEnemy
        {
            get { return yLoc; }
            set { yLoc = value; }
        }
        public PictureBox EnemyPic
        {
            get { return enemyPic; }
            set { enemyPic = value; }
        }

        public bool IsDead
        {
            get { return isDead; }
            set { isDead = value; }
        }
        //methods
        public void SetEnemyPosition()
        {
            enemyPic.Location = new Point(xLoc, yLoc);
        }
        
        public void MoveInDirectionX(int direction)
        {
            xLoc += direction;
        }
        public void MoveInDirectionY(int direction)
        {
            yLoc += direction;
        }
        
    }
}
