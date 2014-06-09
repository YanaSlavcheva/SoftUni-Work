using System;
using System.Collections.Generic;
class DecimalHexadecimal
{
    static void Main()
    {
        long decimalNumber = long.Parse(Console.ReadLine());
        long operatingNumber = decimalNumber;
        List<string> hexNumber = new List<string>();
        long remainder;
        int counter = 0;
        do
        {
            remainder = operatingNumber % 16;
            operatingNumber = operatingNumber / 16;
            string symbolHex;
            symbolHex = ConvertRemainderToHexSymbol(remainder);
            hexNumber.Add(symbolHex);
            counter++;

        } while (operatingNumber != 0);

        for (int i = counter - 1; i >= 0; i--)
        {
            Console.Write(hexNumber[i]);
        }
        Console.WriteLine();
    }

    private static string ConvertRemainderToHexSymbol(long remainder)
    {
        string symbolHex = "";
        switch (remainder)
        {
            case 0:
                {
                    symbolHex = "0";
                }
                break;
            case 1:
                {
                    symbolHex = "1";
                }
                break;
            case 2:
                {
                    symbolHex = "2";
                }
                break;
            case 3:
                {
                    symbolHex = "3";
                }
                break;
            case 4:
                {
                    symbolHex = "4";
                }
                break;
            case 5:
                {
                    symbolHex = "5";
                }
                break;
            case 6:
                {
                    symbolHex = "6";
                }
                break;
            case 7:
                {
                    symbolHex = "7";
                }
                break;
            case 8:
                {
                    symbolHex = "8";
                }
                break;
            case 9:
                {
                    symbolHex = "9";
                }
                break;
            case 10:
                {
                    symbolHex = "A";
                }
                break;
            case 11:
                {
                    symbolHex = "B";
                }
                break;
            case 12:
                {
                    symbolHex = "C";
                }
                break;
            case 13:
                {
                    symbolHex = "D";
                }
                break;
            case 14:
                {
                    symbolHex = "E";
                }
                break;
            case 15:
                {
                    symbolHex = "F";
                }
                break;
            default:
                break;
        }
        return symbolHex;
    }


}
