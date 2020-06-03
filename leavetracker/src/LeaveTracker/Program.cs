using System;

namespace LeaveTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            login();
            while (true)
            {
                PrintMenu();
                var input = Console.ReadLine();
            }
        }

        private static void login()
        {
           Console.WriteLine("Enter the Employee ID: ")
        }

        private static void PrintMenu()
        {
            Console.WriteLine("1. ");
        }
    }
}
