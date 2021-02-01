using System;

namespace Övning_4
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "Hello World!";
            Console.WriteLine(text + "\n");

            for (int i = 0; i < text.Length; i++)
            {
                Console.WriteLine(text[i]);
            }
        }
    }
}
