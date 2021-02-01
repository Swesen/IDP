using System;

namespace Bankkonto_Uppgift
{
    class Program
    {
        static BankAccount bankAccount = new BankAccount();

        static void Main(string[] args)
        {
            bankAccount.CreateNewAccount("Test", "test", 1234);

            while (true)
            {
                bool loggedIn = LoginScreen();

                while (loggedIn)
                {
                    string input = BankAccountScreen();

                    switch (input.ToLower())
                    {
                        case "logga ut":
                            loggedIn = bankAccount.LockAccount();
                            break;

                        case "sätt in":
                        case "sätt in pengar":
                            Deposit();
                            break;

                        case "ta ut":
                        case "ta ut pengar":
                            Withdraw();
                            break;

                        case "saldo":
                        case "visa saldo":
                            ShowBalance();
                            break;

                        default:
                            break;
                    }
                }
            }

        }

        static void ShowBalance()
        {
            Console.WriteLine($"Bankkonto {bankAccount.accountNumber} har saldot {bankAccount.GetBalance():0.##}kr");
            Console.Write("Tryck på valfri knapp för att fortsätta");
            Console.ReadKey();
        }

        static void Withdraw()
        {
            Console.WriteLine($"Det finns {bankAccount.GetBalance():0.##}kr tillgängligt hur mycket vill du ta ut?");
            decimal.TryParse(Console.ReadLine(), out decimal result);
            bool successfull = bankAccount.Withdraw(result);
            if (successfull)
            {
                Console.WriteLine("Uttaget lyckades!");
                Console.WriteLine($"Det finns nu {bankAccount.GetBalance():0.##} på konto {bankAccount.accountNumber}.");
                Console.ReadKey();
            }
        }

        static void Deposit()
        {
            Console.WriteLine($"Hur mycket vill du sätta in?");
            decimal.TryParse(Console.ReadLine(), out decimal result);
            bool successfull = bankAccount.Deposit(result);
            if (successfull)
            {
                Console.WriteLine("Insättningen lyckades!");
                Console.WriteLine($"Det finns nu {bankAccount.GetBalance():0.##} på konto {bankAccount.accountNumber}.");
                Console.ReadKey(); 
            }
        }

        static string BankAccountScreen()
        {
            Console.Clear();
            Console.WriteLine("¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤");
            Console.WriteLine("¤ Inloggad på bankkonto med nummer: {0}                   ¤", bankAccount.accountNumber);
            Console.WriteLine("¤ ============================================================ ¤");
            Console.WriteLine("¤ Välj åtgärd:                                                 ¤");
            Console.WriteLine("¤ ============================================================ ¤");
            Console.WriteLine("¤ Tillgängliga tjänster:                                       ¤");
            Console.WriteLine("¤ > Visa 'saldo'                                               ¤");
            Console.WriteLine("¤ > 'Sätt in' pengar                                           ¤");
            Console.WriteLine("¤ > 'Tag ut' pengar                                            ¤");
            Console.WriteLine("¤ > Logga ut                                                   ¤");
            Console.WriteLine("¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤");
            Console.SetCursorPosition(15, 3);
            string input = Console.ReadLine();

            Console.SetCursorPosition(0, 12);
            return input;
        }

        static bool LoginScreen()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("################################################################");
            Console.WriteLine("# Skriv in din information för att logga in på ditt bankkonto. #");
            Console.WriteLine("# Namn:                                    <Förnamn Efternamn> #");
            Console.WriteLine("# Adress:                                  <Gatuadress nummer> #");
            Console.WriteLine("# Telefonnummer:                               <TelefonNummer> #");
            Console.WriteLine("################################################################");

            Console.SetCursorPosition(8, 2);
            string name = Console.ReadLine();

            Console.SetCursorPosition(10, 3);
            string address = Console.ReadLine();

            Console.SetCursorPosition(17, 4);
            int.TryParse(Console.ReadLine(), out int telephoneNumber);

            if (bankAccount.Verify(name, address, telephoneNumber))
            {
                return true;
            }
            
            Console.SetCursorPosition(0, 6);
            Console.WriteLine("Inloggning misslyckades!");
            return false;
        }
    }

    public class BankAccount
    {
        public int accountNumber;

        string name;
        string address;
        int telephoneNumber;
        bool unlocked;
        decimal balance;

        public void CreateNewAccount(string _name, string _address, int _telephoneNumber)
        {
            name = _name;
            address = _address;
            telephoneNumber = _telephoneNumber;


            accountNumber = GenerateRandomNumberOfLength(8);
        }

        public bool Verify(string _name, string _address, int _telephoneNumber)
        {
            bool valid = false;

            valid = name.ToLower() == _name.ToLower();

            if (valid)
            {
                valid = address.ToLower() == _address.ToLower();
            }

            if (valid)
            {
                valid = telephoneNumber == _telephoneNumber;
            }

            unlocked = valid;
            return valid;
        }

        public bool Deposit(decimal deposit)
        {
            if (deposit > 0)
            {
                balance += deposit;
                return true;
            }
            return false;
        }

        public bool Withdraw(decimal withdraw)
        {
            if (unlocked && withdraw > 0)
            {
                balance -= withdraw;
            }
            
            return false;
        }

        public decimal GetBalance()
        {
            if (unlocked)
            {
                return balance;
            }
            return decimal.MinValue;
        }

        public bool LockAccount()
        {
            unlocked = false;
            return unlocked;
        }

        private int GenerateRandomNumberOfLength(int length)
        {
            int number = 0;
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                number *= 10;
                number += random.Next(0, 10);
            }

            return number;
        }
    }
}
