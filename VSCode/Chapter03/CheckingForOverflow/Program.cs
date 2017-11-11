using System;
using static System.Console;

namespace CheckingForOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                checked
                {
                    int x = int.MaxValue - 1;
                    WriteLine(x);
                    x++;
                    WriteLine(x);
                    x++;
                    WriteLine(x);
                    x++;
                    WriteLine(x);
                }
            }
            catch (OverflowException)
            {
                WriteLine("The code overflowed but I caught the exception.");
            }

            unchecked
            {
                int y = int.MaxValue + 1;
                WriteLine(y); // this will output -2147483648
                y--;
                WriteLine(y); // this will output 2147483647
                y--;
                WriteLine(y); // this will output 2147483646
            }
        }
    }
}
