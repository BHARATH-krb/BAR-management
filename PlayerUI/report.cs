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
    public partial class report : Form
    {
        dbaccess db = new dbaccess();
        public SqlCommand cmd = new SqlCommand();
        public int i, a;
        public string s;
        public report()
        {
            InitializeComponent(); custrep(); suprep();itemrep();
            billrep();
            salrep();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button_NEW_Click(object sender, EventArgs e)
        {
            pcatr.Visible = false;
            pcust.Visible = false;
            psales.Visible = true;
            psup.Visible = false;
            pitem.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pcatr.Visible = false;
            pcust.Visible = false;
            psales.Visible = false;
            psup.Visible = true;
            pitem.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pcatr.Visible = true;
            pcust.Visible = false;
            psales.Visible = false;
            psup.Visible = false;
            pitem.Visible = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            pcatr.Visible = false;
            pcust.Visible = true;
            psales.Visible = false;
            psup.Visible = false;
            pitem.Visible = false;
        }

        private void report_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            pcatr.Visible = false;
            pcust.Visible = false;
            psales.Visible = false;
            psup.Visible = false;
            pitem.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            custrep();
        }
        public void salrep()
        {
            s = "select * from sales";
            dataGridView1.DataSource = db.FetchData(s);
        }
        public void suprep()
        {
            s = "select * from supply";
            dataGridView2.DataSource = db.FetchData(s);
        }
        public void itemrep()
        {
            s = "select * from item";
            dataGridView4.DataSource = db.FetchData(s);
        }
        public void billrep()
        {
            s = "select * from Bill";
            dataGridView3.DataSource = db.FetchData(s);
        }
        public void custrep()
        {
            s = "select * from cust";
            dataGridView5.DataSource = db.FetchData(s);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            suprep();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            itemrep();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            billrep();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            salrep();
        }
    }
}
