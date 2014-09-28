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
    class SpaceInvaders
    {
        private Player player;
        private List<Enemy> enemy;

        public SpaceInvaders(PictureBox p, PictureBox s, int initEnemyX,int initEnemyY,
            PictureBox enemy1Pic, PictureBox enemy2Pic, PictureBox enemy3Pic, PictureBox enemy4Pic, PictureBox enemy5Pic,
            PictureBox enemy6Pic, PictureBox enemy7Pic, PictureBox enemy8Pic, PictureBox enemy9Pic, PictureBox enemy10Pic,
            PictureBox enemy11Pic, PictureBox enemy12Pic, PictureBox enemy13Pic, PictureBox enemy14Pic, PictureBox enemy15Pic)
        {
            player = new Player(p,s);
            enemy = new List<Enemy>();

            enemy.Add(new Enemy(enemy1Pic,initEnemyX,initEnemyY ));
            enemy.Add(new Enemy(enemy2Pic, initEnemyX + 55, initEnemyY ));
            enemy.Add(new Enemy(enemy3Pic, initEnemyX + 110, initEnemyY));
            enemy.Add(new Enemy(enemy4Pic, initEnemyX + 165, initEnemyY));
            enemy.Add(new Enemy(enemy5Pic, initEnemyX + 220, initEnemyY));

            enemy.Add(new Enemy(enemy6Pic, initEnemyX, initEnemyY + 50));
            enemy.Add(new Enemy(enemy7Pic, initEnemyX + 55, initEnemyY + 50));
            enemy.Add(new Enemy(enemy8Pic, initEnemyX + 110, initEnemyY + 50));
            enemy.Add(new Enemy(enemy9Pic, initEnemyX + 165, initEnemyY + 50));
            enemy.Add(new Enemy(enemy10Pic, initEnemyX + 220, initEnemyY + 50));

            enemy.Add(new Enemy(enemy11Pic, initEnemyX, initEnemyY + 100));
            enemy.Add(new Enemy(enemy12Pic, initEnemyX + 55, initEnemyY + 100));
            enemy.Add(new Enemy(enemy13Pic, initEnemyX + 110, initEnemyY + 100));
            enemy.Add(new Enemy(enemy14Pic, initEnemyX + 165, initEnemyY + 100));
            enemy.Add(new Enemy(enemy15Pic, initEnemyX + 220, initEnemyY + 100));
        }
        public bool AllEnemiesDead()
        {
            int numEnemiesDead = 0;

            foreach (Enemy e in enemy)
            {
                if (e.IsDead)
                    numEnemiesDead++;
            }

            if (numEnemiesDead == enemy.Count)
                return true;
            else return false;
        }

        //shot and enemy collison method
        public void Collision()
        {
            foreach (Enemy e in enemy)
            {
                if (e.EnemyPic.Bounds.IntersectsWith(player.Shot.Bounds) && !e.IsDead)
                {
                    e.IsDead = true;
                    e.EnemyPic.Visible = false;

                    ReadyToFire = false;
                    player.ResetShotYPos();
                }
            }
        }
        public void ShotOutOfBounds()
        {
            if (player.YlocationShot < 0)
            {
                ReadyToFire = false;
                player.ResetShotYPos();
            }
        }

        public void ShowShotWhenFired()
        {
            player.ShowShotWhenFired();
        }

        //methods for enemy
        public void UpdateEnemyPosition()
        {
            foreach (Enemy e in enemy)
                e.SetEnemyPosition();
        }

        private int xdAllEnemies = 10;
        private int ydAllEnemies = 30;
        private bool movedInY = false;//test to see if they all need to move in the y direction or not 

        public void MoveAllEnemies()//if enemies hit either side of the panel they move down and go opposite x diretion
        {//30 is leftside max of panel, 395 is left side
            
            //first find which x direction it should move in
            if (enemy[0].XLocationEnemy <= 30)
                xdAllEnemies = 10;
                
            if (enemy[4].XLocationEnemy >= 395)
                xdAllEnemies = -10;

            //move in y first if conitions are met then start moveing in x
            if ((enemy[0].XLocationEnemy <= 30 || enemy[4].XLocationEnemy >= 395) && !movedInY)
            {
                foreach (Enemy e in enemy)
                    e.MoveInDirectionY(ydAllEnemies);

                movedInY = true;
            }
            else
            {
                foreach (Enemy e in enemy)
                    e.MoveInDirectionX(xdAllEnemies);

                movedInY = false;
            }
            
        }

        //setters and getters 
        public int XLocationPlayer
        {
            get { return player.XLocationPlayer; }
            set { player.XLocationPlayer = value; }
        }
        public int XLocationShot
        {
            get { return player.XLocationShot; }
            set { player.XLocationShot = value; }
        }
        public int YlocationShot
        {
            get { return player.YlocationShot; }
            set { player.YlocationShot = value; }
        }
        public int XDirectionPlayer
        {
            get { return player.XDirection; }
            set { player.XDirection = value; }
        }

        
        public bool ReadyToFire
        {
            get { return player.ReadyToFire; }
            set { player.ReadyToFire = value; }
        }

        

        //methods for player
        public bool PlayerBoundaryRight(int panelSizeWidth)
        {
            if (player.PlayerBoundaryRight(panelSizeWidth))
                return true;
            else
                return false;
        }
        public bool PlayerBoundaryLeft()
        {
            if (player.PlayerBoundaryLeft())
                return true;
            else
                return false;
        }
        public void IfPlayerMeetsRightBounds(int panelSizeWidth)
        {
            player.IfPlayerMeetsRightBounds(panelSizeWidth);
        }
        public void IfPlayerMeetsLeftBounds()
        {
            player.IfPlayerMeetsLeftBounds();
        }
        public void MoveShotWithPlayer()
        {
            player.MoveShotWithPlayer();
        }
        public void MoveShotUp()
        {
            player.MoveShotUp();
        }
        
        
    }
}
