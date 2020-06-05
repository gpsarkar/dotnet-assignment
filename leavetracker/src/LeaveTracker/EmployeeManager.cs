using System;
using System.IO;

namespace LeaveTracker
{
    public class EmployeeManager
    {
        public static Employee GetEmployeeFromCsv(int id)
        {
            var E = new Employee();
            using( var reader = File.OpenText("employee.csv"))
            {
                var entry = reader.ReadLine(); //skip first line as it is header
                while(reader.ReadLine() != null)
                {
                    var employ = entry.Split(",");
                    if (int.Parse(employ[0]) == id )
                    {
                        E.ID = int.Parse(employ[0]);
                        E.Name = employ[1];
                        E.ManID = int.Parse(employ[2]);
                        break;
                    }
                }
            }
            return E;
        }
    }
}