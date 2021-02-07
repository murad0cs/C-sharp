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
using System.IO;

namespace Home_Management_System
{
    public partial class CareTakerInfo : Form
    {
        public CareTakerInfo()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            CareTakerHome ct = new CareTakerHome();
            ct.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login l = new Login();
            l.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                SqlConnection conn = new SqlConnection(@"Server=.\SQLEXPRESS;Database=House;Integrated Security=true");
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM CareTaker WHERE id= '" + textBox1.Text + "' AND Password= '" + textBox2.Text + "'", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Corrected user id and password");
                    if (textBox1.Text == "")
                    {
                        MessageBox.Show("Please Fill up Id & Password field!!", "Message");
                    }
                    else
                    {
                        string query = "";

                        query = "select id,Name,PerAddress,Phone,NID from CareTaker where id=" + int.Parse(textBox1.Text);

                        SqlCommand cmd2 = new SqlCommand(query, conn);
                        SqlDataAdapter da2 = new SqlDataAdapter(cmd2);

                        DataTable dt2 = new DataTable();
                        da2.Fill(dt2);
                        dataGridView1.DataSource = dt2;

                    }


                }
                else
                {
                    MessageBox.Show("Invalid Username or Password!!!\n       Please try again!", "Message");
                }
            }
            catch (Exception c)
            {
                MessageBox.Show(c.Message);
            }





            SqlConnection conn20 = new SqlConnection(@"Server=.\SQLEXPRESS;Database=House;Integrated Security=true");
            try
            {
                conn20.Open();
                string que = "SELECT Picture FROM CareTaker WHERE id=" + int.Parse(textBox1.Text);

                SqlCommand cmd = new SqlCommand(que, conn20);
                SqlDataReader DataRead = cmd.ExecuteReader();
                DataRead.Read();




                if (DataRead.HasRows)
                {

                    byte[] image = ((byte[])DataRead[0]);



                    if (image == null)
                    {
                        pictureBox1.Image = null;
                    }
                    else
                    {
                        MemoryStream mstram = new MemoryStream(image);
                        pictureBox1.Image = Image.FromStream(mstram);
                    }
                }
                else
                {
                    MessageBox.Show("No Picture found!!!");
                }
                conn20.Close();

            }
            catch (Exception c)
            {
                MessageBox.Show(c.Message);
            }

        }
    }
}
