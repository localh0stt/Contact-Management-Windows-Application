using System.Collections.Immutable;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Wordprocessing;

namespace Project1_c_sharp
{
    public partial class Form1 : Form
    {
        public static List<Contacts> AllContacts = new List<Contacts>();
        public static void RefreshList(List<Contacts> c)
        {
            AllContacts.Clear();
            AllContacts = c;
        }
        public Form1()
        {
            InitializeComponent();
            if (!File.Exists(FileController.datapath))
            {
                FileController.CreateEmptyFile(FileController.datapath);
            }
            RefreshList(FileController.GetAllContacts(FileController.datapath));
        }
        private void GridRefresh(DataGridView grid)
        {
            grid.DataSource = null;
            ClearSelection();
            if (!File.Exists(FileController.datapath))
            {
                FileController.CreateEmptyFile(FileController.datapath);
            }
            try
            {
                var listBindingFiles = new BindingList<Contacts>(AllContacts);
                grid.DataSource = listBindingFiles;
                dgv.Columns[3].Visible = false;
            }
            catch
            {
                MessageBox.Show("Could not fetch data from source");
                this.Dispose();
            }
        }
        public int maxIDautoincrement(string path)
        {
            var lines = File.ReadAllLines(path);
            string[] fields;
            int id;
            int[] idarray = new int[lines.Length];
            for (int i = 1; i < lines.Length; i++)
            {
                fields = lines[i].Split(',');
                if (fields[0] != null)
                {
                    id = int.Parse(fields[0]);
                    idarray[i] = id;
                }
                else MessageBox.Show("Error in processing data, found null ID.");
            }
            return idarray.Max();
        }
        public int AutoIncrement()
        {
/*            int[] IDs = new int[AllContacts.Count];
            for(int i =0; i < AllContacts.Count; i++)
            {
                IDs[i] = AllContacts[i].ID;
            }
            return IDs.Max();*/
            return AllContacts[AllContacts.Count - 1].ID;
        }
        private void btnnew_Click(object sender, EventArgs e)
        {
            if (AllContacts.Count == 0)
            {
                Form2 f2 = new Form2("0", false);
                if (f2.ShowDialog() == DialogResult.OK)
                {
                    /*                    dgv.DataSource = null;
                                        FileController.fillgrid(dgv, FileController.FileController.datapath);*/
                    GridRefresh(dgv);
                    ClearSelection();
                }
            }
            else
            {
                //Form2 f2 = new Form2(((maxIDautoincrement(FileController.FileController.datapath) + 1).ToString()), false);
                Form2 f2 = new Form2((AutoIncrement() + 1).ToString(), false);

                if (f2.ShowDialog() == DialogResult.OK)
                {
                    /*                    dgv.DataSource = null;
                                        FileController.fillgrid(dgv, FileController.datapath);*/
                    GridRefresh(dgv);
                    ClearSelection();
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //FileController.fillgrid(dgv, FileController.datapath);
            GridRefresh(dgv);
        }
        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            //FileController.Find(dgv, txtsearch, FileController.datapath);
            dgv.DataSource = null;
            dgv.DataSource = FileController.FindContact(AllContacts, txtsearch.Text);
            dgv.Columns[3].Visible = false;
            dgv.CurrentCell = dgv.FirstDisplayedCell;
        }
        private void btndel_Click(object sender, EventArgs e)
        {
            pbform1.Image.Dispose();
            pbform1.Image = null;
            //FileController.delete(txtid2.Text, FileController.datapath, FileController.uploadpath, dgv.CurrentRow.Cells[3].Value.ToString(), pbform1);
            FileController.DeleteContact(AllContacts, int.Parse(txtid2.Text), FileController.uploadpath, dgv.CurrentRow.Cells[3].Value.ToString(),pbform1);
            dgv.DataSource = null;
            //FileController.fillgrid(dgv, FileController.datapath);
            GridRefresh(dgv);
            ClearSelection();
        }
        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(pbform1.Image != null){
                pbform1.Image.Dispose();
                pbform1.Image = null;
            }
            btndel.Enabled = true;
            btnedit.Enabled = true;
            txtid2.Text = dgv.CurrentRow.Cells[0].Value.ToString();
            txtname2.Text = dgv.CurrentRow.Cells[1].Value.ToString();
            txtnumber2.Text = dgv.CurrentRow.Cells[2].Value.ToString();
            try
            {
                pbform1.Image = Image.FromFile(FileController.uploadpath + @"\" + txtid2.Text + dgv.CurrentRow.Cells[3].Value.ToString());
            }
            catch
            {
                pbform1.Image = null;
            }
        }
        private void btnedit_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(true,false, txtid2.Text, txtname2.Text, txtnumber2.Text, FileController.uploadpath + @"\" + txtid2.Text + dgv.CurrentRow.Cells[3].Value.ToString(), false, true, "Edit Contact");
            ClearSelection();
            pbform1.Image.Dispose();
            pbform1.Image = null;
            if(form.ShowDialog() == DialogResult.OK)
            {
/*                pbform1.Image.Dispose();
                pbform1.Image = null;*/
                /*ClearSelection();*/
                /*dgv.DataSource = null;*/
                GridRefresh(dgv);
            }
        }
        private void ClearSelection()
        {
            txtid2.Text = "";
            txtname2.Text = "";
            txtnumber2.Text = "";
            btndel.Enabled = false;
            btnedit.Enabled = false;
            dgv.ClearSelection();
        }
        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            File.Create(FileController.datapath).Close();
            using (StreamWriter sr = File.AppendText(FileController.datapath))
            {
                foreach (var item in AllContacts)
                {
                    sr.WriteLine(string.Format("{0},{1},{2},{3}", item.ID.ToString(), item.Name, item.Number, item.ImageExtension));
                }
                sr.Close();
            }
        }

        private void btnexport_Click(object sender, EventArgs e)
        {
            DataTable dt = ToDataTable<Contacts>(AllContacts);
            XLWorkbook wb = new XLWorkbook();
            string ExportPath = FileController.GetDownloadFolderPath();
            try
            {
                wb.Worksheets.Add(dt, "WorksheetName");
                wb.SaveAs(ExportPath + @"\ContactsData.xlsx");
                dt.Dispose();
                MessageBox.Show("Excel file saved in : " + ExportPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during saving the excel file : " + "\n" + ex.ToString());
            }
            wb.Dispose();
        }
    }
}