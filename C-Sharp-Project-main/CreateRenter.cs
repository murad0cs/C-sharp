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
    public partial class Sign_Up : Form
    {
        public Sign_Up()
        {
            InitializeComponent();
        }

        SqlConnection conn20 = new SqlConnection(@"Server=.\SQLEXPRESS;Database=House;Integrated Security=true");
        string imagelocation = "";
        SqlCommand cmd;

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {

            if (txtId.Text == "")
            {
                MessageBox.Show("Please Fill up the ID field !!!", "Message");

            }
            if (txtName.Text == "")
            {
                MessageBox.Show("Please Fill up the Name field !!!", "Message");

            }

            if (txtpassword.Text == "")
            {
                MessageBox.Show("Please Fill up the Password field !!!", "Message");

            }

            if (txtAddress.Text == "")
            {
                MessageBox.Show("Please Fill up the Address field !!!", "Message");

            }

            if (txtPhone.Text == "")
            {
                MessageBox.Show("Please Fill up the Phone field !!!", "Message");

            }

            if (txtNID.Text == "")
            {
                MessageBox.Show("Please Fill up the NID field !!!", "Message");

            }

            if (txtEmail.Text == "")
            {
                MessageBox.Show("Please Fill up the Email field !!!", "Message");

            }

            if (comboUsertype.Text == "")
            {
                MessageBox.Show("Please Fill up the User Type field !!!", "Message");

            }

            else
            {
                SqlConnection conn = new SqlConnection(@"Server=.\SQLEXPRESS;Database=House;Integrated Security=true");
                conn.Open();
                try
                {
                    byte[] image = null;
                    FileStream fstram = new FileStream(imagelocation, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fstram);
                    image = br.ReadBytes((int)fstram.Length);


                    SqlCommand cmd1 = new SqlCommand("INSERT INTO Login (id,Password,UserType) VALUES('" + txtId.Text + "','" + txtpassword.Text + "','" + comboUsertype.Text + "')", conn);
                    cmd1.ExecuteNonQuery();


                    // conn20.Open();
                    string query = "";
                    query = "INSERT INTO Renter (id,Name,Password,PerAddress,Phone,NID,Email,UserType,Picture) VALUES('" + txtId.Text + "','" + txtName.Text + "','" + txtpassword.Text + "','" + txtAddress.Text + "','" + txtPhone.Text + "','" + txtNID.Text + "','" + txtEmail.Text + "','" + comboUsertype.Text + "',@image)";



                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.Add(new SqlParameter("@image", image));
                    // SqlCommand cmd11 = new SqlCommand(query, conn);
                    int n = cmd.ExecuteNonQuery();
                    // conn20.Close();
                    // cmd11.ExecuteNonQuery();



                    SqlCommand cmd2 = new SqlCommand("INSERT INTO Account (id) VALUES('" + txtId.Text + "')", conn);
                    cmd2.ExecuteNonQuery();



                    SqlCommand cmd3 = new SqlCommand("INSERT INTO Meal (id) VALUES('" + txtId.Text + "')", conn);
                    cmd3.ExecuteNonQuery();



                    SqlCommand cmd4 = new SqlCommand("INSERT INTO ComplainBox (id) VALUES('" + txtId.Text + "')", conn);
                    cmd4.ExecuteNonQuery();




                    MessageBox.Show("Successfully Renter added!!!", "Message");

                }
                catch (Exception c)
                {
                    MessageBox.Show(c.Message);

                }
                conn.Close();

            }






        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin a = new Admin();
            a.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            txtAddress.Text = "";
            txtEmail.Text = "";
            txtId.Text = "";
            txtName.Text = "";
            txtNID.Text = "";
            txtpassword.Text = "";
            txtPhone.Text = "";
            comboUsertype.Text = "";
            textBox1.Text = "";
            pictureBox1.Image = null;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

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
    }
}
