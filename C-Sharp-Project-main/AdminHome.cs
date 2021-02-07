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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void SignUpBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sign_Up sn = new Sign_Up();

            sn.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void loginBtn_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Account a = new Account();

            a.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sign_Up r1 = new Sign_Up();
            r1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateCareTaker ct = new CreateCareTaker();
            ct.Show();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login ll = new Login();
            ll.Show();
        }

        private void MealBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Meal m = new Meal();
            m.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Receipt a = new Receipt();
            a.Show();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminComplainBox ac = new AdminComplainBox();
            ac.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            UpdateProfile up = new UpdateProfile();
            up.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            MakeTo_Let a = new MakeTo_Let();
            a.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            updateAdmin ua = new updateAdmin();
            ua.Show();
        }
    }
}
