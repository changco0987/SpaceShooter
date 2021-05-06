using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace SpaceShooter
{
    class Boss1 : Player
    {
        public int TimeInterval { get; set; }
        private int projectileInterval = 20;
        public Timer bossMove = new Timer();
        int randomNum = 0;
        public void Move()
        {
            bossMove.Interval = 100;
            bossMove.Tick += bossMove_Tick;
            bossMove.Start();
        }

        public void bossMove_Tick(object sender, EventArgs e)
        {





            projectileInterval-=10;

            if (projectileInterval <= 0)
            {
                Shoot();
                Shoot();

                projectileInterval = 20;
                if (randomNum==3) 
                {
                    MyJet.Left -= 65;
                    randomNum=0;
                }
                if (randomNum==2) 
                {
                    MyJet.Left += 65;
                    randomNum++;
                }
                else if (randomNum == 1)
                {
                    MyJet.Left += 160;
                    randomNum++;
                }
                else
                {
                    MyJet.Left -= 160;
                    randomNum++;
                }
            }

            if (MyJet.IsDisposed)
            {
                bossMove.Stop();
                bossMove.Dispose();
                Dispose();
            }

        }

        public void bossAnimation1(PictureBox pictureBox) 
        {
            pictureBox.Image = Properties.Resources.YoungerBrotherSentMeACar3PNGP;
            pictureBox.Refresh();
            pictureBox.Visible = true;
        }
    }
}
