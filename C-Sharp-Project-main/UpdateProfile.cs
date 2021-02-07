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
    public partial class UpdateProfile : Form
    {
        public UpdateProfile()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            UpdateRenter ur = new UpdateRenter();
            ur.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin a = new Admin();
            a.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            UpdateCareTaker uc = new UpdateCareTaker();
            uc.Show();
        }
    }
}
