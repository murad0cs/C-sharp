using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Home_Management_System
{
    public partial class ToLet : Form
    {
        string conn = @"Server=.\SQLEXPRESS;Database=House;Integrated Security=true";
        public ToLet()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlcn = new SqlConnection(conn))
            {
                sqlcn.Open();
                SqlDataAdapter salda = new SqlDataAdapter("SELECT * FROM  ToLet1", sqlcn);
                DataTable d1 = new DataTable();
                salda.Fill(d1);
                dataGridView1.DataSource = d1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login l = new Login();
            l.Show();
        }
    }
}
