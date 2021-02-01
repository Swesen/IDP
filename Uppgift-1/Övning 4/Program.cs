using System;

namespace Övning_4
{
    class Program
    {
        static void Main(string[] args)
        {
            double tempCelsius;
            do
            {
                Console.Write("Mata in temperatur i Celsius: ");
            } while (!double.TryParse(Console.ReadLine(), out tempCelsius));
            Console.WriteLine(" ");

            Console.WriteLine($"Temperaturen i farenheit: {ConvertCelsiusToFarenheit(tempCelsius):F1}");

        }

        static double ConvertCelsiusToFarenheit(double celsius)
        {
            return (celsius * (9d / 5d)) + 32;
        }
    }
}
