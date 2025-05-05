using System.Windows.Forms;

namespace WindowsFormsApp8
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(20, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(660, 450);
            this.panel1.TabIndex = 13;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(700, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(140, 20);
            this.textBox1.TabIndex = 12;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(700, 50);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(140, 20);
            this.textBox2.TabIndex = 11;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(700, 80);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(140, 20);
            this.textBox3.TabIndex = 10;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(874, 291);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 4;
            // 
            // comboBox1
            // 
            this.comboBox1.Location = new System.Drawing.Point(700, 150);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(140, 21);
            this.comboBox1.TabIndex = 9;
            // 
            // comboBox2
            // 
            this.comboBox2.Location = new System.Drawing.Point(700, 180);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(140, 21);
            this.comboBox2.TabIndex = 8;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(700, 410);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox5.Size = new System.Drawing.Size(200, 80);
            this.textBox5.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(700, 110);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 25);
            this.button1.TabIndex = 6;
            this.button1.Text = "Thêm thành phố";
            this.button1.Click += new System.EventHandler(this.btnAddCity_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(700, 210);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 25);
            this.button2.TabIndex = 5;
            this.button2.Text = "Thêm cạnh";
            this.button2.Click += new System.EventHandler(this.btnAddEdge_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(800, 210);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 25);
            this.button3.TabIndex = 4;
            this.button3.Text = "Xóa cạnh";
            this.button3.Click += new System.EventHandler(this.btnRemoveEdge_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(700, 280);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 25);
            this.button4.TabIndex = 3;
            this.button4.Text = "Xóa thành phố";
            this.button4.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(700, 310);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(100, 25);
            this.button5.TabIndex = 2;
            this.button5.Text = "Tìm đường đi";
            this.button5.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(700, 340);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(100, 25);
            this.button6.TabIndex = 1;
            this.button6.Text = "Làm mới";
            this.button6.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(700, 370);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(100, 25);
            this.button7.TabIndex = 0;
            this.button7.Text = "Thoát";
            this.button7.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1000, 500);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
    }
}

