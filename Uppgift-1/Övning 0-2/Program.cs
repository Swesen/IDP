using System;

namespace Övning_0_2
{
    class Program
    {

        static string name = "Linus Boréus", street = "Nån Gata 99", zipCity = "111 99 STOCKHOLM";
        static string[] strings;
        static int maxStringLength;
        static int[] cursorPos = { 0, 0 };

        static string input;

        static void Main(string[] args)
        {
            do
            {
                Console.Write("Ange antal tecken från vänsterkanten: ");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out cursorPos[0]) || int.Parse(input) > Console.BufferWidth);

            do
            {
                Console.Write("Ange antal tecken från fösntrets övre kant: ");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out cursorPos[1]));

            strings = new string[] { name, street, zipCity };

            FindLongestString(strings);

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Clear();

            PrintTextBox();

            Console.ReadKey();
        }

        static void FindLongestString(string[] strings)
        {
            foreach (string text in strings)
            {
                if (text.Length > maxStringLength)
                {
                    maxStringLength = text.Length;
                }
            }
        }

        static void PrintTextBox()
        {
            for (int i = 0; i < strings.Length + 2; i++)
            {
                Console.SetCursorPosition(cursorPos[0], cursorPos[1]);

                if (i == 0 || i == strings.Length + 1)
                {
                    for (int j = 0; j < maxStringLength + 4; j++)
                    {
                        Console.Write("*");
                    }
                    cursorPos[1]++;
                }
                else
                {
                    Console.Write("* ");
                    Console.Write(strings[i - 1]);
                    int fillSpace = maxStringLength - strings[i - 1].Length;
                    for (int j = 0; j < fillSpace; j++)
                    {
                        Console.Write(" ");
                    }
                    Console.Write(" *");
                    cursorPos[1]++;
                }
            }

        }
    }
}
