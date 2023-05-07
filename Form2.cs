using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
namespace Project1_c_sharp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(string ID, bool editingstatus)
        {
            InitializeComponent();
            txtid.Text = ID;
            IsEdit = editingstatus;
        }
        public Form2(bool editing, bool imgedtd, string ID, string name, string number, string imgloc, bool Insert, bool save, string title)
        {
            InitializeComponent();
            IsEdit = editing;
            imageedited = imgedtd;
            txtid.Text = ID;
            txtname.Text = name;
            txtnb.Text = number;
            pictureBox1.ImageLocation = imgloc;
            btninsert.Enabled = Insert;
            btnsave.Enabled = save;
            lbltitle.Text = title;
        }
        public string CurrentSelectedImageNewPath;
        public string CurrentSelectedImageOldPath;
        public bool IsEdit = false;
        public bool imageedited = false;
        private void Form2_Load(object sender, EventArgs e)
        {
            imageedited = false;
            txtid.Enabled = false;
            if (!File.Exists(FileController.datapath))
            {
                using (StreamWriter sw = File.CreateText(FileController.datapath));
            }
        }
        private void btninsert_Click(object sender, EventArgs e)
        {
            if (ValidateID(txtid) && ValidateName(txtname) && ValidateNumber(txtnb))
            {
                if (!File.Exists(FileController.datapath))
                {
                    using (StreamWriter sw = File.CreateText(FileController.datapath));
                }
                //appending data
                if (string.IsNullOrEmpty(pictureBox1.ImageLocation))
                {
                    MessageBox.Show("Please Upload a picture !");
                }
                else {
/*                    using (StreamWriter sr = File.AppendText(datapath))
                    {
                        sr.WriteLine(txtid.Text + "," + txtname.Text + "," + txtnb.Text + "," + Path.GetExtension(CurrentSelectedImageNewPath));
                        sr.Close();
                    }*/
                    //------------------------
                    Contacts obj = new Contacts(int.Parse(txtid.Text), txtname.Text, txtnb.Text, Path.GetExtension(CurrentSelectedImageNewPath));
                    Form1.AllContacts.Add(obj);
                    //------------------------
                    Image NewImage =Image.FromFile(openFileDialog1.FileName); 
                    if (NewImage.Width > 638 || NewImage.Height > 359)
                    {
                        Image ResizedImage = FileController.FixedSize(NewImage, 638, 359); 
                        NewImage.Dispose();
                        string tmp = (Environment.CurrentDirectory + @"\tmp"); 
                        string OldImgName = Path.GetFileName(openFileDialog1.FileName); 
                        Directory.CreateDirectory(tmp); 
                        ResizedImage.Save(tmp + @"\" + OldImgName); 
                        ResizedImage.Dispose();
                        File.Copy((tmp + @"\" + OldImgName), CurrentSelectedImageNewPath); 
                        File.Delete(tmp + @"\" + OldImgName);
                        Directory.Delete(tmp);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        NewImage.Dispose();
                        File.Copy(openFileDialog1.FileName, CurrentSelectedImageNewPath);
                        this.DialogResult = DialogResult.Cancel;
                    }
                    this.Dispose();
                }
            }
        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            if (ValidateID(txtid) && ValidateName(txtname) && ValidateNumber(txtnb))
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
                //FileController.update(datapath, FileController.uploadpath, txtid.Text, txtname.Text, txtnb.Text, openFileDialog1.FileName, CurrentSelectedImageNewPath, imageedited);
                FileController.UpdateContact(Form1.AllContacts, int.Parse(txtid.Text), txtname.Text, txtnb.Text, imageedited, CurrentSelectedImageNewPath, FileController.uploadpath, openFileDialog1.FileName);
                this.DialogResult = DialogResult.OK;
                this.Dispose();
            }
        }
        private void btnupload_Click(object sender, EventArgs e)
        {
            if (IsEdit == false)
            {
                btninsert.Enabled = true;
                btnsave.Enabled = false;
                imageedited = false;
            }
            else
            {
                imageedited = true;
            }
            uploadfunction(IsEdit);
        }
        public void uploadfunction(bool isedit)
        {
            if (!Directory.Exists(FileController.uploadpath)) Directory.CreateDirectory(FileController.uploadpath);
            initfiledialog(openFileDialog1);
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                CurrentSelectedImageNewPath = FileController.uploadpath + @"\" + txtid.Text + Path.GetExtension(openFileDialog1.FileName);
                pictureBox1.ImageLocation = openFileDialog1.FileName;
                lblstatusupload.Text = "Image uploaded successfully";
            }
        }
        public void initfiledialog(OpenFileDialog fdlg)
        {
            fdlg.Title = "Select file";
            fdlg.InitialDirectory = Environment.CurrentDirectory;
            fdlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            fdlg.DefaultExt = ".png";
        }
        public void enableupload()
        {
            if (ValidateID(txtid) && ValidateName(txtname) && ValidateNumber(txtnb))
            {
                btnupload.Enabled = true;
            }
            else btnupload.Enabled = false;
        }
        public bool ValidateNumber(TextBox Text_Box)
        {
            string sanitizedtext = Text_Box.Text.Replace(" ", ""); 
            int nbparsedValue;
            if (sanitizedtext.Length != 8)
            {      
                errorProvider1.SetError(Text_Box, "Number must be 8 digits !");
                return false;
            }
            else if(!int.TryParse(sanitizedtext, out nbparsedValue)) {
                errorProvider1.SetError(Text_Box, "Number field must only contain numbers !");
                return false;
            }
            else
            {
                errorProvider1.SetError(Text_Box, "");
                return true;
            }
        }
        public bool ValidateID(TextBox Text_Box)
        {

            string sanitizedtext = Text_Box.Text.Replace(" ", "");

            int idparsedValue;
            if (!int.TryParse(sanitizedtext, out idparsedValue))
            {
                errorProvider1.SetError(Text_Box, "ID must contain numbers only !");
                return false;
            }
            else
            {
                errorProvider1.SetError(Text_Box, "");
                return true;
            }
        }
        public bool ValidateName(TextBox Text_Box)
        {
            if (!string.IsNullOrEmpty(Text_Box.Text))
            {
                string sanitizedtext = Text_Box.Text.Trim();
                if (!Regex.IsMatch(sanitizedtext, @"^[A-Za-z\s]*$"))
                {
                    errorProvider1.SetError(Text_Box, "The \"Name\"is a letters-only field !");
                    return false;
                }
                else
                {
                    errorProvider1.SetError(Text_Box, "");
                    return true;
                }
            }
            else
            {
                errorProvider1.SetError(Text_Box, "The \"Name\" field cannot be empty!");
                return false;
            }
        }
        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void txtid_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); 
        }
        private void txtnb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void txtname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void txtname_TextChanged(object sender, EventArgs e)
        {
            enableupload(); 
        }
        private void txtnb_TextChanged(object sender, EventArgs e)
        {
            enableupload();
        }
    }
}