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
    public partial class searchbranch : Form
    {
        dbaccess db = new dbaccess();
        public SqlCommand cmd = new SqlCommand();
        public string s;
        public searchbranch()
        {
            InitializeComponent();branchdis();
        }
        public void branchdis()
        {
            s = "select * from branch";
            dataGridView1.DataSource = db.FetchData(s);
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int cr = dataGridView1.CurrentRow.Index;
                if (dataGridView1.CurrentRow.Cells["branch_id"].Value != DBNull.Value)
                {
                    label_brach_id.Text = Convert.ToString(dataGridView1[0, cr].Value);
                    branch_name.Text = Convert.ToString(dataGridView1[1, cr].Value);
                    brch_address.Text = Convert.ToString(dataGridView1[2, cr].Value);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            branchdis();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            s = ("Select * From branch Where branch_name like '" + textBox1.Text.Trim() + "%'  ");
            dataGridView1.DataSource = db.FetchData(s);
        }
    }
}
