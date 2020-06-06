using System;
using System.IO;

namespace LeaveTracker
{
    public class LeaveManager
    {
        public void AddLeave(Employee e)
        {
            var L = GetLeaveObjectFromUser(e);
            AddLeaveToCSV(L);
        }

        internal void ListLeave(Employee e)
        {
            int count = 0;
            using (var reader = File.OpenText($"Leave.csv"))
            {
                Console.WriteLine("ID, Creator, Manager, Title, Description, Start-Date, End-Date, Status");
                var line = reader.ReadLine();
                while( line != null)
                {
                    if (e.ID == int.Parse(line.Split(",")[0]))
                    {
                        Console.WriteLine(line);
                        count++;
                    }
                    line = reader.ReadLine();
                }
                if(count == 0)
                {
                    Console.WriteLine("No entry Found for the current user");
                }
            }
        }

        public void EditLeaveStatus(Employee e)
        {
            if(!CheckLeaveCsvFile())
            {
                using(var f = File.Create("Leave.csv"))
                {
                }
            }
        }

        internal void SearchLeaveByTitle(Employee e)
        {
            throw new NotImplementedException();
        }

        internal void SearchLeaveByStatus(Employee e)
        {
            throw new NotImplementedException();
        }

        private bool CheckLeaveCsvFile()
        {
            return File.Exists("Leave.csv");
        }

        public bool AddLeaveToCSV(Leave l)
        {
            using (var writter = File.AppendText($"Leave.csv"))
            {
                writter.WriteLine(l.ToString());
            }
            return true;
        }

        public Leave GetLeaveObjectFromUser(Employee e)
        {
            var l = new Leave();
            l.ID = e.ID;
            l.Creator = e.Name;
            l.Manager = EmployeeManager.GetEmployeeFromCsv(e.ManID).Name;
            Console.WriteLine("Enter the title for the Leave: ");
            l.Title = Console.ReadLine();
            Console.WriteLine("Enter Description For the Leave: ");
            l.Description = Console.ReadLine();
            Console.WriteLine("Enter Start Date (DD-MM-YYYY): ");
            l.StartDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter End Date (DD-MM-YYYY): ");
            l.EndDate = DateTime.Parse(Console.ReadLine());
            l.Status = LeaveStatus.Pending ;
            return l;
        }

        public Leave getLeaveObjectFromString(string line)
        {
            var l = new Leave();
            var fields = line.Split(",");
            l.ID = int.Parse(fields[0]);
            l.Creator = fields[1];
            l.Manager = fields[2];
            l.Title = fields[3];
            l.Description = fields[4];
            l.StartDate = DateTime.Parse(fields[5]);
            l.EndDate = DateTime.Parse(fields[6]);
            l.Status = (LeaveStatus)Enum.Parse(typeof(LeaveStatus), fields[7], true);
            return l;
        }
    }
}