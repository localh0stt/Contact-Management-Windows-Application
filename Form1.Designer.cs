namespace Project1_c_sharp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgv = new System.Windows.Forms.DataGridView();
            this.btnnew = new System.Windows.Forms.Button();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.lblsearch = new System.Windows.Forms.Label();
            this.btndel = new System.Windows.Forms.Button();
            this.gb = new System.Windows.Forms.GroupBox();
            this.txtnumber2 = new System.Windows.Forms.TextBox();
            this.txtname2 = new System.Windows.Forms.TextBox();
            this.txtid2 = new System.Windows.Forms.TextBox();
            this.btnedit = new System.Windows.Forms.Button();
            this.pbform1 = new System.Windows.Forms.PictureBox();
            this.btnexport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.gb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbform1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dgv.AllowUserToAddRows = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv.Location = new System.Drawing.Point(14, 115);
            this.dgv.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 51;
            this.dgv.RowTemplate.Height = 25;
            this.dgv.Size = new System.Drawing.Size(733, 552);
            this.dgv.TabIndex = 0;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            // 
            // btnnew
            // 
            this.btnnew.Location = new System.Drawing.Point(14, 16);
            this.btnnew.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnnew.Name = "btnnew";
            this.btnnew.Size = new System.Drawing.Size(129, 31);
            this.btnnew.TabIndex = 1;
            this.btnnew.Text = "New Contact";
            this.btnnew.UseVisualStyleBackColor = true;
            this.btnnew.Click += new System.EventHandler(this.btnnew_Click);
            // 
            // txtsearch
            // 
            this.txtsearch.Location = new System.Drawing.Point(14, 76);
            this.txtsearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(352, 27);
            this.txtsearch.TabIndex = 2;
            this.txtsearch.TextChanged += new System.EventHandler(this.txtsearch_TextChanged);
            // 
            // lblsearch
            // 
            this.lblsearch.AutoSize = true;
            this.lblsearch.Location = new System.Drawing.Point(14, 52);
            this.lblsearch.Name = "lblsearch";
            this.lblsearch.Size = new System.Drawing.Size(53, 20);
            this.lblsearch.TabIndex = 3;
            this.lblsearch.Text = "Search";
            // 
            // btndel
            // 
            this.btndel.Enabled = false;
            this.btndel.Location = new System.Drawing.Point(515, 392);
            this.btndel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btndel.Name = "btndel";
            this.btndel.Size = new System.Drawing.Size(129, 31);
            this.btndel.TabIndex = 3;
            this.btndel.Text = "Delete";
            this.btndel.UseVisualStyleBackColor = true;
            this.btndel.Click += new System.EventHandler(this.btndel_Click);
            // 
            // gb
            // 
            this.gb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb.Controls.Add(this.txtnumber2);
            this.gb.Controls.Add(this.txtname2);
            this.gb.Controls.Add(this.txtid2);
            this.gb.Controls.Add(this.btnedit);
            this.gb.Controls.Add(this.pbform1);
            this.gb.Controls.Add(this.btndel);
            this.gb.Location = new System.Drawing.Point(753, 115);
            this.gb.Name = "gb";
            this.gb.Size = new System.Drawing.Size(650, 552);
            this.gb.TabIndex = 3;
            this.gb.TabStop = false;
            this.gb.Text = "Details";
            // 
            // txtnumber2
            // 
            this.txtnumber2.Enabled = false;
            this.txtnumber2.Location = new System.Drawing.Point(6, 514);
            this.txtnumber2.Name = "txtnumber2";
            this.txtnumber2.Size = new System.Drawing.Size(503, 27);
            this.txtnumber2.TabIndex = 8;
            // 
            // txtname2
            // 
            this.txtname2.Enabled = false;
            this.txtname2.Location = new System.Drawing.Point(6, 456);
            this.txtname2.Name = "txtname2";
            this.txtname2.Size = new System.Drawing.Size(503, 27);
            this.txtname2.TabIndex = 7;
            // 
            // txtid2
            // 
            this.txtid2.Enabled = false;
            this.txtid2.Location = new System.Drawing.Point(6, 396);
            this.txtid2.Name = "txtid2";
            this.txtid2.Size = new System.Drawing.Size(503, 27);
            this.txtid2.TabIndex = 6;
            // 
            // btnedit
            // 
            this.btnedit.Enabled = false;
            this.btnedit.Location = new System.Drawing.Point(515, 514);
            this.btnedit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(129, 31);
            this.btnedit.TabIndex = 4;
            this.btnedit.Text = "Edit";
            this.btnedit.UseVisualStyleBackColor = true;
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
            // 
            // pbform1
            // 
            this.pbform1.Location = new System.Drawing.Point(6, 26);
            this.pbform1.Name = "pbform1";
            this.pbform1.Size = new System.Drawing.Size(638, 359);
            this.pbform1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbform1.TabIndex = 0;
            this.pbform1.TabStop = false;
            // 
            // btnexport
            // 
            this.btnexport.Location = new System.Drawing.Point(381, 76);
            this.btnexport.Name = "btnexport";
            this.btnexport.Size = new System.Drawing.Size(118, 29);
            this.btnexport.TabIndex = 5;
            this.btnexport.Text = "Export to Excel ";
            this.btnexport.UseVisualStyleBackColor = true;
            this.btnexport.Click += new System.EventHandler(this.btnexport_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1415, 683);
            this.Controls.Add(this.btnexport);
            this.Controls.Add(this.gb);
            this.Controls.Add(this.lblsearch);
            this.Controls.Add(this.txtsearch);
            this.Controls.Add(this.btnnew);
            this.Controls.Add(this.dgv);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Contacts Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.gb.ResumeLayout(false);
            this.gb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbform1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button btnnew;
        private TextBox txtsearch;
        private Label lblsearch;
        public DataGridView dgv;
        private Button btndel;
        private GroupBox gb;
        private TextBox txtnumber2;
        private TextBox txtname2;
        private TextBox txtid2;
        private Button btnedit;
        private PictureBox pbform1;
        private Button btnexport;
    }
}