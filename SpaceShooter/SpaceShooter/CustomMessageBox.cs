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
    public partial class CustomMessageBox : Form
    {
        public CustomMessageBox()
        {
            InitializeComponent();
        }

        public string message { get; set; }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            

            this.Close();
        }

        private void CustomMessageBox_Load(object sender, EventArgs e)
        {
            msgLabel.Text = message;
        }
    }
}
