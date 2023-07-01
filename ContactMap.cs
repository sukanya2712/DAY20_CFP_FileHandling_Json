using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookFileIO
{
    internal class ContactMap : ClassMap<Contact>
    {
        public ContactMap()
        {
            Map(m => m.Name).Name("Name"); // Map class property "Name" to CSV header "Name"
            Map(m => m.Email).Name("Email"); // Map class property "Email" to CSV header "Email"
            Map(m => m.Phone).Name("Phone"); // Map class property "Phone" to CSV header "Phone"
            Map(m => m.State).Name("State"); // Map class property "State" to CSV header "State"
            Map(m => m.City).Name("City"); // Map class property "City" to CSV header "City"
            Map(m => m.ZipCode).Name("ZipCode"); // Map class property "ZipCode" to CSV header "ZipCode"
        }
    }
}
