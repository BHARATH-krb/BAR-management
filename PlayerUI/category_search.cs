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
    public partial class category_search : Form
    {
        dbaccess db = new dbaccess();
        public SqlCommand cmd = new SqlCommand();
        public string s;
        public category_search()
        {
            InitializeComponent();catdis();
        }

        public void catdis()
        {
            s = "select * from cat";
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
                if (dataGridView1.CurrentRow.Cells["cat_id"].Value != DBNull.Value)
                {
                    label_cat_id.Text = Convert.ToString(dataGridView1[0, cr].Value);
                    labe_Cat_name.Text = Convert.ToString(dataGridView1[1, cr].Value);
                    label_details.Text = Convert.ToString(dataGridView1[2, cr].Value);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            catdis();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            s = ("Select * From cat Where cat_name like '" + textBox1.Text.Trim() + "%'  ");
            dataGridView1.DataSource = db.FetchData(s);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label_cat_id_Click(object sender, EventArgs e)
        {

        }

        private void category_search_Load(object sender, EventArgs e)
        {

        }
    }
}
