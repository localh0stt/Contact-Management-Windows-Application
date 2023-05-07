using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_c_sharp
{
    public class Contacts
    {
        public Contacts(int identifier, string contactname, string phonenb, string imageext)
        {
            ID = identifier;
            Name = contactname;
            Number = phonenb;
            ImageExtension = imageext;
        }
        public Contacts()
        {

        }

        public int ID
        {
            get;set;
        }
        public string Name
        {
            get;set;
        }
        public string Number
        {
            get; set;
        }
        public string ImageExtension
        {
            get; set;
        }
    }
}
