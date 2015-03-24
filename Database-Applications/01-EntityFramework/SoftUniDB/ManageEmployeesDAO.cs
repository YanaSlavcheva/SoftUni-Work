namespace SoftUniDB
{
    using System;
    using System.Linq;

    public class ManageEmployeesDao
    {
        public static void InsertEmployee(SoftUniEntities db, Employee employee)
        {
            db.Employees.Add(employee);
            db.SaveChanges();
        }

        public static void ModifyEmployee(SoftUniEntities db, int employeeId, string propertyName, object newValue)
        {
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

        public static void DeleteEmployee(SoftUniEntities db, string firstName, string middleName, string lastName)
        {
            Employee employeeToDelete =
                db.Employees.First(e => e.FirstName == firstName && e.MiddleName == middleName && e.LastName == lastName);
            db.Employees.Remove(employeeToDelete);
            db.SaveChanges();
        }

        public static void PrintEmployee(SoftUniEntities db, int employeeId)
        {
            var employeeToPrint = db.Employees.Find(employeeId);
            foreach (var prop in employeeToPrint.GetType().GetProperties())
            {
                Console.WriteLine("{0} = {1}", prop.Name, prop.GetValue(employeeToPrint, null));
            }
        }

        public static void FindEmployeesStartDateInYear(SoftUniEntities db, DateTime date)
        {
            var year = date.Year;

            var employeesWProjectsWStartDateInYear =
                db.Employees.Where(e => e.Projects.Any(p => p.StartDate.Year == year));

            foreach (var employee in employeesWProjectsWStartDateInYear)
            {
                Console.WriteLine("Employee Name: {0} {1}", employee.FirstName, employee.LastName);
                Console.WriteLine("Projects Names: ");
                foreach (var project in employee.Projects)
                {
                    Console.WriteLine("{0}; Start Date: {1}", project.Name, project.StartDate);
                }

                Console.WriteLine();
            }
        }

        public static void FindEmployeesStartDateInYearNativeSql(SoftUniEntities db, DateTime date)
        {
            var year = date.Year;
            const string SqlQuery = "SELECT e.FirstName, e.LastName, p.Name, p.StartDate FROM Employees e JOIN EmployeesProjects ep ON e.EmployeeID = ep.EmployeeID JOIN Projects p ON ep.ProjectID = p.ProjectID WHERE p.StartDate BETWEEN ('2002-01-01') AND ('2002-12-31')";

            var employeesWProjectsWStartDateInYear = db.Database.SqlQuery<string>(SqlQuery).ToList();

            foreach (var employee in employeesWProjectsWStartDateInYear)
            {
                Console.WriteLine(employee);
            }
        }

        public static void FindEmployeesByDepartmentAndManager(
            SoftUniEntities db,
            string departmentName,
            string managerFirstName,
            string managerLastName)
        {
            var manager =
                db.Employees.FirstOrDefault(m => m.FirstName == managerFirstName && m.LastName == managerLastName);
            var employees =
                db.Employees.Where(e => e.Department.Name == departmentName && e.ManagerID == manager.EmployeeID);

            foreach (var employee in employees)
            {
                Console.WriteLine("Employee Name: {0} {1}", employee.FirstName, employee.LastName);
                Console.WriteLine("Department Name: {0}", employee.Department.Name);
                if (manager != null)
                {
                    Console.WriteLine("Manager Name: {0} {1}", manager.FirstName, manager.LastName);
                }
                Console.WriteLine();
            }
        }
    }
}
