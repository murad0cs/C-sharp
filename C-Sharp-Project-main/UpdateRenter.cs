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
    public partial class UpdateRenter : Form
    {
        public UpdateRenter()
        {
            InitializeComponent();
        }
        SqlConnection conn20 = new SqlConnection(@"Server=.\SQLEXPRESS;Database=House;Integrated Security=true");
        string imagelocation = "";
        SqlCommand cmd;
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            UpdateProfile up = new UpdateProfile();
            up.Show();
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
                    byte[] image = null;
                    FileStream fstram = new FileStream(imagelocation, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fstram);
                    image = br.ReadBytes((int)fstram.Length);


                    conn20.Open();
                    string query = "";

                    query = "UPDATE Renter SET Name = '" + txtName.Text + "',Password='" + txtpassword.Text + "',PerAddress='" + txtAddress.Text + "',Phone='" + txtPhone.Text + "',NID='" + txtNID.Text + "',Email='" + txtEmail.Text + "',UserType='" + comboUsertype.Text + "',Picture= @image  WHERE id='" + txtId.Text + "';";


                   // SqlCommand cmd = new SqlCommand(query, conn);
                    cmd = new SqlCommand(query, conn20);
                    cmd.Parameters.Add(new SqlParameter("@image", image));
                    // SqlCommand cmd11 = new SqlCommand(query, conn);
                    int n = cmd.ExecuteNonQuery();

                    // cmd.ExecuteNonQuery();


                    string query1 = "";

                    query1 = "UPDATE Login SET Password = '" + txtpassword.Text + "' WHERE id='" + txtId.Text + "';";


                    SqlCommand cmd5= new SqlCommand(query1, conn);
                    cmd5.ExecuteNonQuery();

                    MessageBox.Show("Successfully Updated Renter Account!!!", "Message");



                    conn.Close();
                    conn20.Close();
                }
                catch (Exception c)
                {
                    MessageBox.Show(c.Message);
                }
            }
                
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            d.Filter = "JPG Files(*.jpg)|*.jpg| PNG Files(*.png)|*.png|ALL Files(*.*)|*.*";
            if (d.ShowDialog() == DialogResult.OK)
            {
                imagelocation = d.FileName.ToString();
                textBox1.Text = imagelocation;
                pictureBox1.ImageLocation = imagelocation;



            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                conn20.Open();
                string que = "SELECT Picture FROM Renter WHERE id=" + int.Parse(txtId.Text);

                cmd = new SqlCommand(que, conn20);
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

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Server=.\SQLEXPRESS;Database=House;Integrated Security=true");


            conn.Open();
            if (txtId.Text == "")
            {
                MessageBox.Show("Please Fill up the Search Id field!!", "Message");
            }
            else
            {
                string query = "";
                query = "DELETE FROM Account   WHERE id='" + txtId.Text + "';";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();

                string query1 = "";
                query1 = "DELETE FROM Login   WHERE id='" + txtId.Text + "';";
                SqlCommand cmd1 = new SqlCommand(query1, conn);
                cmd1.ExecuteNonQuery();

                string query2 = "";
                query2 = "DELETE FROM Renter   WHERE id='" + txtId.Text + "';";
                SqlCommand cmd2 = new SqlCommand(query2, conn);
                cmd2.ExecuteNonQuery();

                string query4 = "";
                query4 = "DELETE FROM ComplainBox   WHERE id='" + txtId.Text + "';";
                SqlCommand cmd4 = new SqlCommand(query4, conn);
                cmd4.ExecuteNonQuery();

                string query5 = "";
                query5 = "DELETE FROM Meal   WHERE id='" + txtId.Text + "';";
                SqlCommand cmd5 = new SqlCommand(query5, conn);
                cmd5.ExecuteNonQuery();



                MessageBox.Show("Successfully Deleted Account!!!", "Message");
            }

            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtName.Text = "";
            txtpassword.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtNID.Text = "";
            comboUsertype.Text = "";
            textBox1.Text = "";
            pictureBox1.Image = null;
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

                    query = "select * from Renter where id=" + int.Parse(txtId.Text);

                   SqlCommand cmd1 = new SqlCommand(query, conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd1);

                 

                    SqlDataReader mdr = cmd1.ExecuteReader();
                    if (mdr.Read())
                    {
                        txtName.Text = mdr["Name"].ToString();
                        txtpassword.Text = mdr["Password"].ToString();
                        txtAddress.Text = mdr["PerAddress"].ToString();
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

                   

                    conn20.Open();
                    string que = "SELECT Picture FROM Renter WHERE id=" + int.Parse(txtId.Text);

                    cmd = new SqlCommand(que, conn20);
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

                    conn.Close();

                }
                catch (Exception c)
                {
                    MessageBox.Show(c.Message);
                }

            }
            
        }
               
        
    }
}
