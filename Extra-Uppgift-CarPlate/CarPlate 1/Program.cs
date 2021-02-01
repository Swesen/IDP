using System;

namespace CarPlate_1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool validPlate = false;


            string licensePlate;

            while (true)
            {
                Console.WriteLine();
                Console.Write("Skriv in registreringsskyllt utan mellanrum: ");

                licensePlate = Console.ReadLine();

                int invalidChar = 0;

                if (licensePlate.Length != 6)
                {
                    Console.WriteLine("Registreringskyllten måste innehålla 6 tecken!");
                }
                else
                {
                    for (int i = 0; i < 6; i++)
                    {
                        if (i < 3)
                        {
                            validPlate = ValidateChar(licensePlate, i);
                        }
                        else if (i < 5)
                        {
                            validPlate = ValidateInt(licensePlate, i);
                        }
                        else
                        {
                            validPlate = ValidateIntOrChar(licensePlate, i);
                        }

                        if (!validPlate)
                        {
                            invalidChar = i;
                            break;
                        }
                    }

                    if (validPlate)
                    {
                        Console.WriteLine($"{licensePlate} är en gilltig registreringskyllt!");

                    }
                    else
                    {
                        Console.WriteLine($"{licensePlate} är ej en gilltig registreringskyllt!");
                        for (int i = 0; i < invalidChar; i++)
                        {
                            Console.Write(" ");
                        }
                        Console.WriteLine("^ är ett felaktigt tecken");
                    }
                }
            }

        }

        private static bool ValidateIntOrChar(string licensePlate, int i)
        {
            string bannedCharacters = "iqvo";
            if (char.TryParse(licensePlate[i].ToString(), out _) && !bannedCharacters.Contains(licensePlate[i].ToString().ToLower()))
            {
                return true;
            }
            return false;
        }

        static bool ValidateChar(string licensePlate, int i)
        {
            string bannedCharacters = "iqv";
            if (!int.TryParse(licensePlate[i].ToString(), out _) && !bannedCharacters.Contains(licensePlate[i].ToString().ToLower()))
            {
                return true;
            }
            return false;
        }

        static bool ValidateInt(string licensePlate, int i)
        {
            if (int.TryParse(licensePlate[i].ToString(), out _))
            {
                return true;
            }
            return false;
        }
    }
}
