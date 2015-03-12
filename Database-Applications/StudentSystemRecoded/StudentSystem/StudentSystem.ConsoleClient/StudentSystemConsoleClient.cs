namespace StudentSystem.ConsoleClient
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using StudentSystem.Data;
    using StudentSystem.Model;

    public class StudentSystemConsoleClient
    {
        public static void Main()
        {
            var db = new StudentSystemDbContext();

            //var student = new Student
            //                  {
            //                      //Students: id, name, phone number, registration date, birthday
            //                      FirstName = "Gergan",
            //                      LastName = "Petrov",
            //                      PhoneNumber = "123",
            //                      Birthday = new DateTime(2000, 12, 10)
            //                  };
            //db.Students.Add(student);
            //db.SaveChanges();

            //var savedStudent = db.Students.First();
            //Console.WriteLine(savedStudent.Id + " " + savedStudent.FirstName + " " + savedStudent.LastName);

            //Add new student
            db.Students.AddOrUpdate(new Student
            {
                FirstName = "Peter",
                LastName = "Ivanov",
                Birthday = new DateTime(1980, 1, 1),
                RegistrationDate = new DateTime(2015, 2, 1)
            });

            // Add new resource
            var resourceFirst = new Resource
            {
                Name = "New video",
                ResourceType = ResourceType.Video,
                Link = "www.youtube.com"
            };

            var resourceSecond = new Resource
            {
                Name = "Something",
                Link = "www.dir.bg",
                ResourceType = ResourceType.Other,
            };

            db.Resources.AddOrUpdate(resourceFirst, resourceSecond);

            // Add new courses
            var course1 = new Course
            {
                Name = "C# Intro",
                Description = "description",
                StartDate = new DateTime(2014, 1, 1),
                EndDate = new DateTime(2014, 1, 30),
                Price = 180
            };

            var course2 = new Course
            {
                Name = "Seminar",
                Description = "description",
                StartDate = new DateTime(2015, 2, 1),
                EndDate = new DateTime(2015, 2, 25),
                Price = 0
            };

            course1.Resources.Add(resourceFirst);
            course2.Resources.Add(resourceSecond);
            db.Courses.AddOrUpdate(course1, course2);

            db.SaveChanges();

            // Lists all students and their homework submissions
            Console.WriteLine(" * Lists all students and their homework submissions");

            var students = db.Students
                .Include(s => s.Homeworks)
                .Select(s => new
                {
                    s.FirstName,
                    s.Homeworks
                });

            foreach (var student in students)
            {
                Console.WriteLine(student.FirstName);
                var homeworks = student.Homeworks;
                if (homeworks.Count == 0)
                {
                    Console.WriteLine("    no homeworks");
                }
                else
                {
                    foreach (var homework in homeworks)
                    {
                        Console.WriteLine("    - " + homework.UploadDateTime);
                    }
                }
            }

            Console.WriteLine();

            // List all course and their resources
            Console.WriteLine(" * List all course and their resources");

            var courses = db.Courses
                .Include(c => c.Resources)
                .Select(c => new
                {
                    c.Name,
                    c.Resources
                });

            foreach (var course in courses)
            {
                Console.WriteLine(course.Name);
                var resourses = course.Resources;
                if (resourses.Count == 0)
                {
                    Console.WriteLine("    no resourses");
                }
                else
                {
                    foreach (var resourse in resourses)
                    {
                        Console.WriteLine("    {0}; {1}", resourse.Name, resourse.Link);
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
