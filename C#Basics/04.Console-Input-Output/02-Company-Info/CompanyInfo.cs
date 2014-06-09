using System;
class CompanyInfo
{
    static void Main()
    {
        Console.WriteLine("Please enter the following:");
        Console.Write("Company name: ");
        string companyName = Console.ReadLine();
        Console.Write("Company address: ");
        string companyAddress = Console.ReadLine();
        Console.Write("Phone Number: ");
        string companyPhone = Console.ReadLine();
        Console.Write("Fax Number: ");
        string fax = Console.ReadLine();
        Console.Write("Web site: ");
        string webSite = Console.ReadLine();
        Console.Write("Manager first name: ");
        string managerFirstName = Console.ReadLine();
        Console.Write("Manager last name: ");
        string managerLastName = Console.ReadLine();
        Console.Write("Manager age: ");
        string managerAge = Console.ReadLine();
        Console.Write("Manager Phone number: ");
        string managerPhone = Console.ReadLine();
        Console.WriteLine("The data You entered is as follows:");
        Console.WriteLine("Company name: {0}", companyName);
        Console.WriteLine("Phone Number: {0}", companyPhone);
        Console.WriteLine("Fax Number: {0}", fax);
        Console.WriteLine("Web site: {0}", webSite);
        Console.WriteLine("Manager first name: {0}", managerFirstName);
        Console.WriteLine("Manager last name: {0}", managerLastName);
        Console.WriteLine("Manager age: {0}", managerAge);
        Console.WriteLine("Manager Phone number: {0}", managerPhone);
    }
}

//name, address, phone number, fax number, web site and manager. The manager has first name, last name, age and a phone number
