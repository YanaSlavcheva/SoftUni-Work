using System;
class HexadecimalDecimal
{
    static void Main()
    {
        string input = Console.ReadLine();
        string[] inputArray = new string[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            inputArray[i] = Convert.ToString(input[i]);
        }
        Array.Reverse(inputArray);
        int numberOperate;
        double decimalNumber = 0;
        for (int k = 0; k < input.Length; k++)
        {
            numberOperate = GetNumberToMultiplyValue(inputArray, k);
            decimalNumber += numberOperate * Math.Pow(16, k);
        }
        long result = (long)decimalNumber;
        Console.WriteLine(result);
    }

    private static int GetNumberToMultiplyValue(string[] inputArray, int k)
    {
        int numberToMultiply = 0;
        switch (inputArray[k])
        {
            case "0":
                {
                    numberToMultiply = 0;
                }
                break;
            case "1":
                {
                    numberToMultiply = 1;
                }
                break;
            case "2":
                {
                    numberToMultiply = 2;
                }
                break;
            case "3":
                {
                    numberToMultiply = 3;
                }
                break;
            case "4":
                {
                    numberToMultiply = 4;
                }
                break;
            case "5":
                {
                    numberToMultiply = 5;
                }
                break;
            case "6":
                {
                    numberToMultiply = 6;
                }
                break;
            case "7":
                {
                    numberToMultiply = 7;
                }
                break;
            case "8":
                {
                    numberToMultiply = 8;
                }
                break;
            case "9":
                {
                    numberToMultiply = 9;
                }
                break;
            case "A":
                {
                    numberToMultiply = 10;
                }
                break;
            case "B":
                {
                    numberToMultiply = 11;
                }
                break;
            case "C":
                {
                    numberToMultiply = 12;
                }
                break;
            case "D":
                {
                    numberToMultiply = 13;
                }
                break;
            case "E":
                {
                    numberToMultiply = 14;
                }
                break;
            case "F":
                {
                    numberToMultiply = 15;
                }
                break;
            default:
                break;
        }
        return numberToMultiply;
    }
}
