using System;

namespace Övning_9
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int[] diceThrow = new int[1000000], diceResults = { 0, 0, 0, 0, 0, 0 };

            for (int i = 0; i < diceThrow.Length; i++)
            {
                diceThrow[i] = random.Next(1, 7);
            }

            for (int i = 0; i < diceThrow.Length; i++)
            {
                switch (diceThrow[i])
                {
                    case 1:
                        diceResults[0]++;
                        break;
                    case 2:
                        diceResults[1]++;
                        break;
                    case 3:
                        diceResults[2]++;
                        break;
                    case 4:
                        diceResults[3]++;
                        break;
                    case 5:
                        diceResults[4]++;
                        break;
                    case 6:
                        diceResults[5]++;
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine($"På {diceThrow.Length} tärningsslag blir resultatet:");
            Console.WriteLine(diceResults[0] + "st ettor");
            Console.WriteLine(diceResults[1] + "st tvåor");
            Console.WriteLine(diceResults[2] + "st treor");
            Console.WriteLine(diceResults[3] + "st fyror");
            Console.WriteLine(diceResults[4] + "st femmor");
            Console.WriteLine(diceResults[5] + "st sexor");
        }
    }
}
