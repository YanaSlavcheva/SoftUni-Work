using System;
using System.Collections.Generic;
class EmployeeData
{
    static void Main()
    {
        Console.WriteLine("Please, enter the following information:");
        Console.WriteLine("First name:");
        string firstName = Console.ReadLine();
        Console.WriteLine("Last name:");
        string lastName = Console.ReadLine();
        Console.WriteLine("Age:");
        byte age = byte.Parse(Console.ReadLine());
        Console.WriteLine("Gender (\"m\" or \"f\"):");
        string gender = Console.ReadLine();
        Console.WriteLine("Personal ID number (e.g. 8306112507):");
        long personalId = long.Parse(Console.ReadLine());
        Console.WriteLine("Unique employee number (27560000…27569999):");
        uint employeeNumber = uint.Parse(Console.ReadLine());
        Console.WriteLine("The information You entered is as follows:");
        Console.WriteLine("First name: " + firstName);
        Console.WriteLine("Last name: " + lastName);
        Console.WriteLine("Age: " + age);
        string femaleValue = "f";
        if (((string)gender).Contains(femaleValue)) Console.WriteLine("Gender: female");
        else Console.WriteLine("Gender: male");
        Console.WriteLine("Personal ID number: " + personalId);
        Console.WriteLine("Unique employee number: " + employeeNumber);
    }
}
