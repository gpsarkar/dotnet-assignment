using System;
using System.IO;

namespace LeaveTracker
{
    public class LeaveManager
    {
        public void AddLeave(Employee e)
        {
            var L = new Leave();
            L.GetDataFromUser(e);
            AddLeaveToCSV(L);
        }

        internal void ListLeave(Employee e)
        {
            throw new NotImplementedException();
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
            return true;
        }
    }
}