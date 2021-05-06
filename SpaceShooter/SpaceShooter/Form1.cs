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
    public partial class Form1 : Form
    {
        //To avoid the windows form from flickering
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParams = base.CreateParams;
                handleParams.ExStyle |= 0x02000000;
                return handleParams;
            }
        }
        //To avoid the screen from stuttering to make the object movement smooth
        public static void enableDoubleBuff(System.Windows.Forms.Control cont)
        {
            System.Reflection.PropertyInfo DemoProp = typeof(System.Windows.Forms.Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            DemoProp.SetValue(cont, true, null);
        }

        //Global variables
        Player jet1;
        Boss1 boss;
        public int jetSpeed;
        public Image jetImage;
        public int projectileSpeed;
        public int projectileHeight;
        public int projectileWidth;
        public Color projectileColor;


        public Form1()
        {
            InitializeComponent();
            //Jet1
            jet1 = new Player();
        }

        private async void boss1Timer_Tick(object sender, EventArgs e)
        {    
            enemyTimer.Stop();
            enemyTimer.Dispose();

            await Task.Delay(3100);
            boss = new Boss1();
            boss.IsPlayer = false;
            boss.Container = this;
            boss.Speed = 10;
            boss.projectileSpeed = 30;
            Boss1.bossHP = 100;

            boss.JetImage = Properties.Resources.boss1_3_;
            boss.projectileColor = Color.Crimson;

            boss.Left = (this.Width / 2)-245;
            boss.Top = this.Top-250;
            boss.projectileHeight = 10;
            boss.projectileWidth = 10;
            boss.IsEntityDead = false;
            boss.Create("Boss",500,500);

            await Task.Delay(3050);
            boss.JetImage.Dispose();
            boss.MyJet.Image = null;
            boss.bossAnimation1(boss.MyJet);
            boss.Move();

            boss1Timer.Stop();
            boss1Timer.Dispose();
        }

        private void enemyTimer_Tick(object sender, EventArgs e)
        {
            Enemy enemy = new Enemy();
            enemy.IsPlayer = false;
            enemy.Container = this;
            enemy.Speed = 10;
            enemy.projectileSpeed = 20;
            enemy.JetImage = Properties.Resources.US_p47;
            enemy.projectileColor = Color.Red;
            Random random = new Random();
            enemy.Left = random.Next(this.Width);
            enemy.Top = this.Top-200;
            enemy.projectileHeight = 8;
            enemy.projectileWidth = 8;
            enemy.IsEntityDead = false;
            enemy.Create("Enemy",100,100);
            enemy.Move();
        }

        private void methodUpdates_Tick(object sender, EventArgs e)
        {
            healthRefresh();
            bossHPRefresh();



        }

        public bool healthRefresh() 
        {

            healthDisplay.Text = Player.health.ToString();

            if (Player.health==0) 
            {
                return true;
            }

            return false;
        }

        public bool bossHPRefresh() 
        {


            if (Boss1.bossHP == 0)
            {
                return true;
            }

            return false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            jet1.Container = this;
            jet1.IsPlayer = true;
            jet1.Speed = jetSpeed;
            Player.health = 3;
            healthRefresh();



            jet1.JetImage = jetImage;
            jet1.projectileSpeed = projectileSpeed;
            jet1.projectileHeight = projectileHeight;
            jet1.projectileWidth = projectileWidth;
            jet1.projectileColor = projectileColor;


            jet1.Left = (this.Width / 2) - 60;
            jet1.Top = this.Height - 130;
            jet1.IsEntityDead = false;
            jet1.Create("Player",100,100);
            enemyTimer.Start();
            boss1Timer.Start();
            methodUpdates.Start();
            this.DoubleBuffered = true;
            enableDoubleBuff(jet1.MyJet);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                jet1.Move("up");
            }
            else if (e.KeyCode == Keys.Down)
            {
                jet1.Move("down");
            }
            else if (e.KeyCode == Keys.Left)
            {
                jet1.Move("left");
            }
            else if (e.KeyCode == Keys.Right)
            {
                jet1.Move("right");
            }

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                jet1.Shoot();
            }
        }


    }
}
