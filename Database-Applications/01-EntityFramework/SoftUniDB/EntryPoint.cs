namespace SoftUniDB
{
    using System;
    using System.Linq;

    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            var db = new SoftUniEntities();

            var today = new DateTime();
            today = DateTime.Now;

            var testEmployee = new Employee
            {
                FirstName = "Test",
                MiddleName = "Test",
                LastName = "Test",
                JobTitle = "Test",
                DepartmentID = 1,
                HireDate = today,
                Salary = 1000
            };

            ManageEmployees.InsertEmployee(testEmployee);
            ManageEmployees.DeleteEmployee("Test", "Test", "Test");
            ManageEmployees.ModifyEmployee(298, "FirstName", "Pesho");
            ManageEmployees.PrintEmployee(298);
            
        }
    }
}
