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
    public partial class Account : Form
    {
        string conn = @"Server=.\SQLEXPRESS;Database=House;Integrated Security=true";
        public Account()
        {
            InitializeComponent();
        }

        private void Account_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlcn = new SqlConnection(conn))
            {
                sqlcn.Open();
                SqlDataAdapter salda = new SqlDataAdapter("SELECT * FROM  Account", sqlcn);
                DataTable d1 = new DataTable();
                salda.Fill(d1);
                balancedata.DataSource = d1;
            }
        }

        private void balancedata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            SqlConnection conn = new SqlConnection(@"Server=.\SQLEXPRESS;Database=House;Integrated Security=true");
            conn.Open();
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please Fill up the Id field!!", "Message");
            }
            else
            {
                try
                {
                    string query = "";

                    query = "UPDATE Account SET Balance = '" + txtbalance.Text + "',Rent='" + txtrent.Text + "',Electricity_Bill='" + txtelectricity.Text + "',Water_Bill='" + txtwater.Text + "',Utility='" + txtutility.Text + "',Penalty='" + txtpenalty.Text + "',Meal_Bill='" + txtmeal.Text + "',Total_Bill='" + txttotalbill.Text + "'  WHERE id='" + textBox1.Text + "';";


                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Successfully Updated Account!!!", "Message");



                    string query1 = "";
                    query1 = "UPDATE Meal SET Amount ='" + txtmeal.Text + "' WHERE id='" + textBox1.Text + "';";

                    SqlCommand cmd2 = new SqlCommand(query1, conn);
                    cmd2.ExecuteNonQuery();
                }

                catch (Exception c)
                {
                    MessageBox.Show(c.Message);
                }

            }
          
            conn.Close();

        }

      

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Server=.\SQLEXPRESS;Database=House;Integrated Security=true");
            conn.Open();


            if(txtrent.Text == "")
            {
                MessageBox.Show("Please Fill up the Rent field !!!", "Message");
            }
            if (txtelectricity.Text == "")
            {
                MessageBox.Show("Please Fill up the Electricity Bill field !!!", "Message");
            }
            if (txtwater.Text == "")
            {
                MessageBox.Show("Please Fill up the Water Bill field !!!", "Message");
            }
            if (txtutility.Text == "")
            {
                MessageBox.Show("Please Fill up the Utility field !!!", "Message");
            }
            if (txtpenalty.Text == "")
            {
                MessageBox.Show("Please Fill up the Penalty field !!!", "Message");

            }
            if (txtmeal.Text == "")
            {
                MessageBox.Show("Please Fill up the Meal Bill field !!!", "Message");
            }

            else
            {
                try
                {
                    int sum = 0;
                    sum = Convert.ToInt32(txtrent.Text) + Convert.ToInt32(txtelectricity.Text) + Convert.ToInt32(txtwater.Text) + Convert.ToInt32(txtutility.Text) + Convert.ToInt32(txtpenalty.Text) + Convert.ToInt32(txtmeal.Text);
                    string sum1 = Convert.ToString(sum);

                    txttotalbill.Text = sum1;

                    int sub;
                    sub = Convert.ToInt32(txtbalance.Text) - Convert.ToInt32(txttotalbill.Text);
                    string sub1 = Convert.ToString(sub);
                    txtcurrent.Text = sub1;

                }
                catch (Exception c)
                {
                    MessageBox.Show(c.Message);
                }



            }


           


            conn.Close();

        }

        private void txtwater_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin a = new Admin();
            a.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Server=.\SQLEXPRESS;Database=House;Integrated Security=true");


            conn.Open();
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please give input in Id field!!", "Message");
            }
            else
            {
                try
                {
                    string query = "";
                    query = "DELETE FROM Account   WHERE id='" + textBox1.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();

                    string query1 = "";
                    query1 = "DELETE FROM Login   WHERE id='" + textBox1.Text + "';";
                    SqlCommand cmd1 = new SqlCommand(query1, conn);
                    cmd1.ExecuteNonQuery();

                    string query2 = "";
                    query2 = "DELETE FROM Renter   WHERE id='" + textBox1.Text + "';";
                    SqlCommand cmd2 = new SqlCommand(query2, conn);
                    cmd2.ExecuteNonQuery();

                    string query3 = "";
                    query3 = "DELETE FROM CareTaker   WHERE id='" + textBox1.Text + "';";
                    SqlCommand cmd3 = new SqlCommand(query3, conn);
                    cmd3.ExecuteNonQuery();

                    string query4 = "";
                    query4 = "DELETE FROM ComplainBox   WHERE id='" + textBox1.Text + "';";
                    SqlCommand cmd4 = new SqlCommand(query4, conn);
                    cmd4.ExecuteNonQuery();

                    string query5 = "";
                    query5 = "DELETE FROM Meal   WHERE id='" + textBox1.Text + "';";
                    SqlCommand cmd5 = new SqlCommand(query5, conn);
                    cmd5.ExecuteNonQuery();



                    MessageBox.Show("Successfully Deleted Account!!!", "Message");
                }

                catch (Exception c)
                {
                    MessageBox.Show(c.Message);
                }
            }

           
            conn.Close();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            txtbalance.Text = "";
            txtelectricity.Text = "";
            txtmeal.Text = "";
            txtcurrent.Text = "";
            txtpenalty.Text = "";
            txtrent.Text = "";
            txttotalbill.Text = "";
            txtutility.Text = "";
            txtwater.Text = "";
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Server=.\SQLEXPRESS;Database=House;Integrated Security=true");
            conn.Open();

            if(textBox1.Text == "")
            {
                MessageBox.Show("Please Fill up the Id field!!", "Message");
            }
            else
            {
                try
                {
                    string query = "";

                    query = "select * from Account where id=" + int.Parse(textBox1.Text);

                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    balancedata.DataSource = dt;

                    SqlDataReader mdr = cmd.ExecuteReader();
                    if (mdr.Read())
                    {
                        txtbalance.Text = mdr["Balance"].ToString();
                        txtrent.Text = mdr["Rent"].ToString();
                        txtelectricity.Text = mdr["Electricity_Bill"].ToString();
                        txtwater.Text = mdr["Water_Bill"].ToString();
                        txtutility.Text = mdr["Utility"].ToString();
                        txtpenalty.Text = mdr["Penalty"].ToString();
                        txtmeal.Text = mdr["Meal_Bill"].ToString();
                        txttotalbill.Text = mdr["Total_Bill"].ToString();


                    }
                    else
                    {
                        txtbalance.Text = "";
                        txtrent.Text = "";
                        txtelectricity.Text = "";
                        txtwater.Text = "";
                        txtutility.Text = "";
                        txtpenalty.Text = "";
                        txtmeal.Text = "";
                        txttotalbill.Text = "";


                        MessageBox.Show("NO Data Found!!!", "Message");
                    }
                }
                catch (Exception c)
                {
                    MessageBox.Show(c.Message);
                }

            }

            conn.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void txtmeal_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
