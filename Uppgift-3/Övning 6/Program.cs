using System;

namespace Övning_6
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] fibonacci = new long[50];

            fibonacci[0] = 0;
            fibonacci[1] = 1;

            for (int i = 2; i < fibonacci.Length; i++)
            {
                fibonacci[i] = fibonacci[i - 2] + fibonacci[i - 1];
            }

            for (int i = 0; i < fibonacci.Length; i++)
            {
                Console.Write(fibonacci[i] + ", ");
            }
        }
    }
}
