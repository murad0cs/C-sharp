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
    public partial class ComplainBox : Form
    {
        public ComplainBox()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Server=.\SQLEXPRESS;Database=House;Integrated Security=true");
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Renter WHERE id= '" + textBox1.Text + "' AND Password= '" + textBox2.Text + "'", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    MessageBox.Show("Corrected user id and password & submitted the Complain to the admin, we will knock you soon.");
                    string query1 = "";
                    query1 = "UPDATE  ComplainBox SET Complain ='" + textBox3.Text + "' WHERE id='" + textBox1.Text + "';";

                    SqlCommand cmd2 = new SqlCommand(query1, conn);
                    cmd2.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password!!!\n\t Please try again!", "Message");
                }



                conn.Close();
            }

            catch (Exception c)
            {
                MessageBox.Show(c.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            RenterHome a = new RenterHome();
            a.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login a = new Login();
            a.Show();
        }
    }
}
