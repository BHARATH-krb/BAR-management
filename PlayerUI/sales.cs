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
    public partial class sales : Form
    {
        dbaccess db = new dbaccess();
        public SqlCommand cmd = new SqlCommand();
        public int i,a;
        public string s;
        private int numberOfItemsPerPage = 0;
        private int numberOfItemsPrintedSoFar = 0;
        public sales()
        {
            InitializeComponent();catload();custload();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void stocklow()
        {
            for (int l = 0; l < dataGridView1.Rows.Count-1; l++)
            {
                string a = dataGridView1.Rows[l].Cells[1].FormattedValue.ToString();
                int b = Convert.ToInt32( dataGridView1.Rows[l].Cells[2].FormattedValue.ToString());
                cmd.CommandText = ("Select item_name From item Where item_name ='" + a+ "' and stock < '"+b+"'");
                if (db.checkexist(cmd) == false)
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = ("update  [item] set stock = stock - '"+b+"', Where item_name ='" + a + "'"); db.ExecuteQuery(cmd);
                }

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
            /*PrintDialog PrintDialog1 = new PrintDialog
            {
                AllowSomePages = true,
                ShowHelp = true,
                Document = printDocument1
            };
            DialogResult result = PrintDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                printDocument1.Print();
            }*/
        }

        public void allclear()
        {
                comboBox2.SelectedIndex = -1;
                comboBox1.SelectedIndex = -1;
            textBox3.Clear();
            itemclear();
        }
        public void itemclear()
        {
            
            
                textBox1.Clear();
                textBox2.Clear();
                
                comboBox3.SelectedIndex = -1;
                   
        }
        public void recdis()
        {
            s = "select * from receipt";
            dataGridView1.DataSource = db.FetchData(s);
        }
        public void priceload()
        {
            s = "select item_price from item where item_name='"+ comboBox3.SelectedValue+"'";
            SqlCommand cmd = new SqlCommand(s, db.con);
            db.con.Open();
            textBox1.Text = Convert.ToString(cmd.ExecuteScalar()); db.con.Close();
        }
        public void totload()
        {
            s = "select sum(price) from receipt ";
            SqlCommand cmd = new SqlCommand(s, db.con);
            db.con.Open();
            label_total_price.Text = Convert.ToString(cmd.ExecuteScalar()); db.con.Close();
        }
        public void quantload()
        {
            s = "select sum(quantity) from receipt ";
            SqlCommand cmd = new SqlCommand(s, db.con);
            db.con.Open();
            a = Convert.ToInt32(cmd.ExecuteScalar()); db.con.Close();
        }
        public void custload()
        {
            db.dd(comboBox2, "select cust_name from [cust]", "cust_name");
        }
        public void catload()
        {
            db.dd(comboBox1, "select cat_name from [cat]", "cat_name");
        }

        private void button_list_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedValue != null && textBox1.Text != "" && textBox2.Text != "")
            {
                cmd.CommandText = ("Select item_name From item Where item_name ='" + comboBox3.SelectedValue + "' and stock < '" + textBox2.Text + "'");
                if (db.checkexist(cmd) == false)
                {
                    cmd.CommandText = ("Select * From receipt Where items ='" + comboBox3.SelectedValue + "'  ");
                    if (db.checkexist(cmd) == false)
                    {
                        SqlCommand cmd = new SqlCommand("Insert into receipt values(@a,@b,@c,@d)", db.con);
                        cmd.Parameters.AddWithValue("@a", comboBox3.SelectedValue);
                        cmd.Parameters.AddWithValue("@b", textBox2.Text);
                        cmd.Parameters.AddWithValue("@c", textBox1.Text);
                        cmd.Parameters.AddWithValue("@d", Convert.ToDouble(textBox2.Text) * Convert.ToDouble(textBox1.Text));
                        int i = db.InsertData(cmd);
                        if (i == 1)
                            MessageBox.Show("saved");

                    }
                    else
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandText = ("update  [receipt] set quantity = @x, price = @b  Where items ='" + comboBox3.SelectedValue + "'");
                        cmd.Parameters.AddWithValue("@x", textBox2.Text);
                        cmd.Parameters.AddWithValue("@b", Convert.ToDouble(textBox2.Text) * Convert.ToDouble(textBox1.Text));
                        db.ExecuteQuery(cmd); MessageBox.Show("ROW UPDATED");
                    }
                    cmd.Parameters.Clear();
                    cmd.CommandText = ("update  [Bill] set [" + comboBox3.SelectedValue + "] = @x  Where Id ='" + textBox3.Text + "'");
                    cmd.Parameters.AddWithValue("@x", textBox2.Text);
                    db.ExecuteQuery(cmd); itemclear(); MessageBox.Show("ROW UPDATED");
                    totload();
                }
                else
                {
                    MessageBox.Show("Not enough Stock");

                }

            }
            else
            {
                MessageBox.Show("ENTER all details");
            }
            recdis();

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            priceload();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            db.dd(comboBox3, "select item_name from [item] where category='"+comboBox1.SelectedValue+"'", "item_name");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd.CommandText = ("Select * From receipt Where items ='" + comboBox3.SelectedValue + "'  ");
            if (db.checkexist(cmd) == true)
            {
                cmd.CommandText = ("delete from  receipt  Where items ='" + comboBox3.SelectedValue + "'  ");
                db.ExecuteQuery(cmd); MessageBox.Show("ROW Deleted");
                cmd.Parameters.Clear();
                cmd.CommandText = ("update  [Bill] set [" + comboBox3.SelectedValue + "] = @x  Where Id ='" + textBox3.Text + "'");
                cmd.Parameters.AddWithValue("@x", 0);
                db.ExecuteQuery(cmd); itemclear(); MessageBox.Show("ROW Deleted");
                totload();

            }
            else
            {
                MessageBox.Show("ENTER Known item");
            }
            recdis();

        }

        private void button_save_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedValue != null && textBox3.Text != "" )       
            {
                cmd.CommandText = ("Select * From Bill Where Id ='" + textBox3.Text+ "'  ");
                if (db.checkexist(cmd) == false)
                {
                    SqlCommand cmd = new SqlCommand("Insert into sales values(@a,@b,@c,@d)", db.con);
                    cmd.Parameters.AddWithValue("@a", DateTime.Now);
                    cmd.Parameters.AddWithValue("@b", comboBox2.SelectedValue);
                    cmd.Parameters.AddWithValue("@c", textBox3.Text);
                    cmd.Parameters.AddWithValue("@d", 0);
                    int i = db.InsertData(cmd);
                    if (i == 1)
                        MessageBox.Show("saved");
                    SqlCommand cmd2 = new SqlCommand("Insert into Bill(Id,[to]) values(@a,@b)", db.con);
                    cmd2.Parameters.AddWithValue("@a", textBox3.Text);
                    cmd2.Parameters.AddWithValue("@b", "Customer");
                    int j = db.InsertData(cmd2);
                    if (j == 1)
                        MessageBox.Show("saved");
                }
                else
                {
                    MessageBox.Show("ENTER unique bill no");
                }

            }
            else
            {
                MessageBox.Show("ENTER all details");
            }
            recdis();
        }

        private void button_NEW_Click(object sender, EventArgs e)
        {
            cmd.CommandText = ("delete from  receipt ");
            db.ExecuteQuery(cmd); allclear(); MessageBox.Show("table generated");recdis();

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string l1 = "--------------------------------------------------------------------------------";
            string curdhead = "RECEIPT";
            e.Graphics.DrawString(curdhead, new System.Drawing.Font("Book Antiqua", 9, FontStyle.Bold), Brushes.Black, 120, 20);
            e.Graphics.DrawString(l1, new System.Drawing.Font("Consolas", 9, FontStyle.Bold), Brushes.Black, 0, 50);
            e.Graphics.DrawString("Name :"+comboBox2.SelectedValue, new System.Drawing.Font("Consolas", 9, FontStyle.Bold), Brushes.Black, 70, 70);
            e.Graphics.DrawString("Bill_No:"+textBox3.Text, new System.Drawing.Font("Consolas", 9, FontStyle.Bold), Brushes.Black, 150, 70);


            e.Graphics.DrawString(l1, new System.Drawing.Font("Consolas", 9, FontStyle.Bold), Brushes.Black, 0, 100);
            e.Graphics.DrawString("ID ", new System.Drawing.Font("Consolas", 9, FontStyle.Bold), Brushes.Black, 80, 140);                   
            e.Graphics.DrawString("ITEMS", new System.Drawing.Font("Consolas", 9, FontStyle.Bold), Brushes.Black, 160, 140);            
            e.Graphics.DrawString("QUANT", new System.Drawing.Font("Consolas", 9, FontStyle.Bold), Brushes.Black, 240, 140);
            e.Graphics.DrawString("RATE", new System.Drawing.Font("Consolas", 9, FontStyle.Bold), Brushes.Black, 320, 140);
            e.Graphics.DrawString("PRICE", new System.Drawing.Font("Consolas", 9, FontStyle.Bold), Brushes.Black, 400, 140);            
            e.Graphics.DrawString(l1, new System.Drawing.Font("Consolas", 9, FontStyle.Bold), Brushes.Black, 0, 160);

            int height = 165;
            for (int l = numberOfItemsPrintedSoFar; l < dataGridView1.Rows.Count; l++)
            {
                numberOfItemsPerPage = numberOfItemsPerPage + 1;
                if (numberOfItemsPerPage <= 50)
                {
                    numberOfItemsPrintedSoFar++;

                    if (numberOfItemsPrintedSoFar <= dataGridView1.Rows.Count)
                    {
                        height += dataGridView1.Rows[0].Height;
                        e.Graphics.DrawString(""+(l+1), dataGridView1.Font = new Font("Consolas", 8), Brushes.Black, new RectangleF(80, height, dataGridView1.Columns[0].Width, dataGridView1.Rows[0].Height));
                        e.Graphics.DrawString(dataGridView1.Rows[l].Cells[1].FormattedValue.ToString(), dataGridView1.Font = new Font("Consolas", 8), Brushes.Black, new RectangleF(160, height, dataGridView1.Columns[0].Width, dataGridView1.Rows[0].Height));
                        e.Graphics.DrawString(dataGridView1.Rows[l].Cells[2].FormattedValue.ToString(), dataGridView1.Font = new Font("Consolas", 8), Brushes.Black, new RectangleF(240, height, dataGridView1.Columns[0].Width, dataGridView1.Rows[0].Height));
                        e.Graphics.DrawString(dataGridView1.Rows[l].Cells[3].FormattedValue.ToString(), dataGridView1.Font = new Font("Consolas", 8), Brushes.Black, new RectangleF(320, height, dataGridView1.Columns[0].Width, dataGridView1.Rows[0].Height));
                        e.Graphics.DrawString(dataGridView1.Rows[l].Cells[4].FormattedValue.ToString(), dataGridView1.Font = new Font("Consolas", 8), Brushes.Black, new RectangleF(400, height, dataGridView1.Columns[0].Width, dataGridView1.Rows[0].Height));
                    }
                    else
                    {
                        e.HasMorePages = false;
                    }
                }
                else
                {
                    numberOfItemsPerPage = 0;
                    e.HasMorePages = true;
                    return;
                }
            }
            e.Graphics.DrawString("Total : " + label_total_price.Text, new System.Drawing.Font("Consolas", 9, FontStyle.Bold), Brushes.Black, 150, height+20);


            numberOfItemsPerPage = 0;
            numberOfItemsPrintedSoFar = 0;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            totload();
            cmd.CommandText = ("Select * From Bill Where Id ='" + textBox3.Text + "'  ");
            if (db.checkexist(cmd) == true)
            {
                cmd.Parameters.Clear();
                cmd.CommandText = ("update  [sales] set tot_amt = @x Where bill_no ='" + textBox3.Text.Trim() + "'");
                cmd.Parameters.AddWithValue("@x", label_total_price.Text);
                db.ExecuteQuery(cmd); MessageBox.Show("ROW UPDATED");
                cmd.Parameters.Clear();
                totload();quantload();
                cmd.CommandText = ("update  [Bill] set tot_amt = @x ,tot_quant='"+a+"' Where Id ='" + textBox3.Text + "'");
                cmd.Parameters.AddWithValue("@x", label_total_price.Text);
                db.ExecuteQuery(cmd); itemclear(); MessageBox.Show("ROW updated");
            }
            else
            {
                MessageBox.Show("ENTER Known branch");
            }
            recdis();

        }
    }
}
