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
    public partial class cat : Form
    {
        dbaccess db = new dbaccess();
        public SqlCommand cmd = new SqlCommand();
        public int i;
        public string s;
        public cat()
        {
            InitializeComponent();
        }

        public void catclear()
        {
            foreach (Control c in panel1.Controls)
            {
                if (c is System.Windows.Forms.TextBox)
                    c.Text = "";
            }
        }
        public void catdis()
        {
            s = "select * from cat";
            dataGridView1.DataSource = db.FetchData(s);
        }
        private void cat_Load(object sender, EventArgs e)
        {

        }

        private void button_NEW_Click(object sender, EventArgs e)
        {
            catclear();
        }

        private void button_list_Click(object sender, EventArgs e)
        {
            catdis();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int cr = dataGridView1.CurrentRow.Index;
                if (dataGridView1.CurrentRow.Cells["cat_id"].Value != DBNull.Value)
                {
                    textBox_cat_ID.Text = Convert.ToString(dataGridView1[0, cr].Value);
                    textBox_cat_name.Text = Convert.ToString(dataGridView1[1, cr].Value);
                    textBox_details.Text = Convert.ToString(dataGridView1[2, cr].Value);                 
                }
            }
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            if (textBox_cat_ID.Text != "" && textBox_cat_name.Text != "" && textBox_details.Text != "")
            {
                cmd.CommandText = ("Select * From cat Where cat_id ='" + textBox_cat_ID.Text.Trim() + "'  ");
                if (db.checkexist(cmd) == false)
                {
                    SqlCommand cmd = new SqlCommand("Insert into cat values(@a,@b,@c)", db.con);
                    cmd.Parameters.AddWithValue("@a", textBox_cat_ID.Text);
                    cmd.Parameters.AddWithValue("@b", textBox_cat_name.Text);
                    cmd.Parameters.AddWithValue("@c", textBox_details.Text);                    
                    int i = db.InsertData(cmd);
                    if (i == 1)
                        MessageBox.Show("saved");
                    catclear();
                }
                else
                {
                    MessageBox.Show("ENTER unique category ID");
                }
            }
            else
            {
                MessageBox.Show("ENTER all details");
            }
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            cmd.CommandText = ("Select * From cat Where cat_id ='" + textBox_cat_ID.Text.Trim() + "'  ");
            if (db.checkexist(cmd) == true)
            {
                cmd.Parameters.Clear();
                cmd.CommandText = ("update  [cat] set cat_name = @x, details = @b Where cat_id ='" +textBox_cat_ID.Text.Trim()+"'");
                cmd.Parameters.AddWithValue("@x", textBox_cat_name.Text);
                cmd.Parameters.AddWithValue("@b", textBox_details.Text);
                db.ExecuteQuery(cmd); catclear(); MessageBox.Show("ROW UPDATED");
            }
            else
            {
                MessageBox.Show("ENTER Known Category");
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            cmd.CommandText = ("Select * From cat Where cat_id ='" + textBox_cat_ID.Text.Trim() + "'  ");
            if (db.checkexist(cmd) == true)
            {
                cmd.CommandText = ("delete from  cat  Where cat_id ='" + textBox_cat_ID.Text.Trim() + "'  ");
                db.ExecuteQuery(cmd); catclear(); MessageBox.Show("ROW Deleted");
            }
            else
            {
                MessageBox.Show("ENTER Known Category");
            }
        }
    } 
}
