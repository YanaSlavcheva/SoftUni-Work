namespace BugTracker.Data.Models
{
    using System;

    public class Bug
    {
        public Bug()
        {
            this.SubmitDate = DateTime.Now;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public BugStatus Status { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public DateTime SubmitDate { get; set; }
    }
}
