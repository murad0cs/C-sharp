using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Home_Management_System
{
    public partial class RenterHome : Form
    {
        public RenterHome()
        {
            InitializeComponent();
        }

        private void RenterHome_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Renterinfo a = new Renterinfo();
            a.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login a = new Login();
            a.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Renterbalance a = new Renterbalance();
            a.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            ComplainBox a = new ComplainBox();
            a.Show();
        }
    }
}
