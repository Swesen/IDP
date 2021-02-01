using System;
using System.Linq;

namespace Övning_4
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isWeekDay = false;
            string[] validDays = { "Måndag", "Tisdag", "Onsdag", "Torsdag", "Fredag", "Lödrag", "Söndag" };
            string input = "";
            int dayNumber = 0;

            do
            {
                Console.Write("Skriv en veckodag: ");
                input = Console.ReadLine();

                for (int i = 0; i < validDays.Length; i++)
                {
                    if (input.ToLower() == validDays[i].ToLower())
                    {
                        isWeekDay = true;
                        dayNumber = i + 1;
                        
                        continue;
                    } 
                }
            } while (!isWeekDay);

            Console.WriteLine($"{input.First().ToString().ToUpper() + input.Substring(1)} är dag {dayNumber} i veckan!");
        }
    }
}
