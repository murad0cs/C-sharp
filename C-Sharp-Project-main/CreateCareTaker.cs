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
    public partial class CreateCareTaker : Form
    {
        public CreateCareTaker()
        {
            InitializeComponent();
        }

        SqlConnection conn20 = new SqlConnection(@"Server=.\SQLEXPRESS;Database=House;Integrated Security=true");
        string imagelocation = "";
        SqlCommand cmd;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
            {
                MessageBox.Show("Please Fill up the ID field !!!", "Message");

            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("Please Fill up the Name field !!!", "Message");

            }

            if (textBox3.Text == "")
            {
                MessageBox.Show("Please Fill up the Password field !!!", "Message");

            }

            if (textBox4.Text == "")
            {
                MessageBox.Show("Please Fill up the Address field !!!", "Message");

            }

            if (textBox5.Text == "")
            {
                MessageBox.Show("Please Fill up the Phone field !!!", "Message");

            }

            if (textBox6.Text == "")
            {
                MessageBox.Show("Please Fill up the NID field !!!", "Message");

            }

            if (comboBox1.Text == "")
            {
                MessageBox.Show("Please Fill up the User Type field !!!", "Message");

            }



            else
            {
                try
                {
                    byte[] image = null;
                    FileStream fstram = new FileStream(imagelocation, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fstram);
                    image = br.ReadBytes((int)fstram.Length);




                    SqlConnection conn = new SqlConnection(@"Server=.\SQLEXPRESS;Database=House;Integrated Security=true");
                    conn.Open();

                    SqlCommand cmd1 = new SqlCommand("INSERT INTO Login (id,Password,UserType) VALUES('" + textBox1.Text + "','" + textBox3.Text + "','" + comboBox1.Text + "')", conn);
                    cmd1.ExecuteNonQuery();

                    conn20.Open();
                    string query = "";
                    query = "INSERT INTO CareTaker (id,Name,Password,PerAddress,Phone,NID,UserType,Picture) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + comboBox1.Text + "',@image)";


                    cmd = new SqlCommand(query, conn20);
                    cmd.Parameters.Add(new SqlParameter("@image", image));

                    int n = cmd.ExecuteNonQuery();
                    conn20.Close();


                    SqlCommand cmd7 = new SqlCommand("INSERT INTO Meal (id) VALUES('" + textBox1.Text + "')", conn);
                    cmd7.ExecuteNonQuery();


                    MessageBox.Show("Successfully added!!!", "Message");


                    conn.Close();

                }
                catch (Exception c)
                {
                    MessageBox.Show(c.Message);
                }


            }


        }

        private void CreateCareTaker_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin a = new Admin();
            a.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
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

            }
            catch (Exception c)
            {
                MessageBox.Show(c.Message);
            }

        }
    }
}
