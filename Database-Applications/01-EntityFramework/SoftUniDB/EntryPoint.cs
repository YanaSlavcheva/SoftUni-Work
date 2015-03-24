namespace SoftUniDB
{
    using System;
    using System.Linq;

    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            var db = new SoftUniEntities();

            ////Problem 02
            //var today = DateTime.Now;
            //var testEmployee = new Employee
            //{
            //    FirstName = "Test",
            //    MiddleName = "Test",
            //    LastName = "Test",
            //    JobTitle = "Test",
            //    DepartmentID = 1,
            //    HireDate = today,
            //    Salary = 1000
            //};

            //ManageEmployeesDao.InsertEmployee(db, testEmployee);
            //ManageEmployeesDao.DeleteEmployee(db, "Test", "Test", "Test");
            //ManageEmployeesDao.ModifyEmployee(db, 298, "FirstName", "Pesho");
            //ManageEmployeesDao.PrintEmployee(db, 298);   
 
            ////Problem 03
            //ManageEmployeesDao.FindEmployeesStartDateInYear(db, new DateTime(2012, 01, 01));

            //Problem 04
            //ManageEmployeesDao.FindEmployeesStartDateInYearNativeSql(db, new DateTime(2012, 01, 01));

            //Problem 05
            ManageEmployeesDao.FindEmployeesByDepartmentAndManager(db, "Production", "Jo", "Brown");
        }
    }
}
