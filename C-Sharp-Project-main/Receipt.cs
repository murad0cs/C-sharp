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
    public partial class Receipt : Form
    {
        public Receipt()
        {
            InitializeComponent();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //Bitmap ObjectOfBit = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
           // dataGridView1.DrawToBitmap(ObjectOfBit, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));
           // e.Graphics.DrawImage(ObjectOfBit, 220, 120);
            e.Graphics.DrawString(label1.Text, new Font("Times new roman", 20, FontStyle.Italic), Brushes.Blue, new Point(250, 30));
            e.Graphics.DrawString(label3.Text, new Font("Times new roman", 15, FontStyle.Regular), Brushes.Green, new Point(226, 168));
            e.Graphics.DrawString(textBox1.Text, new Font("Times new roman", 15, FontStyle.Regular), Brushes.Black, new Point(305,168));
            e.Graphics.DrawString(label4.Text, new Font("Times new roman", 15, FontStyle.Regular), Brushes.Green, new Point(170, 229));
            e.Graphics.DrawString(dateTimePicker1.Text, new Font("Times new roman", 15, FontStyle.Regular), Brushes.Black, new Point(305, 229));
            e.Graphics.DrawString(label2.Text, new Font("Times new roman", 15, FontStyle.Regular), Brushes.Green, new Point(224, 281));
            e.Graphics.DrawString(textBox2.Text, new Font("Times new roman", 15, FontStyle.Regular), Brushes.Black, new Point(305, 281));
            e.Graphics.DrawString(label5.Text, new Font("Times new roman", 15, FontStyle.Regular), Brushes.Green, new Point(247, 107));
            e.Graphics.DrawString(textBox3.Text, new Font("Times new roman", 15, FontStyle.Regular), Brushes.Black, new Point(305, 107));
            e.Graphics.DrawString(label6.Text, new Font("Times new roman", 15, FontStyle.Regular), Brushes.Green, new Point(209, 345));
            e.Graphics.DrawString(textBox4.Text, new Font("Times new roman", 15, FontStyle.Regular), Brushes.Black, new Point(305, 345));
            e.Graphics.DrawString(label7.Text, new Font("Times new roman", 15, FontStyle.Regular), Brushes.Green, new Point(232, 399));
            e.Graphics.DrawString(textBox5.Text, new Font("Times new roman", 15, FontStyle.Regular), Brushes.Black, new Point(305, 399));
            e.Graphics.DrawString(label8.Text, new Font("Times new roman", 15, FontStyle.Regular), Brushes.Green, new Point(194, 447));
            e.Graphics.DrawString(textBox6.Text, new Font("Times new roman", 15, FontStyle.Regular), Brushes.Black, new Point(305, 447));
            e.Graphics.DrawString(label9.Text, new Font("Times new roman", 15, FontStyle.Regular), Brushes.Green, new Point(207, 490));
            e.Graphics.DrawString(textBox7.Text, new Font("Times new roman", 15, FontStyle.Regular), Brushes.Black, new Point(305, 490));
            e.Graphics.DrawString(label10.Text, new Font("Times new roman", 20, FontStyle.Italic), Brushes.Blue, new Point(339, 569));

        }

        private void Print_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin a = new Admin();
            a.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login a = new Login();
            a.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Server=.\SQLEXPRESS;Database=House;Integrated Security=true");
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Account WHERE id= '" + textBox3.Text + "'", conn);
                SqlCommand cmd1 = new SqlCommand("SELECT * FROM Renter WHERE id= '" + textBox3.Text + "'", conn);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);


                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    string query = "";

                    query = "select Balance,Total_Bill from Account where id=" + int.Parse(textBox3.Text);

                    SqlCommand cmd2 = new SqlCommand(query, conn);
                    SqlDataReader mdr = cmd2.ExecuteReader();
                    if (mdr.Read())
                    {
                        textBox4.Text = mdr["Total_Bill"].ToString();
                        textBox7.Text = mdr["Balance"].ToString();


                    }
                    else
                    {

                        textBox4.Text = "";
                        textBox7.Text = "";
                        MessageBox.Show("NO Data Found!!!", "Message");
                    }


                }
                else
                {
                    MessageBox.Show("    Invalid Id!!!\n Please try again!", "Message");
                }
                conn.Close();
                conn.Open();
                DataTable dt1 = new DataTable();
                da.Fill(dt1);
                if (dt1.Rows.Count > 0)
                {
                    string query = "";

                    query = "select Name from Renter where id=" + int.Parse(textBox3.Text);

                    SqlCommand cmd2 = new SqlCommand(query, conn);
                    SqlDataReader mdr1 = cmd2.ExecuteReader();
                    if (mdr1.Read())
                    {
                        textBox1.Text = mdr1["Name"].ToString();
                    }
                    else
                    {
                        textBox1.Text = "";
                        MessageBox.Show("NO Data Found!!!", "Message");
                    }


                }
                else
                {
                    MessageBox.Show("    Invalid Id!!!\n  Please try again!", "Message");
                }
                conn.Close();
            }
            catch (Exception c)
            {
                MessageBox.Show(c.Message);
            }
        }

        private void Receipt_Load(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
