using Packt.CS7;
using static System.Console;
using System;

namespace PeopleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var p1 = new Person();
            p1.Name = "Bob Smith";
            p1.DateOfBirth = new DateTime(1965, 12, 22);
            WriteLine($"{p1.Name} was born on {p1.DateOfBirth:dddd, d MMMM  yyyy}");

            var p2 = new Person
            {
                Name = "Alice Jones",
                DateOfBirth = new DateTime(1998, 3, 17)
            };
            WriteLine($"{p2.Name} was born on {p2.DateOfBirth:d MMM yy}");

            p1.FavouriteAncientWonder = WondersOfTheAncientWorld.StatueOfZeusAtOlympia;
            WriteLine($"{p1.Name}'s favourite wonder is {p1.FavouriteAncientWonder}");

            p1.BucketList = WondersOfTheAncientWorld.HangingGardensOfBabylon |
                WondersOfTheAncientWorld.MausoleumAtHalicarnassus;
            // p1.BucketList = (WondersOfTheAncientWorld)18; 
            WriteLine($"{p1.Name}'s bucket list is {p1.BucketList}");

            p1.Children.Add(new Person { Name = "Alfred" });
            p1.Children.Add(new Person { Name = "Zoe" });
            WriteLine($"{p1.Name} has {p1.Children.Count} children:");
            for (int child = 0; child < p1.Children.Count; child++)
            {
                WriteLine($"  {p1.Children[child].Name}");
            }

            BankAccount.InterestRate = 0.012M;
            var ba1 = new BankAccount();
            ba1.AccountName = "Mrs. Jones";
            ba1.Balance = 2400;
            WriteLine($"{ba1.AccountName} earned {ba1.Balance * BankAccount.InterestRate:C} interest.");
            var ba2 = new BankAccount();
            ba2.AccountName = "Ms. Gerrier";
            ba2.Balance = 98;
            WriteLine($"{ba2.AccountName} earned {ba2.Balance * BankAccount.InterestRate:C} interest.");

            Tuple<string, int> fruit4 = p1.GetFruitCS4();
            WriteLine($"There are {fruit4.Item2} {fruit4.Item1}.");

            var fruit7 = p1.GetFruitCS7();
            WriteLine($"{fruit7.Name}, {fruit7.Number} there are.");


            var thing1 = ("Neville", 4);
            WriteLine($"{thing1.Item1} has {thing1.Item2} children.");

            var thing2 = (p1.Name, p1.Children.Count);
            WriteLine($"{thing2.Name} has {thing2.Count} children.");

            (string fruitName, int fruitNumber) = p1.GetFruitCS7();
            WriteLine($"Deconstructed: {fruitName}, {fruitNumber}");

            WriteLine(p1.SayHello());
            WriteLine(p1.SayHello("Emily"));

            WriteLine(p1.OptionalParameters());
        }
    }
}