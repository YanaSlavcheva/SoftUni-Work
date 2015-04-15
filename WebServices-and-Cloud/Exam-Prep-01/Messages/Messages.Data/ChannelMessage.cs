namespace Messages.Data
{
    public class ChannelMessage
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int ChannelId { get; set; }

        public virtual Channel Channel { get; set; }


    }
}
