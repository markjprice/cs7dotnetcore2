using System.Diagnostics;
using static System.Console;

namespace WritingFunctions
{
    class Program
    {
        static void TimesTable(byte number)
        {
            WriteLine($"The {number} Times Table");
            for (int row = 1; row <= 12; row++)
            {
                WriteLine($"{row} x {number} = {row * number}");
            }
        }

        static void RunTimesTable()
        {
            Write("Enter a number between 0 and 255: ");
            if (byte.TryParse(ReadLine(), out byte number))
            {
                TimesTable(number);
            }
            else
            {
                WriteLine("You did not enter a valid number!");
            }
        }

        static decimal SalesTax(decimal amount, string region)
        {
            decimal rate = 0.0M;

            switch (region)
            {
                case "Switzerland":
                    rate = 0.08M;
                    break;
                case "Denmark":
                case "Norway":
                    rate = 0.25M;
                    break;
                case "UK":
                case "France":
                    rate = 0.2M;
                    break;
                case "Hungary":
                    rate = 0.27M;
                    break;
                case "OR":
                case "AK":
                case "MT":
                    rate = 0.0M;
                    break;
                case "ND":
                case "WI":
                case "ME":
                case "VA":
                    rate = 0.05M;
                    break;
                case "CA":
                    rate = 0.0825M;
                    break;
                default:
                    rate = 0.06M;
                    break;
            }

            return amount * rate;
        }

        static void RunSalesTax()
        {
            Write("Enter an amount: ");
            string amountInText = ReadLine();
            Write("Enter a country or US state: ");
            string region = ReadLine();
            decimal taxToPay = SalesTax(decimal.Parse(amountInText), region);
            WriteLine($"You must pay {taxToPay}");
        }

        static string CardinalToOrdinal(int number)
        {
            switch (number)
            {
                case 11:
                case 12:
                case 13:
                    return $"{number}th";
                default:
                    string numberAsText = number.ToString();
                    int lastDigit = int.Parse(
                      numberAsText[numberAsText.Length - 1]
                      .ToString());
                    string suffix = string.Empty;
                    switch (lastDigit)
                    {
                        case 1:
                            suffix = "st";
                            break;
                        case 2:
                            suffix = "nd";
                            break;
                        case 3:
                            suffix = "rd";
                            break;
                        default:
                            suffix = "th";
                            break;
                    }
                    return $"{number}{suffix}";
            }
        }

        static void RunCardinalToOrdinal()
        {
            for (int number = 1; number <= 40; number++)
            {
                Write($"{CardinalToOrdinal(number)} ");
            }
        }

        static int Factorial(int number)
        {
            if (number < 1)
            {
                return 0;
            }
            else if (number == 1)
            {
                return 1;
            }
            else
            {
                return number * Factorial(number - 1);
            }
        }

        static void RunFactorial()
        {
            Write("Enter a number: ");
            if (int.TryParse(ReadLine(), out int number))

            {
                WriteLine(
                  $"{number:N0}! = {Factorial(number):N0}");
            }
            else
            {
                WriteLine("You did not enter a valid number!");
            }
        }

        static void Main(string[] args)
        {
            // RunTimesTable();

            // RunSalesTax();

            // RunCardinalToOrdinal();

            RunFactorial();
        }
    }
}
