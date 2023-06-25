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
    public partial class Item_search : Form
    {
        dbaccess db = new dbaccess();
        public SqlCommand cmd = new SqlCommand();
        public string s;
        public Item_search()
        {
            InitializeComponent();itemdis();
        }

        public void itemdis()
        {
            s = "select * from item";
            dataGridView1.DataSource = db.FetchData(s);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int cr = dataGridView1.CurrentRow.Index;
                if (dataGridView1.CurrentRow.Cells["item_id"].Value != DBNull.Value)
                {
                    label_item_id.Text = Convert.ToString(dataGridView1[0, cr].Value);
                    labe_item_name.Text = Convert.ToString(dataGridView1[1, cr].Value);
                    label5.Text = Convert.ToString(dataGridView1[3, cr].Value);
                    label_details.Text = Convert.ToString(dataGridView1[4, cr].Value);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            itemdis();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            s = ("Select * From item Where item_name like '" + textBox1.Text.Trim() + "%'  ");
            dataGridView1.DataSource = db.FetchData(s);
        }
    }
}
