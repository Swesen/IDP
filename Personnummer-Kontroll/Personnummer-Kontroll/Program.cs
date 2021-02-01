using System;

namespace Personnummer_Kontroll
{
    class Program
    {
        static DateTime today = DateTime.Today;

        static void Main(string[] args)
        {
            while (true)
            {
                string input = InputPersonNumberScreen();

                // if input is empty quit program
                if (input == "")
                {
                    break;
                }

                bool personNumberIsValid = TryParsePersonNumber(input, out int year, out int month, out int day, out int birthNumber, out int controlDigit);

                string sex = "";
                if (personNumberIsValid)
                {
                    personNumberIsValid = VerifyPersonNumber(year, month, day, birthNumber, controlDigit, out sex);
                }

                if (personNumberIsValid)
                {
                    PrintValid(year, month, day, birthNumber, controlDigit, sex);
                }
                else
                {
                    PrintInvalid();
                }

                WriteLineCentered("Tryck på valfri tangent för att fortsätta...", 1);
                Console.ReadKey();
            }
        }

        static void PrintInvalid()
        {
            WriteLineCentered("****************************", 1);
            WriteLineCentered("* Personnummer ej giltigt! *");
            WriteLineCentered("****************************");
        }

        static void PrintValid(int year, int month, int day, int birthNumber, int controlDigit, string sex)
        {
            WriteLineCentered($"Personen är en {sex}, född År: {year}, Månad: {month:00}, Dag: {day:00}, Födelsenummer: {birthNumber:000}, Kontrollsiffra: {controlDigit}", 1);
        }

        /// <summary>
        /// Prints the input screen and reads the user input.
        /// </summary>
        /// <returns>User input.</returns>
        static string InputPersonNumberScreen()
        {
            Console.Clear();
            WriteLineCentered("###############################################################################", 5);
            WriteLineCentered("# Gilltiga inmatnings format:                                                 #");
            WriteLineCentered("#    Endast siffror: ÅÅÅÅMMDDNNNK                        T.ex: 195811253540   #");
            WriteLineCentered("#    Med skilljetecken: ÅÅMMDD-NNNC, ÅÅMMDD+NNNC         T.ex: 581125-3540    #");
            WriteLineCentered("#                                                                             #");
            WriteLineCentered("# Lämna fältet tomt och tryck enter för att avsluta.                          #");
            WriteLineCentered("#                                                                             #");
            WriteLineCentered("# Mata in ett perssonnummer för kontroll av giltighet:                        #");
            WriteLineCentered("###############################################################################");
            // Place cursor in position for input
            Console.SetCursorPosition((Console.WindowWidth / 2) + 15, Console.CursorTop - 2);
            string input = Console.ReadLine();
            Console.SetCursorPosition(0, Console.CursorTop + 2);
            return input;
        }

        static void WriteLineCentered(string s)
        {
            Console.CursorLeft = (Console.WindowWidth - s.Length) / 2;
            Console.WriteLine(s);
        }

        static void WriteLineCentered(string s, int emptyLinesAbove)
        {
            Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop + emptyLinesAbove);
            Console.WriteLine(s);
        }

        /// <returns>Returns true and the sex if verification was successfull.</returns>
        static bool VerifyPersonNumber(int year, int month, int day, int birthNumber, int controlDigit, out string sex)
        {
            bool valid = true;
            int verificationStep = 0;

            sex = "";

            while (valid)
            {
                switch (verificationStep)
                {
                    case 0:
                        valid = VerifyYear(year);
                        break;
                    case 1:
                        valid = VerifyMonth(month);
                        break;
                    case 2:
                        valid = VerifyDay(day, month, year);
                        break;
                    case 3:
                        valid = VerifyBirthNumber(birthNumber, out sex);
                        break;
                    case 4:
                        valid = VerifyControlDigit(year, month, day, birthNumber, controlDigit);
                        break;
                    default:
                        return valid;
                }
                verificationStep++;
            }

            return valid;
        }

        /// <summary>
        /// Tries to parse input string as a person number into the components of a person number.
        /// Valid input is in the format: YYYYMMDDNNNC, YYYYMMDD-NNNC, YYYYMMDD+NNNC, YYMMDD-NNNC or YYMMDD+NNNC.
        /// </summary>
        /// <returns>True and the parsed numbers if parsing is successfull.</returns>
        static bool TryParsePersonNumber(string input, out int year, out int month, out int day, out int birthNumber, out int controlDigit)
        {
            if (input.Length == 12)
            {
                // Input of 12 characters should only contain numbers, any exception makes the input invalid.
                try
                {
                    year = int.Parse(input.Substring(0, 4));
                    month = int.Parse(input.Substring(4, 2));
                    day = int.Parse(input.Substring(6, 2));
                    birthNumber = int.Parse(input.Substring(8, 3));
                    controlDigit = int.Parse(input.Substring(11, 1));
                    return true;
                }
                catch (Exception)
                {
                    WriteLineCentered("Det inmatade personnumret innehåller otillåtet tecken!");
                    WriteLineCentered("Vid inmatning av 12 tecken får personnumret endast innehålla siffror.");
                }
            }
            else if ((input.Length == 11 || input.Length == 13) && (input.Contains('+') || input.Contains('-')))
            {
                // Determin if the input has years with 2 or 4 digits.
                int yearLength = 2;
                if (input.Length == 13)
                {
                    yearLength = 4;
                }

                int currentYear = today.Year;
                int currentCentury = currentYear - (currentYear % 100);
                // Short year is the last two digits in the year
                int currentShortYear = (currentYear % 100);

                try
                {
                    year = int.Parse(input.Substring(0, yearLength));

                    // This part checks that the separation sign is correct, and if the year was input as 4 digits it checks that it matches the seperation sign.
                    if (input.Substring(yearLength + 4, 1) == "+" && (currentYear - year >= 100 || year < 100))
                    {
                        // Determine if year needs to be modified for the verification
                        if (year >= 1753)
                        {
                            // Don't modify year
                        }
                        else if (year > currentShortYear)
                        {
                            year += currentCentury - 200;
                        }
                        else
                        {
                            year += currentCentury - 100;
                        }
                    }
                    else if (input.Substring(yearLength + 4, 1) == "-" && (currentYear - year < 100 || year < 100))
                    {
                        // Determine if year needs to be modified for the verification
                        if (year >= 1753)
                        {
                            // Don't modify year
                        }
                        else if (year > currentShortYear)
                        {
                            year += currentCentury - 100;
                        }
                        else
                        {
                            year += currentCentury;
                        }
                    }
                    else
                    {
                        WriteLineCentered("Skiljetecken ej korrekt!");
                        throw new Exception();
                    }

                    // Yf year was parsed correctly it should be more than 2 digits long and the rest tries to parse the numbers.
                    if (year > 100)
                    {
                        month = int.Parse(input.Substring(yearLength, 2));
                        day = int.Parse(input.Substring(yearLength + 2, 2));
                        birthNumber = int.Parse(input.Substring(yearLength + 5, 3));
                        controlDigit = int.Parse(input.Substring(yearLength + 8, 1));
                        return true;
                    }
                }
                catch (Exception)
                {
                    WriteLineCentered("Det inmatade personnumret är ej i korrekt format eller innehåller otillåtet tecken!");
                }

            }
            else
            {
                WriteLineCentered("Det inmatade personnumret innehåller fel antal tecken!");
            }

            year = -1;
            month = -1;
            day = -1;
            birthNumber = -1;
            controlDigit = -1;
            return false;
        }

        /// <returns>True if year is in a valid range.</returns>
        static bool VerifyYear(int year)
        {
            if (year <= today.Year && year >= 1753)
            {
                return true;
            }

            WriteLineCentered($"År {year} är utanför gilltigt spann! 1752-{today.Year}.");
            return false;
        }

        /// <returns>True if month is in a valid range.</returns>
        static bool VerifyMonth(int month)
        {
            if (month <= 12 && month >= 1)
            {
                return true;
            }

            WriteLineCentered($"{month:00} är ej en gilltig månad!");
            return false;
        }


        /// <returns>True if day is valid for that month and year.</returns>
        static bool VerifyDay(int day, int month, int year)
        {
            // check if day is in a valid range
            if (day >= 1 && day <= 31)
            {
                if (day <= 28)
                {
                    // day 28 or less is always valid
                    return true;
                }
                else if (month == 2 && day == 29)
                {
                    // if month is fabuary and day is 29 check that it is a leap year
                    if (year % 400 == 0)
                    {
                        return true;
                    }
                    else if (year % 100 == 0)
                    {
                    }
                    else if (year % 4 == 0)
                    {
                        return true;
                    }

                    WriteLineCentered($"År {year} är ej ett skottår, så dag {day:00} i månad {month:00} är ej gilltig!");
                    return false;
                }
                else if (month != 2 && day <= 30)
                {
                    // if not febuary and days is 30 or less
                    return true;
                }
                else if ((month <= 7 && month % 2 != 0) || (month >= 8 && month % 2 == 0))
                {
                    // if month is a month with 31 days
                    return true;
                }

                WriteLineCentered($"Dag {day:00} är ej gilltig för månad {month:00}!");
            }
            else
            {
                WriteLineCentered($"Dag {day:00} är utanför gilltigt spann!");
            }

            return false;
        }


        /// <returns>True if birthNumber is valid and the sex of the person.</returns>
        static bool VerifyBirthNumber(int birthNumber, out string sex)
        {
            if (birthNumber >= 0 && birthNumber <= 999)
            {
                if (birthNumber % 2 == 0)
                {
                    sex = "Kvinna";
                }
                else
                {
                    sex = "Man";
                }
                return true;
            }

            WriteLineCentered($"Jag vet inte hur du lyckades men {birthNumber:000} är utanför gilltigt spann!");
            sex = "";
            return false;
        }

        /// <returns>True if the controlDigit is valid</returns>
        static bool VerifyControlDigit(int year, int month, int day, int birthNumber, int controlDigit)
        {
            string personNumber = $"{year}{month:00}{day:00}{birthNumber:000}";
            personNumber = personNumber.Remove(0, 2);

            int controlResult = 0;
            // The Luhn-algorithm
            for (int i = 0; i < personNumber.Length; i++)
            {
                int result = int.Parse(personNumber[i].ToString());
                if (i % 2 == 0)
                {
                    result *= 2;
                    if (result >= 10)
                    {
                        controlResult += result % 10 + 1;
                    }
                    else
                    {
                        controlResult += result;
                    }
                }
                else
                {
                    controlResult += result;
                }
            }

            controlResult = (10 - (controlResult % 10)) % 10;

            if (controlResult == controlDigit)
            {
                return true;
            }
            else
            {
                WriteLineCentered($"Kontrollsiffra {controlDigit} matchar inte uträknad kontrollsiffra {controlResult}!");
                return false;
            }
        }
    }
}
