using System;

namespace Övning_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Beräkna avståndet mellan två punkter i ett kordiantsystem.");
            Console.WriteLine("");

            double[] positionX = new double[2];
            double[] positionY = new double[2];
            for (int i = 0; i < 2; i++)
            {
                do
                {
                    Console.Write($"Ange X-kordinaten för p{i+1}: ");
                } while (!double.TryParse(Console.ReadLine(), out positionX[i]));
                do
                {
                    Console.Write($"Ange Y-kordinaten för p{i+1}: ");
                } while (!double.TryParse(Console.ReadLine(), out positionY[i]));
            }

            Console.WriteLine(" ");
            Console.WriteLine($"Avståndet är: {CalculateDistanceBetweenCoordinates(positionX, positionY):F2}");
        }

        static double CalculateDistanceBetweenCoordinates(double[] positionX, double[] positionY)
        {
            double distance = Math.Sqrt(Math.Pow(Math.Abs(positionX[0] - positionX[1]), 2) + Math.Pow(Math.Abs(positionY[0] - positionY[1]), 2));
            return distance;
        }
    }
}
