namespace Project1_c_sharp
{
    partial class Form2
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
            this.components = new System.ComponentModel.Container();
            this.lblid = new System.Windows.Forms.Label();
            this.txtid = new System.Windows.Forms.TextBox();
            this.lbltitle = new System.Windows.Forms.Label();
            this.txtname = new System.Windows.Forms.TextBox();
            this.lblname = new System.Windows.Forms.Label();
            this.txtnb = new System.Windows.Forms.TextBox();
            this.lblnb = new System.Windows.Forms.Label();
            this.btninsert = new System.Windows.Forms.Button();
            this.btncancel = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnupload = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lblstatusupload = new System.Windows.Forms.Label();
            this.btnsave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblid
            // 
            this.lblid.AutoSize = true;
            this.lblid.Location = new System.Drawing.Point(29, 105);
            this.lblid.Name = "lblid";
            this.lblid.Size = new System.Drawing.Size(24, 20);
            this.lblid.TabIndex = 0;
            this.lblid.Text = "ID";
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(154, 105);
            this.txtid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(145, 27);
            this.txtid.TabIndex = 1;
            this.txtid.Text = "0";
            this.txtid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtid_KeyPress);
            // 
            // lbltitle
            // 
            this.lbltitle.AutoSize = true;
            this.lbltitle.Font = new System.Drawing.Font("Monotype Corsiva", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbltitle.ForeColor = System.Drawing.Color.Black;
            this.lbltitle.Location = new System.Drawing.Point(238, 31);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(257, 45);
            this.lbltitle.TabIndex = 2;
            this.lbltitle.Text = "NEW CONTACT";
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(155, 199);
            this.txtname.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(144, 27);
            this.txtname.TabIndex = 2;
            this.txtname.TextChanged += new System.EventHandler(this.txtname_TextChanged);
            this.txtname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtname_KeyPress);
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.Location = new System.Drawing.Point(30, 199);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(49, 20);
            this.lblname.TabIndex = 3;
            this.lblname.Text = "Name";
            // 
            // txtnb
            // 
            this.txtnb.Location = new System.Drawing.Point(154, 291);
            this.txtnb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtnb.Name = "txtnb";
            this.txtnb.Size = new System.Drawing.Size(144, 27);
            this.txtnb.TabIndex = 3;
            this.txtnb.TextChanged += new System.EventHandler(this.txtnb_TextChanged);
            this.txtnb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtnb_KeyPress);
            // 
            // lblnb
            // 
            this.lblnb.AutoSize = true;
            this.lblnb.Location = new System.Drawing.Point(30, 281);
            this.lblnb.Name = "lblnb";
            this.lblnb.Size = new System.Drawing.Size(108, 20);
            this.lblnb.TabIndex = 5;
            this.lblnb.Text = "Phone Number";
            // 
            // btninsert
            // 
            this.btninsert.Enabled = false;
            this.btninsert.Location = new System.Drawing.Point(29, 392);
            this.btninsert.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btninsert.Name = "btninsert";
            this.btninsert.Size = new System.Drawing.Size(86, 33);
            this.btninsert.TabIndex = 5;
            this.btninsert.Text = "Insert";
            this.btninsert.UseVisualStyleBackColor = true;
            this.btninsert.Click += new System.EventHandler(this.btninsert_Click);
            // 
            // btncancel
            // 
            this.btncancel.Location = new System.Drawing.Point(213, 392);
            this.btncancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(86, 33);
            this.btncancel.TabIndex = 7;
            this.btncancel.Text = "Cancel";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(337, 105);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(379, 213);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // btnupload
            // 
            this.btnupload.Enabled = false;
            this.btnupload.Location = new System.Drawing.Point(422, 396);
            this.btnupload.Name = "btnupload";
            this.btnupload.Size = new System.Drawing.Size(203, 29);
            this.btnupload.TabIndex = 4;
            this.btnupload.Text = "Upload Image";
            this.btnupload.UseVisualStyleBackColor = true;
            this.btnupload.Click += new System.EventHandler(this.btnupload_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lblstatusupload
            // 
            this.lblstatusupload.AutoSize = true;
            this.lblstatusupload.Location = new System.Drawing.Point(422, 428);
            this.lblstatusupload.Name = "lblstatusupload";
            this.lblstatusupload.Size = new System.Drawing.Size(0, 20);
            this.lblstatusupload.TabIndex = 10;
            // 
            // btnsave
            // 
            this.btnsave.Enabled = false;
            this.btnsave.Location = new System.Drawing.Point(121, 392);
            this.btnsave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(86, 33);
            this.btnsave.TabIndex = 6;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 484);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.lblstatusupload);
            this.Controls.Add(this.btnupload);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.btninsert);
            this.Controls.Add(this.txtnb);
            this.Controls.Add(this.lblnb);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.lblname);
            this.Controls.Add(this.lbltitle);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.lblid);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.Text = "Contact Editor";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblid;
        private TextBox txtid;
        private Label lbltitle;
        private TextBox txtname;
        private Label lblname;
        private TextBox txtnb;
        private Label lblnb;
        private Button btninsert;
        private Button btncancel;
        private ErrorProvider errorProvider1;
        private Button btnupload;
        private PictureBox pictureBox1;
        private OpenFileDialog openFileDialog1;
        private Label lblstatusupload;
        private Button btnsave;
    }
}