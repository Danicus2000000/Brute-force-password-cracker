using System;
using System.Diagnostics;
using System.IO;
namespace Brute_force_passowrd_checker
{
    class Program
    {
        public static char[] characters=new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',' ', '!', '\"', '#', '$', '%', '&', '\'', '(', ')', '*', '+', ',', '-', '.', '/', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ':', ';', '<', '=', '>', '?', '@', '[', '\\', ']', '^', '_', '`', '{', '|', '}', '~' };
        public static int passwordLength = 6;
        public static long tries = 0;
        public static bool done = false;
        public static string password = "hey";
        public static void CreatePasswords(string keys)
        {
            if (keys == password)
            {
                done = true;
            }
            if (keys.Length == passwordLength || done == true)
            {
                return;
            }
            for (char c = characters[0]; c <= characters[characters.Length-1]; c++)
            {
                if (done != true)
                {
                    tries++;
                    Console.WriteLine(keys + c);
                    CreatePasswords(keys + c);
                }
            }
        }
        static void Main(string[] args)
        {

            while (true)
            {
                tries = 0;
                done = false;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Welcome to the Password brute forcer!");
                Console.Write("This program was built by ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Danny Boi");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(".");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("\nPlease enter your password > ");
                password = Convert.ToString(Console.ReadLine()).ToLower();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\nCracking your password...");
                Stopwatch timer = Stopwatch.StartNew();
                passwordLength = password.Length;
                CreatePasswords(string.Empty);
                timer.Stop();
                long elapsedMs = timer.ElapsedMilliseconds;
                double elapsedTime = elapsedMs / 1000;
                if (elapsedTime > 0)
                {
                    Console.WriteLine("\n\nYour password has been found! Here are the statistics:");
                    Console.WriteLine(")----------------------------------------------------(");
                    Console.WriteLine("Password: {0}",password);
                    Console.WriteLine("Password length: {0}", passwordLength);
                    Console.WriteLine("Tries: {0}", tries);
                    string plural = "seconds";
                    if (elapsedTime == 1)
                    {
                        plural = "second";
                    }
                    Console.WriteLine("Time to crack: {0} {1}", elapsedTime, plural);
                    Console.WriteLine("Passwords per second: {0}", (long)(tries / elapsedTime));
                }
                else
                {
                    Console.WriteLine("\n\nYour password has been found! Here are the statistics:");
                    Console.WriteLine(")----------------------------------------------------(");
                    Console.WriteLine("Password: {0}",password);
                    Console.WriteLine("Password length: {0}",passwordLength);
                    Console.WriteLine("Tries: {0}",tries);
                    Console.WriteLine("Time to crack: {0} seconds", elapsedTime);
                }
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("\n\nWould you like to go again? (y/n) ");
                string result = Console.ReadLine();
                result = result.ToUpper();
                if (result=="N" || result=="NO" || result=="NAH" || result=="NOPE")
                {
                    break;
                }
            }

        }
    }
}
