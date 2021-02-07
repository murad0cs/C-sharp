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
    public partial class MakeTo_Let : Form
    {
        string conn = @"Server=.\SQLEXPRESS;Database=House;Integrated Security=true";

        public MakeTo_Let()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //SqlConnection conn = new SqlConnection(@"Server=DESKTOP-GA9SLOK;Database=House;Integrated Security=true");


            using (SqlConnection sqlcn = new SqlConnection(conn))
            {
                sqlcn.Open();
                SqlDataAdapter salda = new SqlDataAdapter("SELECT * FROM  ToLet1", sqlcn);
                DataTable d1 = new DataTable();
                salda.Fill(d1);
                dataGridView1.DataSource = d1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Server=.\SQLEXPRESS;Database=House;Integrated Security=true");
            conn.Open();
            try
            {
              
                string query = "";
                query = "INSERT INTO ToLet1 (Number,Floor,Number_of_Rooms,Free_From,Rent,Type,Contact) VALUES('" + int.Parse(textBox1.Text) + "','" + textBox2.Text + "','" + textBox3.Text + "','" + dateTimePicker1.Text + "','" + textBox4.Text + "','" + comboBox1.Text + "','" + textBox5.Text + "')";
               SqlCommand cmd = new SqlCommand(query, conn);
                 cmd.ExecuteNonQuery();
                MessageBox.Show("ToLet Added !!!");
            }
            catch (Exception c)
            {
                MessageBox.Show(c.Message);
            }
            conn.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection(@"Server=.\SQLEXPRESS;Database=House;Integrated Security=true");
            conn.Open();
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please Fill up the Number field!!", "Message");
            }
            else
            {


                string query1 = "";
                query1 = "DELETE FROM ToLet1   WHERE Number='" + int.Parse(textBox1.Text) + "';";
                SqlCommand cmd1 = new SqlCommand(query1, conn);
                cmd1.ExecuteNonQuery();

                MessageBox.Show("Successfully Deleted Tolet !!!", "Message");
            }

            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin a = new Admin();
            a.Show();
        }
    }
}
