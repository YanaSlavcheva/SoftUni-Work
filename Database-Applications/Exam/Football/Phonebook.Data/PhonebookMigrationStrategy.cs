namespace Phonebook.Data
{
    using System.Data.Entity;

    public class PhonebookMigrationStrategy : DropCreateDatabaseIfModelChanges<PhonebookContext>
    {
        protected override void Seed(PhonebookContext context)
        {
            var emailPesho1 = new Email { EmailAddress = "peter@gmail.com" };
            var emailPesho2 = new Email { EmailAddress = "peter_ivanov@yahoo.com" };
            context.Emails.Add(emailPesho1);
            context.Emails.Add(emailPesho2);
            var phonePesho1 = new Phone { PhoneNumber = "+359 2 22 22 22" };
            var phonePesho2 = new Phone { PhoneNumber = "+359 88 77 88 99" };
            context.Phones.Add(phonePesho1);
            context.Phones.Add(phonePesho2);

            var pesho = new Contact
                            {
                                Name = "Peter Ivanov",
                                Position = "CTO",
                                Company = "Smart Ideas",
                                Site = "http://blog.peter.com",
                                Notes = "Friend from school"
                            };
            pesho.Emails.Add(emailPesho1);
            pesho.Emails.Add(emailPesho2);
            pesho.Phones.Add(phonePesho1);
            pesho.Phones.Add(phonePesho2);
            context.Contacts.Add(pesho);

            var phoneMaria = new Phone { PhoneNumber = "+359 22 33 44 55" };
            context.Phones.Add(phoneMaria);
            var maria = new Contact { Name = "Maria" };
            maria.Phones.Add(phoneMaria);
            context.Contacts.Add(maria);

            var emailAngie = new Email { EmailAddress = "info@angiestanton.com" };
            context.Emails.Add(emailAngie);
            var angie = new Contact { Name = "Angie Stanton", Site = "http://angiestanton.com" };
            angie.Emails.Add(emailAngie);
            context.Contacts.Add(angie);
        }
    }
}
