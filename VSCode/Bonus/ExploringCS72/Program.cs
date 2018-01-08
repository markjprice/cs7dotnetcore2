using static System.Console;

namespace ExploringCS72
{
    class Program
    {
        static void Main(string[] args)
        {
            int year = 0b_0000_0111_1011_0100;
            WriteLine($"I was born in {year}.");

            PassingParameters(name: "Bob", 1945);
        }

        public void ReadFieldsInDerivedType()
        {
            WriteLine("Inside a type in different assembly:");
            var am = new AccessModifiers();
            WriteLine(am.Everywhere);
        }

        public static void PassingParameters(string name, int year)
        {
            WriteLine($"{name} was born in {year}.");
        }
    }
    
    public class DerivedInDifferentAssembly : AccessModifiers
    {
        public void ReadFieldsInDerivedType()
        {
            WriteLine("Inside a derived type in different assembly:");
            WriteLine(InDerivedType);
            WriteLine(InSameAssemblyOrDerivedType);
            WriteLine(Everywhere);
        }
    }

}
