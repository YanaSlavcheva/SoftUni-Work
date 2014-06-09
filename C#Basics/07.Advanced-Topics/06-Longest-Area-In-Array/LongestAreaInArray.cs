using System;
class LongestAreaInArray
{
    static void Main()
    {
        //we get the input
        int n = int.Parse(Console.ReadLine());
        string[] inputArray = new string[n];
        //we fill the array
        for (int i = 0; i < n; i++)
        {
            inputArray[i] = Console.ReadLine();
        }

        //actual task solving
        int resultCount = 0;
        string resultValue = inputArray[0];

        int countEqualMembers = 1;
        int maxCount = countEqualMembers;

        //we search the array member by member
        for (int i = 1; i < n; i++)
        {
            string currentMember = inputArray[i];
            string prevMember = inputArray[i - 1];

            if (prevMember == currentMember)
            {
                countEqualMembers++;
                if (countEqualMembers > maxCount)
                {
                    maxCount = countEqualMembers;
                    resultCount = countEqualMembers;
                    resultValue = currentMember;
                }  
            }
            else if (prevMember != currentMember)
            {
                countEqualMembers = 1;
            }
        }
        Console.WriteLine(maxCount);
        for (int i = 0; i < maxCount; i++)
        {
            Console.WriteLine(resultValue);
        }
    }
}
