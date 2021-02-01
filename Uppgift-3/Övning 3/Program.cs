using System;

namespace Övning_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int total = 0;

            for (int i = 1; i < 101; i++)
            {
                total += i;
            }

            Console.WriteLine("Talen 1 - 100 summerade blir: " + total);
        }
    }
}
