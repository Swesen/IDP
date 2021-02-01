using System;
using System.Linq;

namespace Övning_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] lotteryNumber = new int[7];
            Random random = new Random();

            int currentNumber = 0;
            while (lotteryNumber.Contains(0))
            {
                if (currentNumber == lotteryNumber.Length)
                {
                    currentNumber = 0;
                }
                int temporaryNumber = random.Next(1, 36);

                if (lotteryNumber.Contains(temporaryNumber))
                {
                    temporaryNumber = random.Next(1, 36);
                }
                else
                {
                    lotteryNumber[currentNumber] = temporaryNumber;
                }

                currentNumber++;
            }

            for (int i = 0; i < lotteryNumber.Length; i++)
            {
                Console.Write(lotteryNumber[i] + " ");
            }
        }
    }
}
