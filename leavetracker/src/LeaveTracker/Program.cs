using System;

namespace LeaveTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            var emp = new EmployeeManager();
            emp.login();
            while (true)
            {
                PrintMenu();
                var input = Console.ReadLine();
                switch(input)
                {
                    case "1":
                        //Createleave
                        break;
                    case "2":
                        //List leave
                        break;
                    case "3":
                        //update leave
                        break;
                    case "4":
                        //search leave
                        break;
                    case "5":
                        //exit
                        break;
                    default:
                        break;
                }
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("1. Create Leave");
            Console.WriteLine("2. List My Leaves");
            Console.WriteLine("3. Update Leaves");
            Console.WriteLine("4. Search Leaves");
            Console.WriteLine("5. Logout");
        }

        private static void SearchMenu()
        {
            Console.WriteLine("1. Search By Title");
            Console.WriteLine("2. Search By Status");
            Console.WriteLine("3. Back To Main Menu");
        }
    }
}
