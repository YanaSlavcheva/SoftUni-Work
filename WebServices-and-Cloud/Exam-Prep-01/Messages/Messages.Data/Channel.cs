namespace Messages.Data
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Channel
    {
        private ICollection<ChannelMessage> messages;

        public Channel()
        {
            this.messages = new HashSet<ChannelMessage>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }

        public ICollection<ChannelMessage> Messages
        {
            get
            {
                return this.messages;
            }

            set
            {
                this.messages = value;
            }
        }
    }
}
