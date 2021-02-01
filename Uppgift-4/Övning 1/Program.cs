using System;

namespace Övning_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] randomArray = new int[100];
            int numberToFind = 53;
            Random random = new Random();

            for (int i = 0; i < randomArray.Length; i++)
            {
                randomArray[i] = random.Next(1, 101);
            }

            for (int i = 0; i < randomArray.Length; i++)
            {
                if (randomArray[i] == numberToFind)
                {
                    Console.WriteLine($"Talet på plats {i} i din array är lika med {numberToFind}");
                    break;
                }

                if (i == randomArray.Length - 1)
                {
                    Console.WriteLine($"Talet {numberToFind} finns inte med i din array");
                }
            }
        }
    }
}
