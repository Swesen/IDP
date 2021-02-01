using System;

namespace Övning_0_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int speed;
            do
            {
                Console.Write("Mata in hastigheten du kör i: ");
            } while (!int.TryParse(Console.ReadLine(), out speed));

            Console.WriteLine(SimpleSpeedComparison(speed));
        }

        static string SimpleSpeedComparison(int speed)
        {
            int ticketAmount;
            string additionalMessage = "";

            if (speed <= 30)
            {
                return "Du kör lagligt!";
            }
            else if (speed <= 40)
            {
                ticketAmount = 2000;
            }
            else if (speed <= 50)
            {
                ticketAmount = 3000;
            }
            else
            {
                ticketAmount = 5000;
                additionalMessage = " Dessutom blir du av med körkortet!";
            }

            return $"Du har kört för fort och får böta {ticketAmount}SEK!{additionalMessage}";
        }

        static string NestedSpeedComparison(int speed)
        {

            if (speed > 30)
            {
                int ticketAmount;
                string additionalMessage = "";

                if (speed <= 40)
                {
                    ticketAmount = 2000;
                }
                else if (speed <= 50)
                {
                    ticketAmount = 3000;
                }
                else
                {
                    ticketAmount = 5000;
                    additionalMessage = " Dessutom blir du av med körkortet!";
                }

                return $"Du har kört för fort och får böta {ticketAmount}SEK!{additionalMessage}";
            }
            else
            {
                return "Du kör lagligt!";
            }
        }

        static string ComplexSpeedComparison(int speed)
        {
            int ticketAmount = 0;
            string additionalMessage = "";

            if (speed >= 0 && speed <= 30)
            {
                return "Du kör lagligt!";
            }

            if (speed > 30 && speed <= 40)
            {
                ticketAmount = 2000;
            }
            else if (speed > 40 && speed <= 50)
            {
                ticketAmount = 3000;
            }
            else if (speed > 50)
            {
                ticketAmount = 5000;
                additionalMessage = " Dessutom blir du av med körkortet!";
            }

            return $"Du har kört för fort och får böta {ticketAmount}SEK!{additionalMessage}";
        }

        static string LicenceRevocationLength(int speed, int speedLimit)
        {
            int overSpeedLimit = speed - speedLimit;

            if (overSpeedLimit >= 16)
            {
                int monthsRevoked;

                if (overSpeedLimit <= 20)
                {
                    monthsRevoked = 1;
                }
                else if (overSpeedLimit <= 30)
                {
                    monthsRevoked = 2;
                }
                else if (overSpeedLimit <= 40)
                {
                    monthsRevoked = 3;
                }
                else if (overSpeedLimit <= 50)
                {
                    monthsRevoked = 4;
                }
                else if (overSpeedLimit <= 60)
                {
                    monthsRevoked = 5;
                }
                else if (overSpeedLimit <= 70)
                {
                    monthsRevoked = 6;
                }
                else
                {
                    monthsRevoked = int.MaxValue;
                }
                return $"Du har kört för fort! Ditt körkort blir indraget i {monthsRevoked} månader!";
            }
            else
            {
                return "Du får behålla ditt körkort!";
            }
        }
    }
}
