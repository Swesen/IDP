using System;

namespace Övning_5
{
    class Program
    {
        static void Main(string[] args)
        {
            int input;

            do
            {
                Console.Write("Mata in ett heltal: ");
            } while (!int.TryParse(Console.ReadLine(), out input));

            if (input == 0)
            {
                Console.WriteLine("Noll");
            }
            else if (input < 0)
            {
                Console.WriteLine("Negativt");
            }
            else if (input > 0)
            {
                Console.WriteLine("Positivt");
            }

        }
    }
}
