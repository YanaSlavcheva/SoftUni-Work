using System;
class ProgrammerDNA
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        string startingLetter = Console.ReadLine();

        //we make a string for the letters and we will address them with their index
        string letters = "ABCDEFG";
        
        //we manage the the starting letter with the corr (correction) digit
        //we do that in a method in order to have more readable code
        int corr = 0;
        corr = GetCorrValue(startingLetter, corr);

        int indexLetters = 1;

        //we check how many times we need to draw one segment of the DNA spiral (7 rows)
        //the remainder represents how many rows of a segment we need to draw at the end
        int wholeRepetitions = N / 7;
        int remainderLines = N % 7;

        if (remainderLines == 0)
        {
            for (int i = 0; i < wholeRepetitions; i++)
            {
                //this method draws entire segment of seven lines
                //and returns the index for the next letter to be used
                indexLetters = WriteSevenLines(letters, corr, indexLetters);
                indexLetters++;
            }
        }
        else if (remainderLines != 0)
        {
            for (int i = 0; i < wholeRepetitions; i++)
            {
                indexLetters = WriteSevenLines(letters, corr, indexLetters);
                indexLetters++;
            }
            if (remainderLines < 5)
            {
                //method which draws as many rows as the remainder
                //and returns the index for the next letter to be used
                int currRows = remainderLines;
                indexLetters = DrawingLinesSmallRemainder(letters, corr, indexLetters, currRows);
            }
            else if (remainderLines == 5)
            {
                //we substract 4 from the remainder lines, because we have 4 lines in the increasing part of the DNA segment
                int lowerRows = remainderLines - 4;
                //method which draws five rows
                //and returns the index for the next letter to be used
                indexLetters = DrawingLinesRemainderFive(letters, corr, indexLetters, lowerRows);
            }
            else if (remainderLines == 6)
            {
                int lowerRows = remainderLines - 4;
                //method which draws five rows
                //and returns the index for the next letter to be used
                indexLetters = DrawingLinesRemainderSix(letters, corr, indexLetters);
            }
        }
    }

    private static int DrawingLinesRemainderSix(string letters, int corr, int indexLetters)
    {
        //draw increasing half (first four rows)
        for (int row = 0; row < 4; row++)
        {
            indexLetters--;
            Console.Write("{0}", new string('.', (7 - (2 * row + 1)) / 2));
            for (int i = 0; i < 2 * row + 1; i++)
            {
                if (indexLetters == (7 - row - corr))
                {
                    indexLetters = (0 - row - corr);
                }
                Console.Write(letters[row + corr + indexLetters]);
                indexLetters++;
            }
            Console.Write("{0}", new string('.', (7 - (2 * row + 1)) / 2));
            Console.WriteLine();
        }


        //draw decreasing half
        for (int row = 2; row >= 1; row--)
        {
            indexLetters++;
            Console.Write("{0}", new string('.', (7 - (2 * row + 1)) / 2));
            for (int i = 0; i < 2 * row + 1; i++)
            {
                if (indexLetters == (7 - row - corr))
                {
                    indexLetters = (0 - row - corr);
                }
                Console.Write(letters[row + corr + indexLetters]);
                indexLetters++;

            }
            Console.Write("{0}", new string('.', (7 - (2 * row + 1)) / 2));
            Console.WriteLine();
        }
        return indexLetters;
    }

    private static int DrawingLinesSmallRemainder(string letters, int corr, int indexLetters, int currRows)
    {
        //draw just increasing part with up to four rows
        for (int row = 0; row < currRows; row++)
        {
            indexLetters--;
            Console.Write("{0}", new string('.', (7 - (2 * row + 1)) / 2));
            for (int i = 0; i < 2 * row + 1; i++)
            {
                if (indexLetters == (7 - row - corr))
                {
                    indexLetters = (0 - row - corr);
                }
                Console.Write(letters[row + corr + indexLetters]);
                indexLetters++;
            }
            Console.Write("{0}", new string('.', (7 - (2 * row + 1)) / 2));
            Console.WriteLine();
        }
        return indexLetters;
    }

    private static int DrawingLinesRemainderFive(string letters, int corr, int indexLetters, int lowerRows)
    {
        //draw entire increasing half
        for (int row = 0; row < 4; row++)
        {
            indexLetters--;
            Console.Write("{0}", new string('.', (7 - (2 * row + 1)) / 2));
            for (int i = 0; i < 2 * row + 1; i++)
            {
                if (indexLetters == (7 - row - corr))
                {
                    indexLetters = (0 - row - corr);
                }
                Console.Write(letters[row + corr + indexLetters]);
                indexLetters++;
            }
            Console.Write("{0}", new string('.', (7 - (2 * row + 1)) / 2));
            Console.WriteLine();
        }
        //draw only one row from decreasing half (5 - 4 from increasing part)
        for (int row = 2; row >= 2; row--)
        {
            indexLetters++;
            Console.Write("{0}", new string('.', (7 - (2 * row + 1)) / 2));
            for (int i = 0; i < 2 * row + 1; i++)
            {
                if (indexLetters == (7 - row - corr))
                {
                    indexLetters = (0 - row - corr);
                }
                Console.Write(letters[row + corr + indexLetters]);
                indexLetters++;
            }
            Console.Write("{0}", new string('.', (7 - (2 * row + 1)) / 2));
            Console.WriteLine();
        }
        return indexLetters;
    }

    private static int GetCorrValue(string startingLetter, int corr)
    {
        switch (startingLetter)
        {
            case "A":
                corr = 0;
                break;
            case "B":
                corr = 1;
                break;
            case "C":
                corr = 2;
                break;
            case "D":
                corr = 3;
                break;
            case "E":
                corr = 4;
                break;
            case "F":
                corr = 5;
                break;
            case "G":
                corr = 6;
                break;
            default:
                break;
        }
        return corr;
    }

    private static int WriteSevenLines(string letters, int corr, int indexLetters)
    {
        //draw entire increasing half
        for (int row = 0; row < 4; row++)
        {
            indexLetters--;
            Console.Write("{0}", new string('.', (7 - (2 * row + 1)) / 2));
            for (int i = 0; i < 2 * row + 1; i++)
            {
                if (indexLetters == (7 - row - corr))
                {
                    indexLetters = (0 - row - corr);
                }
                Console.Write(letters[row + corr + indexLetters]);
                indexLetters++;

            }

            Console.Write("{0}", new string('.', (7 - (2 * row + 1)) / 2));
            Console.WriteLine();
        }
        //draw only two rows from decreasing half (6 - 4 from increasing part)
        for (int row = 2; row >= 0; row--)
        {
            indexLetters++;
            Console.Write("{0}", new string('.', (7 - (2 * row + 1)) / 2));
            for (int i = 0; i < 2 * row + 1; i++)
            {
                if (indexLetters == (7 - row - corr))
                {
                    indexLetters = (0 - row - corr);
                }
                Console.Write(letters[row + corr + indexLetters]);
                indexLetters++;
            }
            Console.Write("{0}", new string('.', (7 - (2 * row + 1)) / 2));
            Console.WriteLine();
        }
        return indexLetters;
    }
}
