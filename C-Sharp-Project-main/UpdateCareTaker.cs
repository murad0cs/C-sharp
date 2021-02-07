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
    public partial class UpdateCareTaker : Form
    {
        public UpdateCareTaker()
        {
            InitializeComponent();
        }
        SqlConnection conn20 = new SqlConnection(@"Server=.\SQLEXPRESS;Database=House;Integrated Security=true");
        string imagelocation = "";
        SqlCommand cmd;
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                conn20.Open();
                string que = "SELECT Picture FROM Renter WHERE id=" + int.Parse(textBox1.Text);

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
            OpenFileDialog d = new OpenFileDialog();
            d.Filter = "JPG Files(*.jpg)|*.jpg| PNG Files(*.png)|*.png|ALL Files(*.*)|*.*";
            if (d.ShowDialog() == DialogResult.OK)
            {
                imagelocation = d.FileName.ToString();
                textBox7.Text = imagelocation;
                pictureBox1.ImageLocation = imagelocation;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            UpdateProfile up = new UpdateProfile();
            up.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            comboBox1.Text = "";
            textBox7.Text = "";
            pictureBox1.Image = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Server=.\SQLEXPRESS;Database=House;Integrated Security=true");
            conn.Open();
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please Fill up the Search Id field!!", "Message");
            }
            else
            {
               

                string query1 = "";
                query1 = "DELETE FROM Login   WHERE id='" + textBox1.Text + "';";
                SqlCommand cmd1 = new SqlCommand(query1, conn);
                cmd1.ExecuteNonQuery();

                string query2 = "";
                query2 = "DELETE FROM CareTaker   WHERE id='" + textBox1.Text + "';";
                SqlCommand cmd2 = new SqlCommand(query2, conn);
                cmd2.ExecuteNonQuery();

               

                string query5 = "";
                query5 = "DELETE FROM Meal   WHERE id='" + textBox1.Text + "';";
                SqlCommand cmd5 = new SqlCommand(query5, conn);
                cmd5.ExecuteNonQuery();



                MessageBox.Show("Successfully Deleted CareTaker Account!!!", "Message");
            }

            conn.Close();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Server=.\SQLEXPRESS;Database=House;Integrated Security=true");
            conn.Open();
            if (textBox1.Text == "")
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

                    query = "UPDATE CareTaker SET Name = '" + textBox2.Text + "',Password='" + textBox3.Text + "',PerAddress='" + textBox4.Text + "',Phone='" + textBox5.Text + "',NID='" + textBox6.Text + "',UserType='" + comboBox1.Text + "',Picture= @image  WHERE id='" + textBox1.Text + "';";


                    // SqlCommand cmd = new SqlCommand(query, conn);
                    cmd = new SqlCommand(query, conn20);
                    cmd.Parameters.Add(new SqlParameter("@image", image));
                    // SqlCommand cmd11 = new SqlCommand(query, conn);
                    int n = cmd.ExecuteNonQuery();

                    // cmd.ExecuteNonQuery();

                    string query1 = "";

                    query1 = "UPDATE Login SET Password = '" + textBox3.Text + "' WHERE id='" + textBox1.Text + "';";


                    SqlCommand cmd5 = new SqlCommand(query1, conn);
                    cmd5.ExecuteNonQuery();


                    MessageBox.Show("Successfully Updated CareTaker Account!!!", "Message");




                    conn20.Close();
                    
                }
                catch (Exception c)
                {
                    MessageBox.Show(c.Message);
                }
            }
            conn.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Server=.\SQLEXPRESS;Database=House;Integrated Security=true");
            conn.Open();

            if (textBox1.Text == "")
            {
                MessageBox.Show("Please Fill up the Search Id field!!", "Message");
            }
            else
            {

                try
                {
                    string query = "";

                    query = "select * from CareTaker where id=" + int.Parse(textBox1.Text);

                    SqlCommand cmd1 = new SqlCommand(query, conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd1);



                    SqlDataReader mdr = cmd1.ExecuteReader();
                    if (mdr.Read())
                    {
                        textBox2.Text = mdr["Name"].ToString();
                        textBox3.Text = mdr["Password"].ToString();
                        textBox4.Text = mdr["PerAddress"].ToString();
                        textBox5.Text = mdr["Phone"].ToString();
                        textBox6.Text = mdr["NID"].ToString();
                        comboBox1.Text = mdr["UserType"].ToString();



                    }
                    else
                    {

                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                        comboBox1.Text = "";
                        textBox7.Text = "";
                        MessageBox.Show("NO Data Found!!!", "Message");


                    }



                    conn20.Open();
                    string que = "SELECT Picture FROM CareTaker WHERE id=" + int.Parse(textBox1.Text);

                
                    

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
