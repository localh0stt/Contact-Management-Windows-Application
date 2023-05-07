using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing;
using Microsoft.Win32;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Presentation;
using DocumentFormat.OpenXml.Office.CustomUI;
using DocumentFormat.OpenXml.Office2010.Excel;
using Color = System.Drawing.Color;
using System.ComponentModel;

namespace Project1_c_sharp
{
    public static class FileController
    {
        public static void CreateEmptyFile(string filename)
        {
            File.Create(filename).Dispose();
        }
        public static string datapath = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString()).ToString() + @"\data.txt";
        public static string uploadpath = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString()).ToString() + @"\upload";

        public static List<Contacts> GetAllContacts(string datapath)
        {
            List<Contacts> c = new List<Contacts>();
            using (StreamReader r = new StreamReader(datapath))
            {
                string line = null;
                while ((line = r.ReadLine()) != null)
                {
                    string[] fields = line.Split(',');
                    Contacts obj = new Contacts();
                    obj.ID = int.Parse(fields[0]);
                    obj.Name = fields[1];
                    obj.Number = fields[2];
                    obj.ImageExtension = fields[3];
                    c.Add(obj);
                }
            }
            return c;
        }
        public static void DeleteContact(List<Contacts> lst, int id, string uploadpath, string extension, PictureBox box)
        {
            lst.RemoveAll(l => l.ID == id);
            File.Delete(uploadpath + @"\" + id + extension);
        }
        public static void UpdateContact(List<Contacts> lst, int ID, string name, string number, bool imageedited, string imagenewpath, string uploadpath, string imageoldpath)
        {
            string oldImageextension;
            foreach (Contacts Contact in lst)
            {
                if (Contact.ID == ID)
                {
                    oldImageextension = Contact.ImageExtension;
                    if (imageedited)
                    {
                        Contact.ID = ID;
                        Contact.Name = name;
                        Contact.Number = number;
                        Contact.ImageExtension = Path.GetExtension(imagenewpath);
                        Image NewImage = Image.FromFile(imageoldpath);
                        if (NewImage.Width > 638 || NewImage.Height > 359)
                        {
                            Image ResizedImage = FixedSize(NewImage, 638, 359);
                            NewImage.Dispose();
                            string tmp = (Environment.CurrentDirectory + @"\tmp");
                            string OldImgName = Path.GetFileName(imageoldpath);
                            Directory.CreateDirectory(tmp);
                            ResizedImage.Save(tmp + @"\" + OldImgName);
                            ResizedImage.Dispose();
                            File.Delete(uploadpath + @"\" + ID + Path.GetExtension(oldImageextension));
                            File.Copy((tmp + @"\" + OldImgName), imagenewpath);
                            File.Delete(tmp + @"\" + OldImgName);
                            Directory.Delete(tmp);
                        }
                        else
                        {
                            NewImage.Dispose();
                            File.Delete(uploadpath + @"\" + ID + Path.GetExtension(oldImageextension));
                            File.Copy(imageoldpath, imagenewpath);
                        }
                    }
                    else
                    {
                        Contact.ID = ID;
                        Contact.Name = name;
                        Contact.Number = number;
                        Contact.ImageExtension = oldImageextension;
                    }
                }
                else continue;
            }
        }
        public static List<Contacts> FindContact(List<Contacts> lst, string searchtext)
        {
            List<Contacts> contacts = new List<Contacts>();
            foreach (Contacts c in lst)
            {
                if (c.Name.Contains(searchtext) || c.Number.Contains(searchtext)) contacts.Add(c);
            }
            return contacts;
        }
        public static string GetDownloadFolderPath()
        {
            return Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders", "{374DE290-123F-4565-9164-39C4925E467B}", String.Empty).ToString();
        }
        public static Image FixedSize(Image imgPhoto, int Width, int Height)
        {
            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;
            int sourceX = 0;
            int sourceY = 0;
            int destX = 0;
            int destY = 0;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)Width / (float)sourceWidth);
            nPercentH = ((float)Height / (float)sourceHeight);
            if (nPercentH < nPercentW)
            {
                nPercent = nPercentH;
                destX = System.Convert.ToInt16((Width -
                              (sourceWidth * nPercent)) / 2);
            }
            else
            {
                nPercent = nPercentW;
                destY = System.Convert.ToInt16((Height -
                              (sourceHeight * nPercent)) / 2);
            }

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap bmPhoto = new Bitmap(Width, Height,
                              PixelFormat.Format24bppRgb);
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution,
                             imgPhoto.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.Clear(Color.Red);
            grPhoto.InterpolationMode =
                    InterpolationMode.HighQualityBicubic;

            grPhoto.DrawImage(imgPhoto,
                new Rectangle(destX, destY, destWidth, destHeight),
                new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();
            return bmPhoto;
        }
        /*        public static DataTable dt = new DataTable("Contacts");
        public static void initdt(DataTable dat)
        {
            dt.Columns.Add("ID", typeof(Int32));
            dt.Columns.Add("Name", typeof(String));
            dt.Columns.Add("Number", typeof(String));
            dt.Columns.Add("Extension", typeof(String));
        }*/

        /* public static void update(string datapath, string uploadpath, string id, string name, string number, string imageoldpath, string imagenewpath, bool imageedited)
         {
             var lines = File.ReadAllLines(datapath);
             string[] fields;
             string oldImageextension;
             for (int i = 0; i < lines.Length; i++)
             {
                 fields = lines[i].Split(',');
                 if (fields[0] == id)
                 {
                     oldImageextension = fields[3];
                     if (imageedited)
                     {
                         lines[i] = id + "," + name + "," + number + "," + Path.GetExtension(imagenewpath);
                         Image NewImage = Image.FromFile(imageoldpath);
                         if (NewImage.Width > 638 || NewImage.Height > 359)
                         {
                             Image ResizedImage = FixedSize(NewImage, 638, 359);
                             NewImage.Dispose();
                             string tmp = (Environment.CurrentDirectory + @"\tmp");
                             string OldImgName = Path.GetFileName(imageoldpath);
                             Directory.CreateDirectory(tmp);
                             ResizedImage.Save(tmp + @"\" + OldImgName);
                             ResizedImage.Dispose();
                             File.Delete(uploadpath + @"\" + id + Path.GetExtension(oldImageextension));
                             File.Copy((tmp + @"\" + OldImgName), imagenewpath);
                             File.Delete(tmp + @"\" + OldImgName);
                             Directory.Delete(tmp);
                         }
                         else
                         {
                             NewImage.Dispose();
                             File.Delete(uploadpath + @"\" + id + Path.GetExtension(oldImageextension));
                             File.Copy(imageoldpath, imagenewpath);
                         }
                         *//*File.Copy(imageoldpath, imagenewpath);*//*
                     }
                     else
                     {
                         lines[i] = id + "," + name + "," + number + "," + oldImageextension;
                     }
                 }
                 else continue;
             }
             File.WriteAllLines(datapath, lines);
         }*/
        /*        public static void fillgrid(DataGridView dgv, string datapath)
                {
                    if (dt.Columns.Count != 4)
                    {
                        initdt(dt);
                    }
                    if (!File.Exists(datapath))
                    {
                        using (StreamWriter sw = File.CreateText(datapath));
                    }
                    StreamReader file = new StreamReader(datapath);
                    string newline;
                    dt.Rows.Clear();
                    while ((newline = file.ReadLine()) != null)
                    {
                        if (newline != "")
                        {
                            DataRow dr = dt.NewRow();
                            string[] values = newline.Split(',');
                            for (int i = 0; i < values.Length; i++)
                            {
                                dr[i] = values[i];
                            }
                            dt.Rows.Add(dr);
                        }
                        else continue;
                    }
                    file.Close();
                    dgv.DataSource = dt;
                    dgv.Columns[3].Visible = false;
                }*/
        /*        public static void Find(DataGridView grid, TextBox txt, string datapath)
                {
                    var lines = File.ReadAllLines(datapath);
                    string newline;
                    if (txt.Text == "") fillgrid(grid, datapath);
                    else
                    {
                        dt.Rows.Clear();
                        StreamReader file = new StreamReader(datapath);
                        while ((newline = file.ReadLine()) != null)
                        {
                            if (newline != "")
                            {
                                if (newline.Contains(txt.Text))
                                {
                                    DataRow dr = dt.NewRow();
                                    string[] values = newline.Split(',');
                                    for (int i = 0; i < values.Length; i++)
                                    {
                                        dr[i] = values[i];
                                    }
                                    dt.Rows.Add(dr);
                                }
                            }
                            else continue;
                        }
                        grid.DataSource = dt;
                        file.Close();
                    }
                }*/

        /*public static void delete(string id, string datapath, string uploadpath, string extension, PictureBox box)
        {
            if (box.Image != null)
            {
                box.Image.Dispose();
                box.Image = null;
            }
            var lines = File.ReadAllLines(datapath).Where(l => l.Split(',')[0] != id).ToArray();
            File.WriteAllLines(datapath, lines);
            File.Delete(uploadpath + @"\" + id + extension);
        }*/
    }
}