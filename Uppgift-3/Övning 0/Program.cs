using System;

namespace Övning_0
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 625; i <= 767; i++)
            {
                if ((i % 2) > 0)
                {
                    Console.Write(i + ", ");
                }
            }
        }
    }
}
