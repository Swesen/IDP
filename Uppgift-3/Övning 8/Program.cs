using System;

namespace Övning_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            for (int i = 0; i < 101; i++)
            {
                Console.Write(random.Next(1, 7) + ", ");
            }
        }
    }
}
