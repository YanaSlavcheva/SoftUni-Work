namespace StudentSystem.Model
{
    using System;
    using System.Collections.Generic;

    public class Student
    {

        //Students: id, name, phone number, registration date, birthday
        private ICollection<Course> courses;

        private ICollection<Homework> homeworks;

        public Student()
        {
            this.courses = new HashSet<Course>();
            this.homeworks = new HashSet<Homework>();
            this.RegistrationDate = DateTime.Now;
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime RegistrationDate { get; set; }

        public DateTime Birthday { get; set; }

        public virtual ICollection<Course> Courses
        {
            get
            {
                return this.courses;
            }

            set
            {
                this.courses = value;
            }
        }

        public virtual ICollection<Homework> Homeworks
        {
            get
            {
                return this.homeworks;
            }

            set
            {
                this.homeworks = value;
            }
        }
    }
}
