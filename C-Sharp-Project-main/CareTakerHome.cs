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
    public partial class CareTakerHome : Form
    {
        public CareTakerHome()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            CareTakerInfo ci = new CareTakerInfo();
            ci.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login l = new Login();
            l.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewRenterAccount vra = new ViewRenterAccount();
            vra.Show();
        }
    }
}
