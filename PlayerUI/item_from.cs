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
    public partial class item_from : Form
    {
        dbaccess db = new dbaccess();
        public SqlCommand cmd = new SqlCommand();
        public int i;
        public string s,z;
        public item_from()
        {
            InitializeComponent();sendcat();
        }

        public void itemclear()
        {
            foreach (Control c in panel1.Controls)
            {
                if (c is System.Windows.Forms.TextBox)
                    c.Text = "";
            }
            sendcat();itemdis();
        }
        public void itemdis()
        {
            s = "select * from item";
            dataGridView1.DataSource = db.FetchData(s);
        }
        public void sendcat()
        {
          db.dd(comboBox1, "select cat_name from [cat]", "cat_name");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_NEW_Click(object sender, EventArgs e)
        {
            itemclear();
        }              
        private void button_list_Click(object sender, EventArgs e)
        {
            itemdis();
        }         
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int cr = dataGridView1.CurrentRow.Index;
                if (dataGridView1.CurrentRow.Cells["item_id"].Value != DBNull.Value)
                {
                    textBox_cat_ID.Text = Convert.ToString(dataGridView1[0, cr].Value);
                    textBox_cat_name.Text = Convert.ToString(dataGridView1[1, cr].Value);
                    comboBox1.SelectedValue= Convert.ToString(dataGridView1[2, cr].Value);
                    textBox1.Text= Convert.ToString(dataGridView1[3, cr].Value);
                    textBox_details.Text = Convert.ToString(dataGridView1[4, cr].Value);
                }
            }
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            if (textBox_cat_ID.Text != "" && textBox_cat_name.Text != "" && textBox_details.Text != "" && comboBox1.SelectedValue !=null && textBox1.Text != "" )
            {
                cmd.CommandText = ("Select * From item Where item_id ='" + textBox_cat_ID.Text.Trim() + "'  ");
                if (db.checkexist(cmd) == false)
                {
                    SqlCommand cmd = new SqlCommand("Insert into item values(@a,@b,@c,@d,@e,0)", db.con);
                    cmd.Parameters.AddWithValue("@a", textBox_cat_ID.Text);
                    cmd.Parameters.AddWithValue("@b", textBox_cat_name.Text);
                    cmd.Parameters.AddWithValue("@c", comboBox1.SelectedValue);
                    cmd.Parameters.AddWithValue("@d", Convert.ToDouble(textBox1.Text));
                    cmd.Parameters.AddWithValue("@e", textBox_details.Text);
                    string z = Convert.ToString(textBox_cat_name.Text);
                    int i = db.InsertData(cmd);
                    if (i == 1)
                        MessageBox.Show("saved");                   
                    cmd.Dispose();
                    SqlCommand cmd2 = new SqlCommand("Alter table Bill add ["+z+"] numeric(8,0) ",db.con);
                    int j = db.InsertData(cmd2);
                    if (j == 1)
                        MessageBox.Show("saved");                                     
                    itemclear();

                }
                else
                {
                    MessageBox.Show("ENTER unique item ID");
                }
            }
            else
            {
                MessageBox.Show("ENTER all details");
            }
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            cmd.CommandText = ("Select * From item Where item_id ='" + textBox_cat_ID.Text.Trim() + "'  ");
            if (db.checkexist(cmd) == true)
            {
                z = "Select item_name From item Where item_id ='" + textBox_cat_ID.Text.Trim() + "'  ";
                SqlCommand cmd2 = new SqlCommand("EXEC sp_rename '[Bill].[" + z + "]',[" + textBox_cat_name.Text + "]", db.con);
                int j = db.InsertData(cmd2);
                if (j == 1)
                    MessageBox.Show("saved");
                /*db.cmd.Connection.Close();*/
                cmd.Parameters.Clear();z = textBox_cat_name.Text;
                cmd.CommandText = ("update  [item] set item_name = @x, details = @b ,category=@c ,item_price=@d Where item_id ='" + textBox_cat_ID.Text.Trim() + "'");
                cmd.Parameters.AddWithValue("@x", textBox_cat_name.Text);
                cmd.Parameters.AddWithValue("@b", textBox_details.Text);
                cmd.Parameters.AddWithValue("@c", (comboBox1.SelectedValue));
                cmd.Parameters.AddWithValue("@d", Convert.ToDouble(textBox1.Text));                
                db.ExecuteQuery(cmd);  MessageBox.Show("ROW UPDATED");
                
                itemclear();
            }
            else
            {
                MessageBox.Show("ENTER Known item");
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            cmd.CommandText = ("Select * From item Where item_id ='" + textBox_cat_ID.Text.Trim() + "'  ");
            if (db.checkexist(cmd) == true)
            {
                cmd.CommandText = ("delete from  item  Where item_id ='" + textBox_cat_ID.Text.Trim() + "'  ");
                db.ExecuteQuery(cmd); itemclear(); MessageBox.Show("ROW Deleted");
            }
            else
            {
                MessageBox.Show("ENTER Known item");
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !ReferenceEquals(".",e.KeyChar) && textBox1.Text.Contains("."))
            {
                e.Handled = true;
            }
        }
    }
}
