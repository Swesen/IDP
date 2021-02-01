using System;

namespace Övning_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ange en text: ");
            string input = Console.ReadLine();
            bool isPalindrome = true;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != input[input.Length - 1 - i])
                {
                    isPalindrome = false;
                    break;
                }
            }

            if (isPalindrome)
            {
                Console.WriteLine("Texten är en palindrom");
            }
            else
            {
                Console.WriteLine("Texten är inte en palindrom");
            }
        }
    }
}
