using System;
class FourDigitNumber
{
    static void Main()
    {
        Console.WriteLine("Please, enter a four digit integer \"abcd\": ");
        int number = int.Parse(Console.ReadLine());
        var firstDigit = (number / 1) % 10;
        var secondDigit = (number / 10) % 10;
        var thirdDigit = (number / 100) % 10;
        var fourthDigit = (number / 1000) % 10;
        int a = fourthDigit; //this is just in order to make the code  
        int b = thirdDigit; //more readable and in connection
        int c = secondDigit; //with the variables in the explanation
        int d = firstDigit; //of the Problem in the .doc file
        int sumDigits = (a + b + c + d);
        Console.WriteLine("The sum of the digits is: {0}", sumDigits);
        Console.WriteLine("\"dcba\":{0}{1}{2}{3}", d, c, b, a);
        Console.WriteLine("\"dabc\":{0}{1}{2}{3}", d, a, b, c);
        Console.WriteLine("\"acbd\":{0}{1}{2}{3}", a, c, b, d);
    }
}
