using System;

namespace Övning_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int minInt, maxInt, total = 0;

            Console.WriteLine("Summera alla heltal mellan två  tal");

            do
            {
                Console.Write("Skriv in det lägsta talet: ");
            } while (!int.TryParse(Console.ReadLine(), out minInt));

            do
            {
                Console.Write("Skriv in det högsta talet: ");
            } while (!int.TryParse(Console.ReadLine(), out maxInt));

            for (int i = minInt; i < maxInt; i++)
            {
                total += i;
            }

            Console.WriteLine();
            Console.WriteLine($"Alla heltal mellan {minInt} och {maxInt} blir summerade: {total}");
        }
    }
}
