namespace StudentSystem.ConsoleClient
{
    using System;
    using System.Linq;

    using StudentSystem.Data;
    using StudentSystem.Model;

    public class StudentSystemConsoleClient
    {
        public static void Main()
        {
            var db = new StudentSystemDbContext();

            var student = new Student
                              {
                                  //Students: id, name, phone number, registration date, birthday
                                  FirstName = "Gergan",
                                  LastName = "Petrov",
                                  PhoneNumber = "123",
                                  Birthday = new DateTime(2000, 12, 10)
                              };
            db.Students.Add(student);
            db.SaveChanges();

            var savedStudent = db.Students.First();
            Console.WriteLine(savedStudent.Id + " " + savedStudent.FirstName + " " + savedStudent.LastName);
            Console.ReadKey();
        }
    }
}
