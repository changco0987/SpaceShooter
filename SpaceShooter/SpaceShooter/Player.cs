using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SpaceShooter
{
    class Player : IDisposable
    {
        public PictureBox MyJet;
        public Form Container = new Form();
        public Image JetImage { get; set; }
        public int Speed { get; set; }
        public int projectileSpeed { get; set; }
        public int projectileWidth { get; set; }
        public int projectileHeight { get; set; }
        public int Left { get; set; }
        public int Top { get; set; }
        //Label healthDisplay;
        public static int health { get; set; }
        public static int bossHP { get; set;  }
        public Color projectileColor;
        public bool IsPlayer;
        public bool IsEntityDead { get; set; }

        public void Create(string tag, int height, int width) 
        {
            MyJet = new PictureBox();
            MyJet.SizeMode = PictureBoxSizeMode.StretchImage;
            MyJet.Top = Top;
            MyJet.Left = Left;
            MyJet.Image = JetImage;
            MyJet.BackColor = Color.Transparent;
            MyJet.Height = height;
            MyJet.Width = width;
            MyJet.Tag = tag;
            Container.Controls.Add(MyJet);
        }

        public void Move(string direction)
        {
            if (direction == "up")
            {
                MyJet.Top -= Speed;
            }
            else if (direction == "down") 
            {
                MyJet.Top += Speed;
            }
            else if (direction == "left")
            {
                MyJet.Left -= Speed;
            }
            else if (direction == "right")
            {
                MyJet.Left += Speed;
            }

        }

        //For projectile
        public virtual void Shoot()
        {
            Projectile projectile = new Projectile();
            if (IsEntityDead==false)
            {
                projectile.IsPlayer = IsPlayer;
                projectile.ProjectileColor = projectileColor;
                projectile.Height = projectileHeight;
                projectile.Width = projectileWidth;
                projectile.Speed = projectileSpeed;
                projectile.Left = MyJet.Left + (MyJet.Width / 2) - 2;
                projectile.Top = MyJet.Top - (projectile.Height / 2);
                projectile.Container = Container;
                projectile.Create();
            }
        }

        public void Dispose() 
        {
            MyJet.Dispose();
            JetImage.Dispose();
            GC.SuppressFinalize(MyJet);
        }
    }
}
