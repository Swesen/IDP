using System;

namespace Övning_3
{
    class Program
    {
        static void Main(string[] args)
        {
            double diameter;
            do
            {
                Console.Write("Ange cirkelns diameter: ");
            } while (!double.TryParse(Console.ReadLine(), out diameter));

            Console.WriteLine(" ");

            Console.WriteLine($"Cirkelns omkerets: {CalculateCircleCurcomference(diameter):F2}");
            Console.WriteLine($"Cirkelns area: {CalculateCircleArea(diameter):F2}");
        }

        static double CalculateCircleCurcomference(double diameter)
        {
            return diameter * Math.PI;
        }

        static double CalculateCircleArea(double diameter)
        {
            return Math.Pow(diameter, 2) * Math.PI / 4;
        }
    }
}
