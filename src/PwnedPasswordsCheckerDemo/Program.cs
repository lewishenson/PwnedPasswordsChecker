using System;
using System.Threading.Tasks;

namespace PwnedPasswordsChecker.Demo
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("============================");
            Console.WriteLine("Pwned Passwords Checker Demo");
            Console.WriteLine("============================");

            Console.WriteLine("Enter the password to check:");

            var password = Console.ReadLine();

            var pwnedPasswords = new PwnedPasswords();

            var count = await pwnedPasswords.PwnedCountAsync(password);
            var isPwned = count > 0;

            if (isPwned)
            {
                Console.WriteLine($"Oh no — pwned! This password has been seen {count} times before.");
            }
            else
            {
                Console.WriteLine("Good news — no pwnage found!");
            }
        }
    }
}