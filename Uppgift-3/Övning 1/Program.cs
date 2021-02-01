using System;

namespace Övning_1
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 1000; i++)
            {
                if ((i % 3) == 0 && (i % 7) == 0)
                {
                    Console.Write(i + ", ");
                }
            }
        }
    }
}
