using static System.Console;
using Packt.CS7;

namespace Assemblies
{
    class Program
    {
        static void Main(string[] args)
        {
            Write("Enter a valid color value in hex: ");
            string hex = ReadLine();
            WriteLine($"Is {hex} a valid color value: {hex.IsValidHex()}");

            Write("Enter a valid XML tag: ");
            string xmlTag = ReadLine();
            WriteLine($"Is {xmlTag} a valid XML tag: {xmlTag.IsValidXmlTag()}");

            Write("Enter a valid password: ");
            string password = ReadLine();
            WriteLine($"Is {password} a valid password: {password.IsValidPassword()}");
        }
    }
}
