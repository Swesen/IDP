using System;
using System.Threading;

namespace Övning_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = 0;
            do
            {
                Console.Write("Mata in ett positivt heltal: ");
            } while (!int.TryParse(Console.ReadLine(), out input) || !(input > 0));

            if ((input % 2) == 0)
            {
                Console.WriteLine("Ditt tal är jämnt!");
            }
            else
            {
                Console.WriteLine("Ditt tal är udda!");
            }
        }
    }
}
