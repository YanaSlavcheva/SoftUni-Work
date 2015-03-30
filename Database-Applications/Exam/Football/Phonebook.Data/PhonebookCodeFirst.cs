namespace Phonebook.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PhonebookCodeFirst
    {
        public static void Main(string[] args)
        {
            var db = new PhonebookContext();
            Database.SetInitializer(new PhonebookMigrationStrategy());

            var contactsQuery =
                db.Contacts.Select(
                    c => new
                             {
                                 Name = c.Name,
                                 Phones = c.Phones.Select(p => new { p.PhoneNumber }),
                                 Emails = c.Emails.Select(e => new { e.EmailAddress })
                             });

            foreach (var contact in contactsQuery)
            {
                Console.WriteLine("Contact: " + contact.Name);
                if (contact.Phones != null)
                {
                    foreach (var phone in contact.Phones)
                    {
                        Console.WriteLine("\tPhone: " + phone.PhoneNumber);
                    }
                }

                if (contact.Emails != null)
                {
                    foreach (var email in contact.Emails)
                    {
                        Console.WriteLine("\tEmail: " + email.EmailAddress);
                    }
                }
            }
        }
    }
}
