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
using DGVPrinterHelper;

namespace Home_Management_System
{
    public partial class Renterbalance : Form
    {
        public Renterbalance()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Server=.\SQLEXPRESS;Database=House;Integrated Security=true");
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Login WHERE id= '" + textBox1.Text + "' AND Password= '" + textBox2.Text + "'", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Corrected user id and password");
                    if (textBox1.Text == "")
                    {
                        MessageBox.Show("Please give input in Id field!!", "Message");
                    }
                    else
                    {
                        string query = "";

                        query = "select * from Account where id=" + int.Parse(textBox1.Text);

                        SqlCommand cmd2 = new SqlCommand(query, conn);
                        SqlDataAdapter da2 = new SqlDataAdapter(cmd2);

                        DataTable dt2 = new DataTable();
                        da2.Fill(dt2);
                        dataGridView1.DataSource = dt2;
                    }

                }
                else
                {
                    MessageBox.Show("Invalid Username or Password!!!\n    Please try again!", "Message");
                }
            }
            catch (Exception c)
            {
                MessageBox.Show(c.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            RenterHome a = new RenterHome();
            a.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login l = new Login();
            l.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Server=.\SQLEXPRESS;Database=House;Integrated Security=true");
            conn.Open();
            DGVPrinter a = new DGVPrinter();
            a.Title = " Renter Balance";
            a.SubTitle = String.Format("Date: {0}", DateTime.Now.Date.ToString("MM/dd/yyyy"));
            a.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            a.PageNumbers = true;
            a.PageNumberInHeader = false;
            a.PorportionalColumns = true;
            a.HeaderCellAlignment = StringAlignment.Near;
            a.Footer = "Printed By user "+textBox1.Text;
            a.FooterSpacing = 15;
            a.PrintDataGridView(dataGridView1);
            
            conn.Close();
        }
    }
}
