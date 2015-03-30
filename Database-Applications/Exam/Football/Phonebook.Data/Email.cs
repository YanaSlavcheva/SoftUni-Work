namespace Phonebook.Data
{
    using System.ComponentModel.DataAnnotations;

    public class Email
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string EmailAddress { get; set; }
    }
}
