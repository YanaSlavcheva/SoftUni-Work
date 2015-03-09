namespace SoftUniDB
{
    using System;
    using System.Linq;

    public class ManageEmployees : IEmployeeDao
    {
        public static void InsertEmployee(Employee employee)
        {
            var db = new SoftUniEntities();
            db.Employees.Add(employee);
            db.SaveChanges();
        }

        public static void ModifyEmployee(int employeeId, string propertyName, object newValue)
        {
            var db = new SoftUniEntities();
            var employeeToModify = db.Employees.Find(employeeId);
            if (employeeToModify != null)
            {
                employeeToModify.GetType().GetProperty(propertyName).SetValue(employeeToModify, newValue);
                db.SaveChanges();
            }
            else
            {
                Console.WriteLine("No such employee.");
            }
        }

        public static void DeleteEmployee(string firstName, string middleName, string lastName)
        {
            var db = new SoftUniEntities();
            Employee employeeToDelete =
                db.Employees.First(e => e.FirstName == firstName && e.MiddleName == middleName && e.LastName == lastName);
            db.Employees.Remove(employeeToDelete);
            db.SaveChanges();
        }

        public static void PrintEmployee(int employeeId)
        {
            var db = new SoftUniEntities();
            var employeeToPrint = db.Employees.Find(employeeId);
            foreach (var prop in employeeToPrint.GetType().GetProperties())
            {
                Console.WriteLine("{0} = {1}", prop.Name, prop.GetValue(employeeToPrint, null));
            }
        }

        void IEmployeeDao.ModifyEmployee(int employeeId, string propertyName, object newValue)
        {
            ModifyEmployee(employeeId, propertyName, newValue);
        }

        void IEmployeeDao.DeleteEmployee(string firstName, string middleName, string lastName)
        {
            DeleteEmployee(firstName, middleName, lastName);
        }

        void IEmployeeDao.InsertEmployee(Employee employee)
        {
            InsertEmployee(employee);
        }

        void IEmployeeDao.PrintEmployee(int employeeId)
        {
            PrintEmployee(employeeId);
        }
    }
}
