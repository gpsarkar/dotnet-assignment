using System;
using System.IO;

namespace LeaveTracker
{
    public class Leave
    {
        public int ID { get; set; }
        public string Creator { get; set; }
        public string Manager { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public LeaveStatus Status { get; set; }

        public bool AddLeave(Employee e)
        {
            using (var writter = File.AppendText($"Leave.csv"))
            return true;
        }

        public void EditLeaveStatus()
        {
            if(!CheckLeaveCsv())
            {
                using(var f = File.Create("Leave.csv"))
                {
                }
            }
        }

        private bool CheckLeaveCsv()
        {
            return File.Exists("Leave.csv");
        }
    }
}