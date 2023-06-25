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
    public partial class search_cust : Form
    {
        dbaccess db = new dbaccess();
        public SqlCommand cmd = new SqlCommand();
        public string s;
        public search_cust()
        {
            InitializeComponent();custdis();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void custdis()
        {
            s = "select * from cust";
            dataGridView1.DataSource = db.FetchData(s);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            custdis();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int cr = dataGridView1.CurrentRow.Index;
                if (dataGridView1.CurrentRow.Cells["cust_id"].Value != DBNull.Value)
                {
                    label_cust_id.Text = Convert.ToString(dataGridView1[0, cr].Value);
                    cutomer_name.Text = Convert.ToString(dataGridView1[1, cr].Value);
                    doc_id.Text = Convert.ToString(dataGridView1[3, cr].Value);
                    phone.Text = Convert.ToString(dataGridView1[4, cr].Value);
                }
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            s = ("Select * From cust Where cust_name like '" + textBox1.Text.Trim() + "%'  ");
            dataGridView1.DataSource = db.FetchData(s);
        }
    }
}
