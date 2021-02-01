using System;

namespace Övning_9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Skriv in hur många Yatzy-kast du vill göra med 5 tärningar: ");
            int.TryParse(Console.ReadLine(), out int input);

            int[,] diceThrow = new int[5, input];

            Random random = new Random();


            for (int i = 0; i < input; i++)
            {
                for (int dice = 0; dice < 5; dice++)
                {
                    diceThrow[dice, i] = random.Next(1, 7);
                }
            }

            for (int i = 0; i < input; i++)
            {
                Console.Write($"Kast {i + 1}:");
                for (int dice = 0; dice < 5; dice++)
                {
                    Console.Write($" {diceThrow[dice, i]}");
                }
                Console.WriteLine();
            }
        }
    }
}
