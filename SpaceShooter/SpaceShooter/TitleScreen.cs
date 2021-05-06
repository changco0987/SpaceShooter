using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceShooter
{
    public partial class TitleScreen : Form
    {
        public TitleScreen()
        {
            InitializeComponent();
        }

        Form1 mainScene;

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            mainScene = new Form1();
            mainScene.jetImage = Properties.Resources.UK_Blenheim;
            mainScene.jetSpeed = 10;
            mainScene.projectileSpeed = 12;
            mainScene.projectileHeight = 8;
            mainScene.projectileWidth = 6;
            mainScene.projectileColor = Color.PowderBlue;

            this.Hide();
            mainScene.ShowDialog();
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            mainScene = new Form1();
            mainScene.jetImage = Properties.Resources.UK_Lancaster;
            mainScene.jetSpeed = 9;
            mainScene.projectileSpeed = 9;
            mainScene.projectileHeight = 11;
            mainScene.projectileWidth = 11;
            mainScene.projectileColor = Color.Peru;

            this.Hide();
            mainScene.ShowDialog();
            this.Close();
        }
    }
}
