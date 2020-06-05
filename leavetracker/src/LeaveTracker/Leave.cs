using System;

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

        public void GetDataFromUser(Employee e)
        {
            ID = e.ID;
            Creator = e.Name;
            Manager = EmployeeManager.GetEmployeeFromCsv(e.ManID).Name;
            Console.WriteLine("Enter the title for the Leave: ");
            var Title = Console.ReadLine();
            Console.WriteLine("Enter Description For the Leave: ");
            var Description = Console.ReadLine();
            Console.WriteLine("Enter Start Date (DD-MM-YYYY): ");
            var StartDate = Console.ReadLine();
            Console.WriteLine("Enter End Date (DD-MM-YYYY): ");
            var EndDate = Console.ReadLine();
            Status = LeaveStatus.Pending ;
        }

    }
}
