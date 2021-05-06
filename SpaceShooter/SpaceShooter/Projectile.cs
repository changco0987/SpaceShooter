using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace SpaceShooter
{
    class Projectile : IDisposable
    {
        public Color ProjectileColor { get; set; }
        public Form Container;
        public int Speed { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int Left { get; set; }
        public int Top { get; set; }
        public bool IsPlayer { get; set; }
        public PictureBox projectile { get; set; }
        public Timer projectileTimer { get; set; }
        Form1 mainScene;

        public void Create() 
        {
            projectile = new PictureBox();
            projectile.Height = Height;
            projectile.Width = Width;
            projectile.Left = Left;
            projectile.Top = Top;
            projectile.BackColor = ProjectileColor;
            Container.Controls.Add(projectile);
            projectileTimer = new Timer();
            projectileTimer.Interval = 50;
            projectileTimer.Tick += projectileTimer_Tick;
            projectileTimer.Start();

            if (IsPlayer)
            {
                projectile.Tag = "PlayerProjectile";
            }
            else 
            {
                projectile.Tag = "EnemyProjectile";
            }

        }

        public void Dispose()
        {
            projectile.Dispose();
            projectileTimer.Dispose();
            GC.SuppressFinalize(this);
        }

        private async void projectileTimer_Tick(object sender, EventArgs e)
        {
            /*
             * To make projectile move and then check if the projectile was outside of sight
             * in order to remove or disposed it
             */
            if (IsPlayer)
            {
                projectile.Top -= Speed;
                if (projectile.Top <= (Container.Top-200))
                {
                    projectileTimer.Stop();
                    Dispose();
                }

            }
            else 
            {
                projectile.Top += Speed;
                if (projectile.Top >= (Container.Height))
                {
                    projectileTimer.Stop();
                    Dispose();
                }
            }

            //To disposed the created projectile
            //if (projectile.Top >= (Container.Height))
            //{
            //    projectileTimer.Stop();
            //    Dispose();
            //    GC.SuppressFinalize(projectile);
            //}
            //else if (projectile.Top <= (Container.Height)) 
            //{
            //    projectileTimer.Stop();
            //    Dispose();
            //    GC.SuppressFinalize(projectile);
            //}


            if (projectile.Tag.ToString() == "PlayerProjectile")
            {
                foreach (var item in Container.Controls.OfType<PictureBox>())
                {
                    if (item.Tag.ToString() == "Enemy" && projectile.Bounds.IntersectsWith(item.Bounds))
                    {
                        Enemy enemy = new Enemy();

                        projectileTimer.Stop();
                        Dispose();
                        item.Image.Dispose();
                        item.Image = null;
                        showAnimatedPictureBox(item);
                        await Task.Delay(250);
                        item.Dispose();

                    }
                    else if (item.Tag.ToString() == "Boss" && projectile.Bounds.IntersectsWith(item.Bounds)) 
                    {
                        mainScene = new Form1();
                        projectileTimer.Stop();
                        Dispose();
                        Boss1.bossHP--;
                        if (mainScene.bossHPRefresh()) 
                        {
                            item.Image.Dispose();
                            item.Image = null;
                            showAnimatedPictureBox(item);
                            await Task.Delay(250);
                            item.Dispose();
                        }

                    }
                }
            }
            else if (projectile.Tag.ToString() == "EnemyProjectile") 
            {
                foreach (var item in Container.Controls.OfType<PictureBox>())
                {
                    if (item.Tag.ToString() == "Player" && projectile.Bounds.IntersectsWith(item.Bounds))
                    {
                        mainScene = new Form1();
                        Player.health--;

                        if (mainScene.healthRefresh())
                        {
                            projectileTimer.Stop();
                            Dispose();
                            item.Image.Dispose();
                            item.Image = null;
                            showAnimatedPictureBox(item);
                            await Task.Delay(250);
                            item.Dispose();

                            //To show the message box
                            CustomMessageBox msgBox = new CustomMessageBox();
                            msgBox.message = "Game Over";
                            msgBox.ShowDialog();

                            //To dispose or remove the previous game scene
                            Container.Dispose();

                            //To return in title screen
                            TitleScreen titleScreen = new TitleScreen();
                            titleScreen.ShowDialog();
                        }
                        else 
                        {
                            projectileTimer.Stop();
                            Dispose();
                        }


                    }
                }
            }
        }


        public void showAnimatedPictureBox(PictureBox thePicture)
        {
            thePicture.Image = Properties.Resources.explosion_anim3;
            thePicture.Refresh();
            thePicture.Visible = true;
        }
    }
}
