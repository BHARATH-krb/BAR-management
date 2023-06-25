using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PlayerUI
{
    public partial class register : Form
    {
        dbaccess db = new dbaccess();
        public SqlCommand cmd = new SqlCommand();
        public int i;
        public string s;
        public string pat = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
        public register()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void regclear()
        {
            foreach (Control c in panel1.Controls)
            {
                if (c is System.Windows.Forms.TextBox)
                    c.Text = "";                
            }            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text.Length == 10 && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" )
            {
                cmd.CommandText = ("Select * From [Login] Where username ='" + textBox2.Text.Trim() + "'  ");
                if (db.checkexist(cmd) == false)
                {
                    cmd.CommandText = ("Select * From [Login] Where email ='" + textBox4.Text.Trim() + "'  ");
                    if (db.checkexist(cmd) == false)
                    {
                        if (textBox5.Text != "" && textBox6.Text != "")
                        {
                            /*SqlCommand cmd = new SqlCommand("Insert into [Login] values( @a,@b,@c,@d,@e)", db.con);
                            cmd.Parameters.AddWithValue("@a", textBox3.Text);
                            cmd.Parameters.AddWithValue("@b", textBox7.Text);
                            cmd.Parameters.AddWithValue("@c", textBox4.Text);
                            cmd.Parameters.AddWithValue("@d", textBox5.Text);
                            cmd.Parameters.AddWithValue("@e", textBox8.Text);
                            i = db.InsertData(cmd);
                            if (i == 1)
                                MessageBox.Show("saved"); regclear();*/
                        }
                        else
                        {
                            MessageBox.Show("ENTER same password");
                        }                           
                    }
                    else
                    {
                        MessageBox.Show("ENTER unique email");
                    }                                       
                }
                else
                {
                    MessageBox.Show("ENTER unique Username");
                }
            }
            else
            {
                MessageBox.Show("ENTER ALL DETAILS");
            }


            register win3 = new register();
            win3.Show();
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LOGIN win2 = new LOGIN();
            win2.Show();
            this.Visible = false;
        }

        private void register_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

       
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }
    }
}
