
namespace SpaceShooter
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.enemyTimer = new System.Windows.Forms.Timer(this.components);
            this.healthDisplay = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.boss1Timer = new System.Windows.Forms.Timer(this.components);
            this.methodUpdates = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // enemyTimer
            // 
            this.enemyTimer.Interval = 1000;
            this.enemyTimer.Tick += new System.EventHandler(this.enemyTimer_Tick);
            // 
            // healthDisplay
            // 
            this.healthDisplay.AutoSize = true;
            this.healthDisplay.BackColor = System.Drawing.Color.Transparent;
            this.healthDisplay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.healthDisplay.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.healthDisplay.ForeColor = System.Drawing.Color.Red;
            this.healthDisplay.Location = new System.Drawing.Point(38, 6);
            this.healthDisplay.Margin = new System.Windows.Forms.Padding(0);
            this.healthDisplay.Name = "healthDisplay";
            this.healthDisplay.Size = new System.Drawing.Size(62, 20);
            this.healthDisplay.TabIndex = 0;
            this.healthDisplay.Text = "label1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::SpaceShooter.Properties.Resources.PikPng_com_pixel_heart_png_305960;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(11, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(27, 26);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Tag = "lifeVisual";
            // 
            // boss1Timer
            // 
            this.boss1Timer.Interval = 10000;
            this.boss1Timer.Tick += new System.EventHandler(this.boss1Timer_Tick);
            // 
            // methodUpdates
            // 
            this.methodUpdates.Interval = 1000;
            this.methodUpdates.Tick += new System.EventHandler(this.methodUpdates_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::SpaceShooter.Properties.Resources.desert_backgorund_looped;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(601, 684);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.healthDisplay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer enemyTimer;
        private System.Windows.Forms.Label healthDisplay;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer boss1Timer;
        private System.Windows.Forms.Timer methodUpdates;
    }
}

