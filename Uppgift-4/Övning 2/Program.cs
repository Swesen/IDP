using System;

namespace Övning_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] randomArray = new int[100];
            
            Random random = new Random();

            for (int i = 0; i < randomArray.Length; i++)
            {
                randomArray[i] = random.Next(1, 101);
            }

            for (int i = 1; i < randomArray.Length; i+=2)
            {
                Console.Write(randomArray[i] + ", ");
            }
        }
    }
}
