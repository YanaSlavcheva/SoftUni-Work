namespace StudentSystem.Model
{
    using System;
    using System.Collections.Generic;

    public class Course
    {
        //Courses: id, name, description, start date, end date, price

        private ICollection<Student> students;

        private ICollection<Homework> homeworks;

        private ICollection<Resource> resources;

        public Course()
        {
            this.students = new HashSet<Student>();
            this.homeworks = new HashSet<Homework>();
            this.resources = new HashSet<Resource>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public float Price { get; set; }

        public virtual ICollection<Student> Students
        {
            get
            {
                return this.students;
            }

            set
            {
                this.students = value;
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

        public virtual ICollection<Resource> Resources
        {
            get
            {
                return this.resources;
            }

            set
            {
                this.resources = value;
            }
        }
    }
}
