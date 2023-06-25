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
    public partial class newbranch : Form
    {
        dbaccess db = new dbaccess();
        public SqlCommand cmd = new SqlCommand();
        public int i;
        public string s;
        public newbranch()
        {
            InitializeComponent();
        }
        public void branchclear()
        {
            foreach (Control c in panel1.Controls)
            {
                if (c is System.Windows.Forms.TextBox)
                    c.Text = "";
            }
             branchdis();
        }
        public void branchdis()
        {
            s = "select * from branch";
            dataGridView1.DataSource = db.FetchData(s);
        }
        private void button_NEW_Click(object sender, EventArgs e)
        {
            branchclear();
        }

        private void button_list_Click(object sender, EventArgs e)
        {
            branchdis();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int cr = dataGridView1.CurrentRow.Index;
                if (dataGridView1.CurrentRow.Cells["branch_id"].Value != DBNull.Value)
                {
                    textBox_Branch_ID.Text = Convert.ToString(dataGridView1[0, cr].Value);
                    txtbox_branch_name.Text = Convert.ToString(dataGridView1[1, cr].Value);
                    textBox_address.Text = Convert.ToString(dataGridView1[4, cr].Value);
                }
            }
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            if (textBox_Branch_ID.Text != "" && txtbox_branch_name.Text != "" && textBox_address.Text != "")
            {
                cmd.CommandText = ("Select * From branch Where branch_id ='" + textBox_Branch_ID.Text.Trim() + "'  ");
                if (db.checkexist(cmd) == false)
                {
                    SqlCommand cmd = new SqlCommand("Insert into branch values(@a,@b,@e)", db.con);
                    cmd.Parameters.AddWithValue("@a", textBox_Branch_ID.Text);
                    cmd.Parameters.AddWithValue("@b", txtbox_branch_name.Text);
                    cmd.Parameters.AddWithValue("@e", textBox_address.Text);

                    int i = db.InsertData(cmd);
                    if (i == 1)
                        MessageBox.Show("saved");
                    branchclear();
                }
                else
                {
                    MessageBox.Show("ENTER unique branch ID");
                }
            }
            else
            {
                MessageBox.Show("ENTER all details");
            }
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            cmd.CommandText = ("Select * From branch Where branch_id ='" + textBox_Branch_ID.Text.Trim() + "'  ");
            if (db.checkexist(cmd) == true)
            {
                cmd.Parameters.Clear();
                cmd.CommandText = ("update  [branch] set branch_name = @x, doc_id = @b ,doc_type=@c ,phone=@d Where branch_id ='" + textBox_Branch_ID.Text.Trim() + "'");
                cmd.Parameters.AddWithValue("@x", txtbox_branch_name.Text);
                cmd.Parameters.AddWithValue("@b", textBox_address.Text);
                db.ExecuteQuery(cmd); branchclear(); MessageBox.Show("ROW UPDATED");
            }
            else
            {
                MessageBox.Show("ENTER Known branch");
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            cmd.CommandText = ("Select * From branch Where branch_id ='" + textBox_Branch_ID.Text.Trim() + "'  ");
            if (db.checkexist(cmd) == true)
            {
                cmd.CommandText = ("delete from  branch  Where branch_id ='" + textBox_Branch_ID.Text.Trim() + "'  ");
                db.ExecuteQuery(cmd); branchclear(); MessageBox.Show("ROW Deleted");
            }
            else
            {
                MessageBox.Show("ENTER Known branch");
            }
        }
    }
}
