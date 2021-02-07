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
    public partial class Meal : Form
    {
        SqlDataReader mdr;
        string conn = @"Server=.\SQLEXPRESS;Database=House;Integrated Security=true";
        public Meal()
        {
            InitializeComponent();
        }

        private void Meal_Load(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlcn = new SqlConnection(conn))
            {
                sqlcn.Open();
                SqlDataAdapter salda = new SqlDataAdapter("SELECT * FROM  Meal", sqlcn);
                DataTable d1 = new DataTable();
                salda.Fill(d1);
                dataGridView1.DataSource = d1;
            }
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin a = new Admin();
            a.Show();
        }

        private void Button5_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection(@"Server=.\SQLEXPRESS;Database=House;Integrated Security=true");
            conn.Open();

            if (textBox1.Text == "")
            {
                MessageBox.Show("Please Fill up the ID field !!!", "Message");

            }

            if ( textBox2.Text == "" )
            {
                MessageBox.Show("Please Fill up the Meal Rate field !!!", "Message");

            }

             if(textBox3.Text == "")
            {
                MessageBox.Show("Please Fill up the Total Meal field !!!", "Message");
            }
            else
            {
                try
                {
                    int mul = 1;
                    mul = Convert.ToInt32(textBox2.Text) * Convert.ToInt32(textBox3.Text);
                    string mul1 = Convert.ToString(mul);

                    textBox4.Text = mul1;
                }
                catch (Exception c)
                {
                    MessageBox.Show(c.Message);
                }

            }
           
           
            conn.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

           if(textBox1.Text =="")
            {
                MessageBox.Show("Please Fill up the ID field !!!", "Message");
            }

            if (textBox2.Text == "")
            {
                MessageBox.Show("Please Fill up the Meal Rate field !!!", "Message");
            }
            if (textBox3.Text == "")
            {
                MessageBox.Show("Please Fill up the Total Meal field !!!", "Message");
            }
            if (textBox4.Text == "")
            {
                MessageBox.Show("Please Fill up the Amount field !!!", "Message");
            }
            else
            {
                try
                {
                    SqlConnection conn = new SqlConnection(@"Server=.\SQLEXPRESS;Database=House;Integrated Security=true");
                    conn.Open();
                    string query = "";



                    query = "UPDATE Meal SET MealRate = '" + textBox2.Text + "',TotalMeal='" + textBox3.Text + "',Amount='" + textBox4.Text + "'  WHERE id='" + textBox1.Text + "';";


                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Successfully Updated Account!!!", "Message");



                    string query2 = "";
                    query2 = "UPDATE  Account SET Meal_Bill ='" + textBox4.Text + "' WHERE id='" + textBox1.Text + "';";

                    SqlCommand cmd2 = new SqlCommand(query2, conn);
                    cmd2.ExecuteNonQuery();

                    conn.Close();
                }



                catch (Exception c)
                {
                    MessageBox.Show(c.Message);
                }


            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Server=.\SQLEXPRESS;Database=House;Integrated Security=true");
                conn.Open();

                string query = "";

                query = "select * from Meal where id=" + int.Parse(textBox1.Text);

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                mdr = cmd.ExecuteReader();
                if (mdr.Read())
                {
                    textBox2.Text = mdr["MealRate"].ToString();
                    textBox3.Text = mdr["TotalMeal"].ToString();
                    textBox4.Text = mdr["Amount"].ToString();

                }
                else
                {

                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    MessageBox.Show("NO Data Found!!!", "Message");
                }


                conn.Close();
            }
            catch (Exception c)
            {
                MessageBox.Show(c.Message);
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
    }
}
