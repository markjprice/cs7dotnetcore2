using System;
using Packt.CS7;
using static System.Console;

namespace HashingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("A user named Alice has been registered with Pa$$w0rd as her password."); 
        
            var alice = Protector.Register("Alice", "Pa$$w0rd");
            WriteLine($"Name: {alice.Name}");
            WriteLine($"Salt: {alice.Salt}");
            WriteLine(
              $"Salted and hashed password: {alice.SaltedHashedPassword}");
            WriteLine();
            Write("Enter a different username to register: ");
            string username = ReadLine();
            Write("Enter a password to register: ");
            string password = ReadLine();
            var user = Protector.Register(username, password);
            WriteLine($"Name: {user.Name}");
            WriteLine($"Salt: {user.Salt}");
            WriteLine(
              $"Salted and hashed password: {user.SaltedHashedPassword}");

            bool correctPassword = false;
            while (!correctPassword)
            {
                Write("Enter a username to log in: ");
                string loginUsername = ReadLine();
                Write("Enter a password to log in: ");
                string loginPassword = ReadLine();
                correctPassword = Protector.CheckPassword(
                  loginUsername, loginPassword);
                if (correctPassword)
                {
                    WriteLine(
                      $"Correct! {loginUsername} has been logged in.");
                }
                else
                {
                    WriteLine("Invalid username or password. Try again.");
                }
            }
        }
    }
}
