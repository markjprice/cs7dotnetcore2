using System;
using static System.Console;
using Packt.CS7;
using System.Security.Principal;
using System.Threading;
using System.Security.Claims;
using System.Security;

namespace SecureApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Protector.RegisterSomeUsers();

            Write($"Enter your user name: ");
            string username = ReadLine();
            Write($"Enter your password: ");
            string password = ReadLine();
            Protector.LogIn(username, password);
            if (Thread.CurrentPrincipal == null)
            {
                WriteLine("Log in failed.");
                return;
            }

            var p = Thread.CurrentPrincipal;
            WriteLine($"IsAuthenticated: {p.Identity.IsAuthenticated}");
            WriteLine($"AuthenticationType: {p.Identity.AuthenticationType}");
            WriteLine($"Name: {p.Identity.Name}");
            WriteLine($"IsInRole(\"Admins\"): {p.IsInRole("Admins")}");
            WriteLine($"IsInRole(\"Sales\"): {p.IsInRole("Sales")}");

            if (p is ClaimsPrincipal)
            {
                WriteLine($"{p.Identity.Name} has the following claims:");
                foreach (Claim claim in (p as ClaimsPrincipal).Claims)
                {
                    WriteLine($"  {claim.Type}: {claim.Value}");
                }
            }

            try
            {
                SecureFeature();
            }
            catch (Exception ex)
            {
                WriteLine($"{ex.GetType()}: {ex.Message}");
            }
        }

        static void SecureFeature()
        {
            if (Thread.CurrentPrincipal == null)
            {
                throw new SecurityException("Thread.CurrentPrincipal cannot be null.");
            }

            if (!Thread.CurrentPrincipal.IsInRole("Admins"))
            {
                throw new SecurityException("User must be a member of Admins to access this feature.");
            }

            WriteLine("You have access to this secure feature.");
        }
    }
}
