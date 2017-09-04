using System;
using System.Collections.Generic;

namespace Packt.CS7
{
    public class Person : object
    {
        // fields
        public string Name;
        public DateTime DateOfBirth;
        public WondersOfTheAncientWorld FavouriteAncientWonder;
        public WondersOfTheAncientWorld BucketList;
        public List<Person> Children = new List<Person>();

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
    }
}