using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AddressBookFileIO
{
    internal class Contact
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }


        public Contact(string Name, string Email, string Phone, string State, string City, string ZipCode)
        {
            if (!IsValidEmail(Email))
                throw new ArgumentException(" Invalid email address");

            if (!IsValidPhone(Phone))
                throw new ArgumentException(" Invalid phone number");

            if (!IsValidZipcode(ZipCode))
                throw new ArgumentException(" Invalid ZIP code");

            this.Name = Name;
            this.Email = Email;
            this.Phone = Phone;
            this.State = State;
            this.City = City;
            this.ZipCode = ZipCode;
        }

        public override string ToString()
        {
            return $"Name: {Name}\nEmail: {Email}\nPhone: {Phone}\nState: {State}\nCity: {City}\nZip: {ZipCode}";
        }

        private static bool IsValidEmail(string email)
        {
            // Regular expression to validate email addresses
            string EmailPattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            return Regex.IsMatch(email, EmailPattern);
        }

        private static bool IsValidPhone(string phone)
        {
            // Regular expression to validate phone numbers
            string PhonePattern = "^\\d{10}$";
            return Regex.IsMatch(phone, PhonePattern);
        }

        private static bool IsValidZipcode(string ZipCode)
        {
            // Regular expression to validate ZIP codes (5 digits)
            string ZipCodePattern = @"^\d{5}$";
            return Regex.IsMatch(ZipCode, ZipCodePattern);
        }
    }
}
