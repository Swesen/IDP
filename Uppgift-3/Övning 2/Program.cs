using System;

namespace Övning_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int input;
            do
            {
                Console.Write("Skriv ett heltal(0 för att avsluta) för att se om det är jämnt delbart med 9: ");
                bool isNumber = int.TryParse(Console.ReadLine(), out input);

                if (isNumber)
                {
                    
                    if ((input % 9) == 0 && input != 0)
                    {
                        Console.WriteLine($"{input} är jämnt delbart med 9.");
                    }
                    else
                    {
                        Console.WriteLine($"{input} är inte jämnt delbart med 9.");
                    }

                }

            } while (input != 0);
        }
    }
}
