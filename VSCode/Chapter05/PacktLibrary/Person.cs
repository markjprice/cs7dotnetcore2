using System;
using System.Collections.Generic;
using static System.Console;

namespace Packt.CS7
{
    public partial class Person : object
    {
        // fields
        public string Name;
        public DateTime DateOfBirth;
        public WondersOfTheAncientWorld FavouriteAncientWonder;
        public WondersOfTheAncientWorld BucketList;
        public List<Person> Children = new List<Person>();

        // constants
        public const string Species = "Homo Sapien";

        // read-only fields
        public readonly string HomePlanet = "Earth";
        public readonly DateTime Instantiated;

        // constructors
        public Person()
        {
            // set default values for fields
            // including read-only fields
            Name = "Unknown";
            Instantiated = DateTime.Now;
        }

        public Person(string initialName)
        {
            Name = initialName;
            Instantiated = DateTime.Now;
        }

        // methods
        public void WriteToConsole()
        {
            WriteLine($"{Name} was born on {DateOfBirth:dddd, d MMMM yyyy}");
        }

        public string GetOrigin()
        {
            return $"{Name} was born on {HomePlanet}";
        }

        // the old C# 4 and .NET 4.0 System.Tuple type 
        public Tuple<string, int> GetFruitCS4()
        {
            return Tuple.Create("Apples", 5);
        }

        // the new C# 7 syntax and new System.ValueTuple type 
        public (string Name, int Number) GetFruitCS7()
        {
            return (Name: "Apples", Number: 5);
        }

        public string SayHello()
        {
            return $"{Name} says 'Hello!'";
        }

        public string SayHello(string name)
        {
            return $"{Name} says 'Hello {name}!'";
        }

        public string OptionalParameters(string command = "Run!", double number = 0.0, bool active = true)
        {
            return $"command is {command}, number is {number}, active is {active}";
        }

        public void PassingParameters(int x, ref int y, out int z)
        {
            // out parameters cannot have a default
            // AND must be initialized inside the method
            z = 99;
            // increment each parameter
            x++;
            y++;
            z++;
        }
    }
}