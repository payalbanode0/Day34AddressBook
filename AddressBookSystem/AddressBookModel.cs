using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    internal class AddressBookModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string _address { get; set; }
        public string City { get; set; }
        public string _State { get; set; }
        public int Zip { get; set; }
        public string PhoneNumber { get; set; }
        public string email { get; set; }
        public string RelationType { get; set; }

    }
}