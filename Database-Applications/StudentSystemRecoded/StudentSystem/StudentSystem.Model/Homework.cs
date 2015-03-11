namespace StudentSystem.Model
{
    using System;

    public class Homework
    {
        //Homework: id, content, content-type (e.g. application/pdf or application/zip), date and time

        public Homework()
        {
            this.UploadDateTime = DateTime.Now;
        }

        public int Id { get; set; }

        public byte[] Content { get; set; }

        public HomeworkContentType ContentType { get; set; }

        public DateTime UploadDateTime { get; set; }

        public int CourseId { get; set; }

        public virtual Course Course { get; set; }

        public int StudentId { get; set; }

        public virtual Student Student { get; set; }
    }
}
