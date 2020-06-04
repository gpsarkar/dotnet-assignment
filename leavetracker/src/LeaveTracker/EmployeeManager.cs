using System;
using System.IO;

namespace LeaveTracker
{
    public class EmployeeManager
    {
        public Employee E { get; set; }

        public bool GetEmployeeFromCsv(int id)
        {
            using( var reader = File.OpenText("employee.csv"))
            {
                var entry = reader.ReadLine(); //skip first line as it is header
                entry = reader.ReadLine();
                while(entry != null)
                {
                    var employ = entry.Split(",");
                    if (int.Parse(employ[0]) == id )
                    {
                        E.ID = int.Parse(employ[0]);
                        E.Name = employ[1];
                        E.ManID = int.Parse(employ[2]);
                        return true;
                    }
                    entry = reader.ReadLine();
                }
                return false;
            }

        }

        public void AddEmployye()
        {
        }

        public void login()
        {
            while(true)
            {
                Console.WriteLine("Enter the Employee ID or q to quit: ");
                var input = Console.ReadLine();
                if (input == "q")
                {
                    Environment.Exit(0);
                }
                var id = int.Parse(input);
                if (GetEmployeeFromCsv(id))
                {
                    break;
                }
                Console.WriteLine("The ID is Invalid");
            }
        }
    }
}