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
    public partial class AdminComplainBox : Form
    {
        public AdminComplainBox()
        {
            InitializeComponent();
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Server=.\SQLEXPRESS;Database=House;Integrated Security=true");
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Renter WHERE id= '" + textBox1.Text + "'", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    string query = "";

                    query = "select Complain from ComplainBox where id=" + int.Parse(textBox1.Text);

                    SqlCommand cmd1 = new SqlCommand(query, conn);
                    // SqlDataAdapter da1 = new SqlDataAdapter(cmd1);


                    SqlDataReader mdr = cmd1.ExecuteReader();
                    if (mdr.Read())
                    {
                        textBox3.Text = mdr["Complain"].ToString();

                    }
                    else
                    {

                        textBox3.Text = "";
                        MessageBox.Show("NO Complain Found!!!", "Message");
                    }


                }
                else
                {
                    MessageBox.Show("     Invalid Id!!!\n Please try again!", "Message");
                }
                conn.Close();
            }

            catch (Exception c)
            {
                MessageBox.Show(c.Message);
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin a = new Admin();
            a.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string conn = @"Server=.\SQLEXPRESS;Database=House;Integrated Security=true";
            using (SqlConnection sqlcn = new SqlConnection(conn))
            {
               
                sqlcn.Open();
                SqlDataAdapter salda = new SqlDataAdapter("SELECT * FROM  ComplainBox", sqlcn);
                DataTable d1 = new DataTable();
                salda.Fill(d1);
                dataGridView1.DataSource = d1;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox3.Text = "";
        }
    }
}
