using System;
namespace SoftUniDB.Tests
{
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SoftUniDB;

    [TestClass]
    public class ManageEmployeesDaoTests
    {
        [TestMethod]
        public void InsertEmployeeTestMethod()
        {
            var db = new SoftUniEntities();
            var today = DateTime.Now;
            var testEmployee = new Employee
            {
                FirstName = "TestInsert",
                MiddleName = "TestInsert",
                LastName = "TestInsert",
                JobTitle = "TestInsert",
                DepartmentID = 1,
                HireDate = today,
                Salary = 1000
            };

            ManageEmployeesDao.InsertEmployee(testEmployee);
            var result = db.Employees.Select(a => a.HireDate > today);
            Console.WriteLine(result);
            // well.... TODO
        }
    }
}
