using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace AddressBookFileIO
{
    internal class Addressbook
    {
        private const string FilePath = "C:\\Users\\Sukanay\\Desktop\\addresss.json";

        List<Contact> contactList = new List<Contact>();

        public Addressbook()
        {
            contactList = LoadContactsFromFile();
        }

        public bool AddContact()
        {
            Console.WriteLine("Enter name");
            string? name = Console.ReadLine();
            Console.WriteLine("Enter email");
            string? email = Console.ReadLine();
            Console.WriteLine("Enter phone");
            string? phone = Console.ReadLine();
            Console.WriteLine("Enter state");
            string? state = Console.ReadLine();
            Console.WriteLine("Enter city");
            string? city = Console.ReadLine();
            Console.WriteLine("Enter zip");
            string? zip = Console.ReadLine();
            Contact contact = new Contact(name, email, phone, state, city, zip);

            bool isDuplicate = contactList.Any(existingContact => existingContact.Phone == phone);

            if (!isDuplicate)
            {
                contactList.Add(contact);
                SaveContactsToFile();
                return true;
            }
            else
            {
                throw new ContactAlreadyExistsException("Duplicate contact");
            }
        }

        public List<Contact> Display()
        {
            contactList = LoadContactsFromFile();
            if (contactList.Count == 0)
            {
                throw new EmptyContactListException("Contact list is empty.");
            }
            return contactList;
        }

        public bool Delete()
        {
            Console.WriteLine("Enter name of the contact to be deleted : ");
            string? inputString = Console.ReadLine();

            Contact contactToRemove = contactList.FirstOrDefault(contact => contact.Name == inputString);

            if (contactToRemove != null)
            {
                contactList.Remove(contactToRemove);
                SaveContactsToFile();
                return true;
            }

            return false;
        }

        public bool Edit()
        {
            Console.WriteLine("Enter name of the contact:");
            string? input = Console.ReadLine();

            for (int i = 0; i < contactList.Count; i++)
            {
                Contact contact = contactList[i];

                if (input == contact.Name)
                {
                    Console.WriteLine("Enter name:");
                    string? name = Console.ReadLine();

                    Console.WriteLine("Enter email:");
                    string? email = Console.ReadLine();

                    Console.WriteLine("Enter phone:");
                    string? phone = Console.ReadLine();

                    Console.WriteLine("Enter state:");
                    string? state = Console.ReadLine();

                    Console.WriteLine("Enter city:");
                    string? city = Console.ReadLine();

                    Console.WriteLine("Enter zip:");
                    string? zip = Console.ReadLine();

                    Contact updatedContact = new Contact(name, email, phone, state, city, zip);

                    if (contactList.Contains(updatedContact))
                    {
                        throw new ContactAlreadyExistsException("Contact already exists.");
                    }
                    else
                    {
                        contact.Name = name;
                        contact.Email = email;
                        contact.Phone = phone;
                        contact.State = state;
                        contact.City = city;
                        contact.ZipCode = zip;
                        SaveContactsToFile();
                        return true;
                    }
                }
            }

            return false;
        }

        private void SaveContactsToFile()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };

            string json = JsonConvert.SerializeObject(contactList, settings);
            File.WriteAllText(FilePath, json);
        }

        private List<Contact> LoadContactsFromFile()
        {
            if (File.Exists(FilePath))
            {
                string json = File.ReadAllText(FilePath);
                var contacts = JsonConvert.DeserializeObject<List<Contact>>(json);
                return contacts ?? new List<Contact>();
            }

            return new List<Contact>();
        }
    
}
}
