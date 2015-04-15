namespace Messages.Data
{
    using System.ComponentModel.DataAnnotations;

    public class UserMessage
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public string SendByUserId { get; set; }

        public virtual User SendByUser { get; set; }

        [Required]
        public string SendToUserId { get; set; }

        public virtual User SendToUser { get; set; }
    }
}
