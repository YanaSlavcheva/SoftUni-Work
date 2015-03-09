namespace SoftUniDB
{
    using System;
    using System.Linq;

    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            var db = new SoftUniEntities();

            var today = DateTime.Now;

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

            ManageEmployeesDao.InsertEmployee(testEmployee);
            ManageEmployeesDao.DeleteEmployee("Test", "Test", "Test");
            ManageEmployeesDao.ModifyEmployee(298, "FirstName", "Pesho");
            ManageEmployeesDao.PrintEmployee(298);    
        }
    }
}
