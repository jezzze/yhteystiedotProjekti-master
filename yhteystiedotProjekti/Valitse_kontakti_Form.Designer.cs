
namespace yhteystiedotProjekti
{
    partial class Valitse_kontakti_Form
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.buttonSulje = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonMinimoi = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(520, 591);
            this.panel1.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.buttonSulje);
            this.panel4.Location = new System.Drawing.Point(420, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(100, 94);
            this.panel4.TabIndex = 4;
            // 
            // buttonSulje
            // 
            this.buttonSulje.BackColor = System.Drawing.Color.Transparent;
            this.buttonSulje.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSulje.Location = new System.Drawing.Point(3, 0);
            this.buttonSulje.Name = "buttonSulje";
            this.buttonSulje.Size = new System.Drawing.Size(100, 94);
            this.buttonSulje.TabIndex = 0;
            this.buttonSulje.UseVisualStyleBackColor = false;
            this.buttonSulje.Click += new System.EventHandler(this.buttonSulje_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.buttonMinimoi);
            this.panel3.Location = new System.Drawing.Point(305, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(100, 94);
            this.panel3.TabIndex = 3;
            // 
            // buttonMinimoi
            // 
            this.buttonMinimoi.BackColor = System.Drawing.Color.Transparent;
            this.buttonMinimoi.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonMinimoi.Location = new System.Drawing.Point(3, 0);
            this.buttonMinimoi.Name = "buttonMinimoi";
            this.buttonMinimoi.Size = new System.Drawing.Size(94, 94);
            this.buttonMinimoi.TabIndex = 0;
            this.buttonMinimoi.UseVisualStyleBackColor = false;
            this.buttonMinimoi.Click += new System.EventHandler(this.buttonMinimoi_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Location = new System.Drawing.Point(3, 103);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(517, 600);
            this.panel2.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(511, 482);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.AutoSizeColumnsModeChanged += new System.Windows.Forms.DataGridViewAutoSizeColumnsModeEventHandler(this.dataGridView1_AutoSizeColumnsModeChanged);
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // Valitse_kontakti_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 591);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Valitse_kontakti_Form";
            this.Text = "Valitse_kontakti_Form";
            this.Load += new System.EventHandler(this.Valitse_kontakti_Form_Load);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button buttonSulje;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonMinimoi;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.DataGridView dataGridView1;
    }
}