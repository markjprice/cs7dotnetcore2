using static System.Console;

namespace ExploringCS72
{
    public class AccessModifiers
    {
        private int InTypeOnly;
        internal int InSameAssembly;
        protected int InDerivedType;
        internal protected int InSameAssemblyOrDerivedType;
        private protected int InSameAssemblyAndDerivedType; // C# 7.2
        public int Everywhere;

        public void ReadFields()
        {
            WriteLine("Inside the same type:");
            WriteLine(InTypeOnly);
            WriteLine(InSameAssembly);
            WriteLine(InDerivedType);
            WriteLine(InSameAssemblyOrDerivedType);
            WriteLine(InSameAssemblyAndDerivedType);
            WriteLine(Everywhere);
        }
    }

    public class DerivedInSameAssembly : AccessModifiers
    {
        public void ReadFieldsInDerivedType()
        {
            WriteLine("Inside a derived type in same assembly:");
            //WriteLine(InTypeOnly); // is not visible
            WriteLine(InSameAssembly);
            WriteLine(InDerivedType);
            WriteLine(InSameAssemblyOrDerivedType);
            WriteLine(InSameAssemblyAndDerivedType);
            WriteLine(Everywhere);
        }
    }
}