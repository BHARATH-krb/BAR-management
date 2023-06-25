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
    public partial class add_cust : Form
    {
        dbaccess db = new dbaccess();
        public SqlCommand cmd = new SqlCommand();
        public int i;
        public string s;     

        public add_cust()
        {
            InitializeComponent();custclear();
        }
        public void custclear()
        {
            foreach (Control c in panel1.Controls)
            {
                if (c is System.Windows.Forms.TextBox)
                    c.Text = "";
            }
            senddoc();custdis();
        }
        public void custdis()
        {
            s = "select * from cust";
            dataGridView1.DataSource = db.FetchData(s);
        }
        public void senddoc()
        {
            db.dd(comboBox1, "select type from [doc]", "type");
        }

        private void button_NEW_Click(object sender, EventArgs e)
        {
            custclear();
        }

        private void button_list_Click(object sender, EventArgs e)
        {
            custdis();
        }

        private void textBox_phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int cr = dataGridView1.CurrentRow.Index;
                if (dataGridView1.CurrentRow.Cells["cust_id"].Value != DBNull.Value)
                {
                    textBox_cat_ID.Text = Convert.ToString(dataGridView1[0, cr].Value);
                    textBox_cat_name.Text = Convert.ToString(dataGridView1[1, cr].Value);
                    comboBox1.SelectedValue = Convert.ToString(dataGridView1[2, cr].Value);
                    textBox_doc_ID.Text = Convert.ToString(dataGridView1[3, cr].Value);
                    textBox_phone.Text = Convert.ToString(dataGridView1[4, cr].Value);
                }
            }
        }
        private void button_save_Click(object sender, EventArgs e)
        {
            if (textBox_cat_ID.Text != "" && textBox_cat_name.Text != "" && textBox_doc_ID.Text != "" && comboBox1.SelectedValue != null && textBox_phone.Text != "")
            {
                cmd.CommandText = ("Select * From cust Where cust_id ='" + textBox_cat_ID.Text.Trim() + "'  ");
                if (db.checkexist(cmd) == false)
                {
                    SqlCommand cmd = new SqlCommand("Insert into cust values(@a,@b,@c,@d,@e)", db.con);
                    cmd.Parameters.AddWithValue("@a", textBox_cat_ID.Text);
                    cmd.Parameters.AddWithValue("@b", textBox_cat_name.Text);
                    cmd.Parameters.AddWithValue("@c", comboBox1.SelectedValue);
                    cmd.Parameters.AddWithValue("@d", textBox_doc_ID.Text);
                    cmd.Parameters.AddWithValue("@e", textBox_phone.Text);

                    int i = db.InsertData(cmd);
                    if (i == 1)
                        MessageBox.Show("saved");
                    custclear();
                }
                else
                {
                    MessageBox.Show("ENTER unique cust ID");
                }
            }
            else
            {
                MessageBox.Show("ENTER all details");
            }
        }
        private void button_update_Click(object sender, EventArgs e)
        {
            cmd.CommandText = ("Select * From cust Where cust_id ='" + textBox_cat_ID.Text.Trim() + "'  ");
            if (db.checkexist(cmd) == true)
            {
                cmd.Parameters.Clear();
                cmd.CommandText = ("update  [cust] set cust_name = @x, doc_id = @b ,doc_type=@c ,phone=@d Where cust_id ='" + textBox_cat_ID.Text.Trim() + "'");
                cmd.Parameters.AddWithValue("@x", textBox_cat_name.Text);
                cmd.Parameters.AddWithValue("@b", textBox_doc_ID.Text);
                cmd.Parameters.AddWithValue("@c", (comboBox1.SelectedValue));
                cmd.Parameters.AddWithValue("@d", textBox_phone.Text);
                db.ExecuteQuery(cmd); custclear(); MessageBox.Show("ROW UPDATED");
            }
            else
            {
                MessageBox.Show("ENTER Known cust");
            }
        }
        private void Delete_Click(object sender, EventArgs e)
        {
            cmd.CommandText = ("Select * From cust Where cust_id ='" + textBox_cat_ID.Text.Trim() + "'  ");
            if (db.checkexist(cmd) == true)
            {
                cmd.CommandText = ("delete from  cust  Where cust_id ='" + textBox_cat_ID.Text.Trim() + "'  ");
                db.ExecuteQuery(cmd); custclear(); MessageBox.Show("ROW Deleted");
            }
            else
            {
                MessageBox.Show("ENTER Known cust");
            }
        }

       
    }
}
