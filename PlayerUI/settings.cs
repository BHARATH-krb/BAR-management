using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PlayerUI
{
    public partial class settings : Form
    {
        dbaccess db = new dbaccess();
        public SqlCommand cmd = new SqlCommand();
        public int i;
        public string s;
        public string s2=LOGIN.s1;

        public settings()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void settings_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_NEW_Click(object sender, EventArgs e)
        {
            //cng pass
            
            if (textBox1.Text != "" && textBox2.Text != "")
            {               
                    string s = "Select Count(*) From [Login] where [username] = '" + s2 + "'and [pass] = '" + textBox1.Text + "'";
                    DataTable dt = db.FetchData(s);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = ("update [Login] set pass= @a  where username = @b  ");
                    cmd.Parameters.AddWithValue("@a", s2);
                    cmd.Parameters.AddWithValue("@b", textBox2.Text);
                    cmd.Connection = db.con;
                    int i = db.InsertData(cmd);
                    if (i != 0)
                    {
                        MessageBox.Show("New password updated");
                    }
                }
                else
                {
                    MessageBox.Show("enter correct updated");
                }
            }
            else
            {
                MessageBox.Show("Enter  password");
            }

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //usr name cng
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                string s = "Select Count(*) From [Login] where [username] = '" + s2 + "'and [pass] = '" + textBox3.Text + "'";
                DataTable dt = db.FetchData(s);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    cmd.CommandText = ("Select * From [Login] Where username ='" + textBox3.Text.Trim() + "'  ");
                    if (db.checkexist(cmd) == false)
                    {
                         cmd.Parameters.Clear();
                        cmd.CommandText = ("update [Login] set [username]= @a  where [pass] = @b  ");
                         cmd.Parameters.AddWithValue("@a", textBox4.Text);
                        cmd.Parameters.AddWithValue("@b", textBox3.Text);
                        cmd.Connection = db.con;
                         int i = db.InsertData(cmd);
                        if (i != 0)
                        {
                                MessageBox.Show("New username updated");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Enter unique username");
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect password");
                }
            }
            else
            {
                    MessageBox.Show("enter details");
            }
        }
    }
}
