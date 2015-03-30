namespace Phonebook.Importer
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Web.Script.Serialization;

    using Phonebook.Data;
    using Phonebook.Dto;

    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            var filePath = File.ReadAllText("../../contacts.json");
            var mySerializer = new JavaScriptSerializer();

            var contacts = mySerializer.Deserialize<ContactDto[]>(filePath);

            foreach (var contactDto in contacts)
            {
                var c = new Contact { Name = contactDto.Name, Phones = new HashSet<Phone>(), Emails = new HashSet<Email>() };
                foreach (var phone in c.Phones)
                {
                    c.Phones.Add(phone);
                }

                //foreach (var email in c.Emails)
                //{
                //    c.Phones.Add(email);
                //}  
            }

            //foreach (var contact in contacts)
            //{
            //    Console.WriteLine(contact.Name);
            //    if (contact.Company != null)
            //    {
            //        Console.WriteLine("\tCompany: " + contact.Company);
            //    }

            //    if (contact.Position != null)
            //    {
            //        Console.WriteLine("\tPosition: " + contact.Position);
            //    }

            //    if (contact.Phones != null)
            //    {
            //        Console.WriteLine("\tPhones: " + string.Join(", ", contact.Phones));
            //    }

            //    if (contact.Emails != null)
            //    {
            //        Console.WriteLine("\tEmails: " + string.Join(", ", contact.Emails));
            //    }
            //}
        }
    }
}
