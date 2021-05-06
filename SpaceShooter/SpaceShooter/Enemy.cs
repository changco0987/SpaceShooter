using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SpaceShooter
{
    class Enemy : Player
    {
        public int TimeInterval { get; set; }
        private int projectileInterval = 20; 
        public Timer enemyMove = new Timer();
        public void Move()
        {
            enemyMove.Interval = 120;
            enemyMove.Tick += enemyMove_Tick;
            enemyMove.Start();
        }

        public void enemyMove_Tick(object sender, EventArgs e)
        {
            MyJet.Top += Speed;
            projectileInterval--;

            if (projectileInterval == 0)
            {
                Shoot();
                projectileInterval = 20;
            }

            if (MyJet.Top >= 780 || MyJet.IsDisposed)
            {
                enemyMove.Stop();
                enemyMove.Dispose();
                Dispose();
            }
 

        }




    }
}
