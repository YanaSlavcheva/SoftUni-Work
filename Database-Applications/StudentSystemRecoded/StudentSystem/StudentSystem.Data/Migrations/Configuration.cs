namespace StudentSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Net.Mime;

    using StudentSystem.Model;

    public sealed class Configuration : DbMigrationsConfiguration<StudentSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "StudentSystem.Data.StudentSystemDbContext";
        }

        //protected override void Seed(StudentSystemDbContext db)
        //{
        //    var cSharpCourse = new Course
        //    {
        //        Name = "C#",
        //        Description = "Best Course ever.",
        //        Price = 200,
        //        StartDate = new DateTime(2014, 02, 02),
        //        EndDate = new DateTime(2014, 03, 30)
        //    };

        //    var peshoStudent = new Student()
        //    {
        //        FirstName = "Pesho",
        //        LastName = "Peshev",
        //        Birthday = new DateTime(2000, 01, 01),
        //        PhoneNumber = "0888888888"
        //    };

        //    var homework1 = new Homework()
        //    {
        //        Content = new byte[] { 0, 1, 0, 1, 0 },
        //        ContentType = HomeworkContentType.Pdf,
        //        Course = cSharpCourse,
        //        Student = peshoStudent,
        //        UploadDateTime = new DateTime(2015, 03, 30)
        //    };

        //    var javaCourse = new Course
        //    {
        //        Name = "Java",
        //        Description = "WTF ?",
        //        Price = 200,
        //        StartDate = new DateTime(2014, 02, 02),
        //        EndDate = new DateTime(2014, 03, 30)
        //    };

        //    var goshoStudent = new Student
        //    {
        //        FirstName = "Gosho",
        //        LastName = "Goshev",
        //        Birthday = new DateTime(2000, 01, 01),
        //        PhoneNumber = "0878888888"
        //    };

        //    var homework2 = new Homework()
        //    {
        //        Content = new byte[] { 0, 1, 0, 1, 1 },
        //        ContentType = HomeworkContentType.Pdf,
        //        Course = javaCourse,
        //        Student = goshoStudent,
        //        UploadDateTime = new DateTime(2015, 03, 30)
        //    };

        //    db.Homeworks.Add(homework1);
        //    db.Homeworks.Add(homework2);
        //    db.SaveChanges();
        //}

        protected override void Seed(StudentSystemDbContext db)
        {
            this.SeedStudents(db);
            db.SaveChanges();
            this.SeedCourse(db);
            db.SaveChanges();
            this.SeedHomeworks(db);
            db.SaveChanges();
            this.SeedResources(db);
            db.SaveChanges();
        }

        private void SeedCourse(StudentSystemDbContext db)
        {
            if (db.Courses.Any())
            {
                return;
            }

            db.Courses.AddOrUpdate(
                c => c.Name,
                new Course
                {
                    Name = "First Course",
                    Description = "Very exciting free course",
                    Price = 0,
                    StartDate = new DateTime(2015, 01, 01),
                    EndDate = new DateTime(2015, 02, 01)
                },
                new Course
                {
                    Name = "Second Course",
                    Description = "Very exciting course",
                    Price = 100,
                    StartDate = new DateTime(2015, 02, 01),
                    EndDate = new DateTime(2015, 03, 01)
                });
        }

        private void SeedResources(StudentSystemDbContext db)
        {
            if (db.Resources.Any())
            {
                return;
            }

            db.Resources.AddOrUpdate(
                r => r.Name,
                new Resource { Name = "Smart Document", Link = "www.smartDocument.com", ResourceType = ResourceType.Document, Course = db.Courses.FirstOrDefault() },
                new Resource { Name = "Smart Presentation", Link = "www.smartPresentation.com", ResourceType = ResourceType.Presentation, Course = db.Courses.FirstOrDefault() },
                new Resource { Name = "Smart Video", Link = "www.smartVideo.com", ResourceType = ResourceType.Video, Course = db.Courses.FirstOrDefault() });
        }

        private void SeedHomeworks(StudentSystemDbContext db)
        {
            if (db.Homeworks.Any())
            {
                return;
            }

            db.Homeworks.AddOrUpdate(
                h => h.UploadDateTime,
                new Homework
                    {
                        Content = new byte[] { 0, 1, 0, 1, 0 },
                        ContentType = HomeworkContentType.Zip,
                        UploadDateTime = new DateTime(2015, 01, 25),
                        Student = db.Students.FirstOrDefault(),
                        Course = db.Courses.FirstOrDefault()
                    },
                new Homework
                    {
                        Content = new byte[] { 0, 1, 0, 1, 1 },
                        ContentType = HomeworkContentType.Zip,
                        UploadDateTime = new DateTime(2015, 01, 26),
                        Student = db.Students.FirstOrDefault(),
                        Course = db.Courses.FirstOrDefault()
                    },
                new Homework
                    {
                        Content = new byte[] { 0, 1, 1, 1, 1 },
                        ContentType = HomeworkContentType.Zip,
                        UploadDateTime = new DateTime(2015, 02, 26),
                        Student = db.Students.FirstOrDefault(),
                        Course = db.Courses.FirstOrDefault()
                    });
        }

        private void SeedStudents(StudentSystemDbContext db)
        {
            if (db.Students.Any())
            {
                return;
            }

            db.Students.AddOrUpdate(
                s => s.Birthday,
                new Student
                    {
                        FirstName = "Ivan",
                        LastName = "Ivanov",
                        PhoneNumber = "123",
                        Birthday = new DateTime(1980, 12, 1)
                    },
                new Student
                    {
                        FirstName = "Peter",
                        LastName = "Petrov",
                        PhoneNumber = "123",
                        Birthday = new DateTime(1980, 12, 2)
                    },
                new Student
                    {
                        FirstName = "Dragan",
                        LastName = "Draganov",
                        PhoneNumber = "123",
                        Birthday = new DateTime(1980, 12, 3)
                    },
                new Student
                    {
                        FirstName = "Vasil",
                        LastName = "Levski",
                        PhoneNumber = "123",
                        Birthday = new DateTime(1980, 12, 4)
                    });
        }
    }
}
