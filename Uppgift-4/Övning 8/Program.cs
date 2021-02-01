using System;

namespace Övning_8
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[1000];

            Random random = new Random();

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(1, 101);
            }

            int ammountOddNumbers = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if ((numbers[i] % 2) > 0)
                {
                    ammountOddNumbers++;
                }
            }

            int[] oddNumbers = new int[ammountOddNumbers];
            int[] evenNumbers = new int[numbers.Length - ammountOddNumbers];
            int currentEven = 0, currentOdd = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if ((numbers[i] % 2) > 0)
                {
                    oddNumbers[currentOdd] = numbers[i];
                    currentOdd++;
                }
                else
                {
                    evenNumbers[currentEven] = numbers[i];
                    currentEven++;
                }
            }

            Console.WriteLine("Udda tal | Jämna tal");
            Console.WriteLine("====================");
            for (int i = 0; i < Math.Max(currentOdd, currentEven); i++)
            {
                if (oddNumbers.Length > i)
                {
                    Console.SetCursorPosition(3, 2 + i);
                    Console.Write(oddNumbers[i]);
                }

                Console.SetCursorPosition(9, 2 + i);
                Console.Write("|");

                if (evenNumbers.Length > i)
                {
                    Console.SetCursorPosition(14, 2 + i);
                    Console.Write(evenNumbers[i]);
                }
            }
        }
    }
}
