using System;

namespace Övning_5
{
    class Program
    {
        static void Main(string[] args)
        {
            int input;
            bool isPrime = true;

            do
            {
                Console.Write("Skriv in ett heltal för att se om det är ett primtal: ");
            } while (!int.TryParse(Console.ReadLine(), out input));

            for (int i = 2; i < input; i++)
            {
                if ((input % i) == 0)
                {
                    isPrime = false;
                    break;
                }
                else
                {
                    isPrime = true;
                }
            }

            if (isPrime)
            {
                Console.WriteLine($"{input} är ett primtal");
            }
            else
            {
                Console.WriteLine($"{input} är inte ett primtal");
            }

        }
    }
}
