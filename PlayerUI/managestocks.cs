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
    public partial class managestocks : Form
    {
        dbaccess db = new dbaccess();
        public SqlCommand cmd = new SqlCommand();
        public int i;
        public string s, z;
        public managestocks()
        {
           
            InitializeComponent(); itemclear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void itemclear()
        {
            textBox_Quantiny.Clear();
            sendcat(); itemdis();
        }
        public void itemdis()
        {
            s = "select * from item";
            dataGridView1.DataSource = db.FetchData(s);
        }
        public void sendcat()
        {
            db.dd(catdd, "select cat_name from [cat]", "cat_name");

        }


        private void textBox_Quantiny_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)&& ReferenceEquals("-", e.KeyChar) )
            {
                e.Handled = true;
            }
        }

        private void button_update_Click(object sender, EventArgs e)
            
        {
            
            cmd.CommandText = ("Select * From item Where item_name='" + comboBox1.SelectedValue + "'  ");
            if (db.checkexist(cmd) == true)
            {
                /*db.cmd.Connection.Close();*/
                cmd.Parameters.Clear(); 
                cmd.CommandText = ("update  [item] set stock = stock +@x Where item_name ='" + comboBox1.SelectedValue + "'");
                cmd.Parameters.AddWithValue("@x", textBox_Quantiny.Text);              
                db.ExecuteQuery(cmd); MessageBox.Show("ROW UPDATED");

                itemclear();
            }
            else
            {
                MessageBox.Show("ENTER Known item");
            }
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            itemclear();
        }

        private void catdd_SelectedIndexChanged(object sender, EventArgs e)
        {
            db.dd(comboBox1, "select item_name from [item] where category='" + catdd.SelectedValue + "'", "item_name");

        }

        private void button_list_Click(object sender, EventArgs e)
        {
            itemdis();
        }
    }
}
