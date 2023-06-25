namespace PlayerUI
{
    partial class cat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button5 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox_details = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button_list = new System.Windows.Forms.Button();
            this.button_Clear = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.button_update = new System.Windows.Forms.Button();
            this.button_save = new System.Windows.Forms.Button();
            this.button_NEW = new System.Windows.Forms.Button();
            this.textBox_cat_name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_cat_ID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button5
            // 
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.LightGray;
            this.button5.Location = new System.Drawing.Point(10, 11);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(25, 25);
            this.button5.TabIndex = 23;
            this.button5.Text = "X";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Aquamarine;
            this.label1.Location = new System.Drawing.Point(354, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 25);
            this.label1.TabIndex = 24;
            this.label1.Text = "Category Management";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox_details);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.button_list);
            this.panel1.Controls.Add(this.button_Clear);
            this.panel1.Controls.Add(this.Delete);
            this.panel1.Controls.Add(this.button_update);
            this.panel1.Controls.Add(this.button_save);
            this.panel1.Controls.Add(this.button_NEW);
            this.panel1.Controls.Add(this.textBox_cat_name);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBox_cat_ID);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(19, 51);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(420, 444);
            this.panel1.TabIndex = 25;
            // 
            // textBox_details
            // 
            this.textBox_details.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_details.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_details.Location = new System.Drawing.Point(123, 110);
            this.textBox_details.Multiline = true;
            this.textBox_details.Name = "textBox_details";
            this.textBox_details.Size = new System.Drawing.Size(202, 62);
            this.textBox_details.TabIndex = 41;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(60, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 15);
            this.label4.TabIndex = 40;
            this.label4.Text = "DEATILS :";
            // 
            // button_list
            // 
            this.button_list.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.button_list.FlatAppearance.BorderSize = 0;
            this.button_list.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_list.ForeColor = System.Drawing.SystemColors.Control;
            this.button_list.Location = new System.Drawing.Point(349, 213);
            this.button_list.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_list.Name = "button_list";
            this.button_list.Size = new System.Drawing.Size(56, 19);
            this.button_list.TabIndex = 39;
            this.button_list.Text = "List";
            this.button_list.UseVisualStyleBackColor = false;
            this.button_list.Click += new System.EventHandler(this.button_list_Click);
            // 
            // button_Clear
            // 
            this.button_Clear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.button_Clear.FlatAppearance.BorderSize = 0;
            this.button_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Clear.ForeColor = System.Drawing.SystemColors.Control;
            this.button_Clear.Location = new System.Drawing.Point(349, 182);
            this.button_Clear.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_Clear.Name = "button_Clear";
            this.button_Clear.Size = new System.Drawing.Size(56, 19);
            this.button_Clear.TabIndex = 38;
            this.button_Clear.Text = "Clear";
            this.button_Clear.UseVisualStyleBackColor = false;
            this.button_Clear.Click += new System.EventHandler(this.button_NEW_Click);
            // 
            // Delete
            // 
            this.Delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.Delete.FlatAppearance.BorderSize = 0;
            this.Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Delete.ForeColor = System.Drawing.SystemColors.Control;
            this.Delete.Location = new System.Drawing.Point(349, 146);
            this.Delete.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(56, 19);
            this.Delete.TabIndex = 37;
            this.Delete.Text = "Delete";
            this.Delete.UseVisualStyleBackColor = false;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // button_update
            // 
            this.button_update.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.button_update.FlatAppearance.BorderSize = 0;
            this.button_update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_update.ForeColor = System.Drawing.SystemColors.Control;
            this.button_update.Location = new System.Drawing.Point(349, 112);
            this.button_update.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_update.Name = "button_update";
            this.button_update.Size = new System.Drawing.Size(56, 19);
            this.button_update.TabIndex = 36;
            this.button_update.Text = "Update";
            this.button_update.UseVisualStyleBackColor = false;
            this.button_update.Click += new System.EventHandler(this.button_update_Click);
            // 
            // button_save
            // 
            this.button_save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.button_save.FlatAppearance.BorderSize = 0;
            this.button_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_save.ForeColor = System.Drawing.SystemColors.Control;
            this.button_save.Location = new System.Drawing.Point(349, 75);
            this.button_save.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(56, 19);
            this.button_save.TabIndex = 35;
            this.button_save.Text = "Save";
            this.button_save.UseVisualStyleBackColor = false;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // button_NEW
            // 
            this.button_NEW.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.button_NEW.FlatAppearance.BorderSize = 0;
            this.button_NEW.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_NEW.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_NEW.Location = new System.Drawing.Point(349, 39);
            this.button_NEW.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_NEW.Name = "button_NEW";
            this.button_NEW.Size = new System.Drawing.Size(56, 19);
            this.button_NEW.TabIndex = 34;
            this.button_NEW.Text = "New";
            this.button_NEW.UseVisualStyleBackColor = false;
            this.button_NEW.Click += new System.EventHandler(this.button_NEW_Click);
            // 
            // textBox_cat_name
            // 
            this.textBox_cat_name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_cat_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_cat_name.Location = new System.Drawing.Point(123, 73);
            this.textBox_cat_name.Name = "textBox_cat_name";
            this.textBox_cat_name.Size = new System.Drawing.Size(202, 21);
            this.textBox_cat_name.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(29, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 15);
            this.label3.TabIndex = 20;
            this.label3.Text = "Category Name :";
            // 
            // textBox_cat_ID
            // 
            this.textBox_cat_ID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_cat_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_cat_ID.Location = new System.Drawing.Point(123, 37);
            this.textBox_cat_ID.Name = "textBox_cat_ID";
            this.textBox_cat_ID.Size = new System.Drawing.Size(202, 21);
            this.textBox_cat_ID.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(46, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 15);
            this.label2.TabIndex = 18;
            this.label2.Text = "Category ID :";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(444, 51);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(563, 444);
            this.dataGridView1.TabIndex = 26;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // cat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(896, 505);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button5);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "cat";
            this.Text = "cat";
            this.Load += new System.EventHandler(this.cat_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox_details;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_list;
        private System.Windows.Forms.Button button_Clear;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button button_update;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Button button_NEW;
        private System.Windows.Forms.TextBox textBox_cat_name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_cat_ID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}