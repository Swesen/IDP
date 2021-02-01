using System;

namespace Övning_5
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "Hello World!";
            Console.WriteLine(text);

            for (int i = text.Length - 1; i >= 0; i--)
            {
                Console.Write(text[i]);
            }
        }
    }
}
