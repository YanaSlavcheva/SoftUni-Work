namespace Phonebook.Dto
{
    using System.Collections.Generic;

    using Phonebook.Data;

    public class ContactDto
    {
        //Contacts have name and optionally position, company, emails, phones, site (URL) and notes (free text)

        private ICollection<string> emails;

        private ICollection<string> phones;

        public ContactDto()
        {
            this.emails = new HashSet<string>();
            this.phones = new HashSet<string>();
        }

        public string Name { get; set; }

        public string Position { get; set; }

        public string Company { get; set; }

        public string Site { get; set; }

        public string Notes { get; set; }

        public virtual ICollection<string> Emails
        {
            get
            {
                return this.emails;
            }

            set
            {
                this.emails = value;
            }
        }

        public virtual ICollection<string> Phones
        {
            get
            {
                return this.phones;
            }

            set
            {
                this.phones = value;
            }
        }
    }
}
