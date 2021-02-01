using System;

namespace Övning_7
{
    class Program
    {
        static void Main(string[] args)
        {
            int max = 12;
            int[,] multiplications = new int[max, max];

            for (int i = 0; i < max; i++)
            {
                Console.WriteLine($"****** {i + 1}:ans tabell ******");
                for (int j = 0; j < max; j++)
                {
                    multiplications[i, j] = (i + 1) * (j + 1);
                    Console.WriteLine($"       {i + 1} x {j + 1} = {multiplications[i, j]}");
                }
                Console.WriteLine("___________________________");
            }
        }
    }
}
