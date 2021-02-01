using System;

namespace Övning_7
{
    class Program
    {
        static void Main(string[] args)
        {
            int printedPrimes = 0, currentNumber = 0;

            do
            {
                for (int i = 2; i < currentNumber + 1; i++)
                {
                    if (i == currentNumber)
                    {
                        Console.Write(currentNumber + ", ");
                        printedPrimes++;
                    }
                    else if ((currentNumber % i) == 0)
                    {
                        break;
                    }

                }
                currentNumber++;
            } while (printedPrimes < 100);

        }
    }
}
