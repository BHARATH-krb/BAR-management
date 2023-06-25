using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PlayerUI
{
    public partial class custmer_details : Form
    {
        dbaccess db = new dbaccess();
        public SqlCommand cmd = new SqlCommand();
        public int i;
        public string s;
        public string pat = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
        public custmer_details()
        {
            InitializeComponent();qualdis();citydis();
        }

        public void lawclear()
        {
            foreach (Control c in panel1.Controls)
            {
                if (c is System.Windows.Forms.TextBox)
                    c.Text = "";
                else if (c is System.Windows.Forms.ComboBox)
                    panel1.Controls.SetChildIndex(c, -1);
            }
            qualdis();citydis();
        }

        public void lawidis()
        {
           
        }

        public void qualdis()
        {
          
        }

        public void citydis()
        {
           
        }
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void button_NEW_Click(object sender, EventArgs e)
        {
            lawclear();
        }

        private void textBox_PINCODE_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar)&&!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox_PHONE_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox_GMAIL_Leave(object sender, EventArgs e)
        {
         
        }

        private void button_list_Click(object sender, EventArgs e)
        {
            lawidis();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            
        }

        private void button_update_Click(object sender, EventArgs e)
        {
        }

        private void Delete_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox_LYERid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
