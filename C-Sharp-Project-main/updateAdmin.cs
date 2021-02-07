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
    public partial class updateAdmin : Form
    {
        public updateAdmin()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Server=.\SQLEXPRESS;Database=House;Integrated Security=true");
            conn.Open();

            if (txtId.Text == "")
            {
                MessageBox.Show("Please Fill up the Search Id field!!", "Message");
            }
            else
            {

                try
                {
                    string query = "";

                    query = "select * from Admin where id=" + int.Parse(txtId.Text);

                    SqlCommand cmd1 = new SqlCommand(query, conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd1);



                    SqlDataReader mdr = cmd1.ExecuteReader();
                    if (mdr.Read())
                    {
                        txtName.Text = mdr["Name"].ToString();
                        txtpassword.Text = mdr["Password"].ToString();
                        txtAddress.Text = mdr["Address"].ToString();
                        txtNID.Text = mdr["NID"].ToString();
                        txtPhone.Text = mdr["Phone"].ToString();
                        txtEmail.Text = mdr["Email"].ToString();
                        comboUsertype.Text = mdr["UserType"].ToString();



                    }
                    else
                    {

                        txtName.Text = "";
                        txtpassword.Text = "";
                        txtAddress.Text = "";
                        txtNID.Text = "";
                        txtPhone.Text = "";
                        txtEmail.Text = "";
                        comboUsertype.Text = "";
                        MessageBox.Show("NO Data Found!!!", "Message");


                    }
                                       
                    conn.Close();

                }
                catch (Exception c)
                {
                    MessageBox.Show(c.Message);
                }

            }
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Server=.\SQLEXPRESS;Database=House;Integrated Security=true");
            conn.Open();
            if (txtId.Text == "")
            {
                MessageBox.Show("Please Fill up the Search Id field!!", "Message");
            }



            else
            {
                try
                {
                                     
                    string query = "";

                    query = "UPDATE Admin SET Name = '" + txtName.Text + "',Password='" + txtpassword.Text + "',Address='" + txtAddress.Text + "',Phone='" + txtPhone.Text + "',NID='" + txtNID.Text + "',Email='" + txtEmail.Text + "',UserType='" + comboUsertype.Text + "'  WHERE id='" + txtId.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, conn);
                                    
                    cmd.ExecuteNonQuery();


                    string query1 = "";

                    query1 = "UPDATE Login SET Password = '" + txtpassword.Text + "' WHERE id='" + txtId.Text + "';";


                    SqlCommand cmd5 = new SqlCommand(query1, conn);
                    cmd5.ExecuteNonQuery();

                    MessageBox.Show("Successfully Updated Admin Account!!!", "Message");



                    conn.Close();
                   
                }
                catch (Exception c)
                {
                    MessageBox.Show(c.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin a = new Admin();
            a.Show();
        }
    }
}
