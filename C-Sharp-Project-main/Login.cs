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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(60, 0, 0, 0);
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Server=.\SQLEXPRESS;Database=House;Integrated Security=true");
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Login WHERE id= '" + txtid.Text + "' AND Password= '" + txtpassword.Text + "'AND UserType= '" + comboBox1.Text + "'", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    SqlCommand cmd1 = new SqlCommand("SELECT UserType FROM Login WHERE id= '" + txtid.Text + "' AND Password= '" + txtpassword.Text + "'", conn);
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows[0][0].ToString() == "Admin")
                    {
                        this.Hide();
                        Admin a = new Admin();
                        a.Show();
                    }

                    else if (dt1.Rows[0][0].ToString() == "Renter")
                    {
                        this.Hide();
                        RenterHome r = new RenterHome();
                        r.Show();
                    }
                    else if (dt1.Rows[0][0].ToString() == "Care Taker")
                    {
                        this.Hide();
                        CareTakerHome c = new CareTakerHome();
                        c.Show();
                    }

                }
                else
                {
                    MessageBox.Show("Invalid Id or Password!!!\n    Please try again!", "Message");
                }

                conn.Close();

            }

            catch (Exception c)
            {
                MessageBox.Show(c.Message);
            }



        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ToLet a = new ToLet();
            a.Show();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
