using System;
using System.Linq;

namespace LinqWithObjects
{
    class Program
    {
        static void LinqWithArrayOfStrings()
        {
            var names = new string[] { "Michael", "Pam", "Jim",
                "Dwight", "Angela", "Kevin", "Toby", "Creed" };
            var query = names.Where(new Func<string, bool>())
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}