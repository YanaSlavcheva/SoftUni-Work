namespace SoftUniDB
{
    using System.Security.Cryptography.X509Certificates;

    public interface IEmployeeDao
    {
        void InsertEmployee(Employee employee);

        void ModifyEmployee(int employeeId, string propertyName, object newValue);

        void DeleteEmployee(string firstName, string middleName, string lastName);

        void PrintEmployee(int employeeId);

        // delete by ID
        // delete by FirstName
        // delete by LastName
        // delete by JobTitle
    }
}
