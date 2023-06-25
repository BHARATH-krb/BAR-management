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
    
   
    public partial class LOGIN : Form
    {
        dbaccess db = new dbaccess();
        public SqlCommand cmd = new SqlCommand();
        public int i;
        public static string s1;
        public string s;
        public string pat = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
        public LOGIN()
        {
            InitializeComponent();
        }

        public void regclear()
        {
            foreach (Control c in panel_reg.Controls)
            {
                if (c is System.Windows.Forms.TextBox)
                    c.Text = "";
            }
        }

        private void button_NEW_Click(object sender, EventArgs e)
        {
            string s = "Select Count(*) From [Login] where [username] = '" + textBox1.Text + "'and [pass] = '" + textBox2.Text + "'";
            DataTable dt = db.FetchData(s);
            if (dt.Rows[0][0].ToString() == "1")
            {
                s1 = textBox1.Text;
                
                 Form1 win2 = new Form1();
                win2.Show();
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("Enter correct details");
            }
          
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            register win3 = new register();
            win3.Show();
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            panel_LOG.Visible = false;
            panel_reg.Visible = false;
            panel_RESET.Visible = true;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel_LOG.Visible = false;
            panel_reg.Visible = true;
            panel_RESET.Visible = false;
        }

        private void LOGIN_Load(object sender, EventArgs e)
        {
            panel_LOG.Visible = true;
            panel_reg.Visible = false;
            panel_RESET.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel_LOG.Visible = true;
            panel_reg.Visible = false;
            panel_RESET.Visible = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            panel_LOG.Visible = true;
            panel_reg.Visible = false;
            panel_RESET.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "" && textBox4.Text != "" && textBox7.Text.Length == 10 && textBox8.Text != "" && textBox5.Text != "" && textBox6.Text != "")
            {
                cmd.CommandText = ("Select * From [Login] Where username ='" + textBox3.Text.Trim() + "'  ");
                if (db.checkexist(cmd) == false)
                {
                    cmd.CommandText = ("Select * From [Login] Where email ='" + textBox4.Text.Trim() + "'  ");
                    if (db.checkexist(cmd) == false)
                    {
                        if (textBox5.Text != "" && textBox6.Text != "")
                        {
                            SqlCommand cmd = new SqlCommand("Insert into [Login] values( @a,@b,@c,@d,@e)", db.con);
                            cmd.Parameters.AddWithValue("@a", textBox3.Text);
                            cmd.Parameters.AddWithValue("@b", textBox7.Text);
                            cmd.Parameters.AddWithValue("@c", textBox4.Text);
                            cmd.Parameters.AddWithValue("@d", textBox5.Text);
                            cmd.Parameters.AddWithValue("@e", textBox8.Text);
                            i = db.InsertData(cmd);
                            if (i == 1)
                            {
                                MessageBox.Show("saved"); regclear();
                                panel_LOG.Visible = true;
                                panel_reg.Visible = false;
                                panel_RESET.Visible = false;
                            }                               
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
        }
        public void resetclear()
        {
            textBox9.Clear(); textBox10.Clear();
            textBox11.Clear(); textBox12.Clear();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            string s = "Select Count(*) From [Login] where [username] = '" + textBox12.Text + "'and [fav_song] = '" + textBox11.Text + "'";
            DataTable dt = db.FetchData(s);
            if (dt.Rows[0][0].ToString() == "1")
            {
                if(textBox10.Text!=""&& textBox9.Text != "")
                {
                    if (textBox10.Text ==  textBox9.Text )
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandText = ("update [Login] set pass= @a  where username = @b  ");
                        cmd.Parameters.AddWithValue("@a", textBox10.Text);
                        cmd.Parameters.AddWithValue("@b", textBox12.Text);
                        cmd.Connection = db.con;
                        int i = db.InsertData(cmd);
                        if (i != 0)
                        {
                             MessageBox.Show("New password updated");
                             panel_LOG.Visible = true;
                             panel_reg.Visible = false;
                             panel_RESET.Visible = false;
                        }                           
                        resetclear();
                    }
                    else
                    {
                        MessageBox.Show("Enter matching password");
                    }
                }
                else
                {
                    MessageBox.Show("Enter password");
                }                
            }
            else
            {
                MessageBox.Show("Enter correct details");
            }           
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox4.Text, pat) == false)
            {
                textBox4.Focus();
                errorProvider1.SetError(this.textBox4, "INVALID EMAIL");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
