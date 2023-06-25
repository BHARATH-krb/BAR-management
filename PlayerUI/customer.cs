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

namespace PlayerUI
{
    public partial class category_ : Form
    {

        dbaccess db = new dbaccess();
        public SqlCommand cmd = new SqlCommand();
        public int i;
        public string s;

        public category_()
        {
            InitializeComponent();
        }

        public void lawclear()
        {
            foreach(Control c in panel1.Controls)
            {
                if (c is TextBox)
                    c.Text="";
            }            
        }

        public void lawidis()
        {
           
        }

        private void button_list_Click(object sender, EventArgs e)
        {
            lawidis();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            if(textBox_cat_ID.Text!=""&& textBox_cat_name.Text != ""&& textBox_details.Text != "")
            {
                cmd.CommandText = ("Select * From law Where law_no ='" + textBox_cat_ID.Text.Trim() + "'  ");
                if (db.checkexist(cmd) == false)
                {
                    SqlCommand cmd = new SqlCommand("Insert into law values(@a,@b,@c)", db.con);
                    cmd.Parameters.AddWithValue("@a", textBox_cat_ID.Text);
                    cmd.Parameters.AddWithValue("@b", textBox_cat_name.Text);
                    cmd.Parameters.AddWithValue("@c", textBox_details.Text);
                    int i = db.InsertData(cmd);
                    if ( i == 0)
                        MessageBox.Show("saved");
                    lawclear();
                }
                else
                {
                    MessageBox.Show("ENTER unique law no");
                }
            }
            else
            {
                MessageBox.Show("ENTER all details");
            }
        }

        private void button_NEW_Click(object sender, EventArgs e)
        {
            lawclear();
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            lawclear();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int cr = dataGridView1.CurrentRow.Index;
                if (dataGridView1.CurrentRow.Cells["law_no"].Value != DBNull.Value)
                {
                    
                    textBox_cat_ID.Text = Convert.ToString(dataGridView1[0, cr].Value);
                    textBox_cat_name.Text = Convert.ToString(dataGridView1[1, cr].Value);
                    textBox_details.Text = Convert.ToString(dataGridView1[2, cr].Value);                

                }
            }
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            cmd.CommandText = ("Select * From [law] Where law_no ='" + textBox_cat_ID.Text.Trim() + "'  ");
            if (db.checkexist(cmd) == true)
            {
                cmd.Parameters.Clear();
                cmd.CommandText = ("update  [law] set law_no = @x, type = @b , details = @d Where law_no = @x  ");
                cmd.Parameters.AddWithValue("@x", textBox_cat_ID.Text);
                cmd.Parameters.AddWithValue("@b", textBox_cat_name.Text);
                cmd.Parameters.AddWithValue("@d", textBox_details.Text);                
                db.ExecuteQuery(cmd); lawclear(); MessageBox.Show("ROW UPDATED");
            }
            else
            {
                MessageBox.Show("ENTER Known LAW NO");
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            cmd.CommandText = ("Select * From law Where law_no ='" + textBox_cat_ID.Text.Trim() + "'  ");
            if (db.checkexist(cmd) == true)
            {
                cmd.CommandText = ("delete from  law  Where law_no ='" + textBox_cat_ID.Text.Trim() + "'  ");
                db.ExecuteQuery(cmd); lawclear(); MessageBox.Show("ROW Deleted");
            }
            else
            {
                MessageBox.Show("ENTER Known LAW NO");
            }
        }

        private void category_Load(object sender, EventArgs e)
        {

        }
    }
}
