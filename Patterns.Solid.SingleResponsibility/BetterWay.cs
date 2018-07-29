using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Solid.SingleResponsibility
{
    public class EmployeeNew
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

    public class Persistence
    {
        public static EmployeeNew Load(int id, string filePath)
        {
            EmployeeNew emp = null;
            var requestedId = id.ToString();
            if (File.Exists(filePath))
            {
                List<string> rows = File.ReadLines("Employee.txt").ToList();
                foreach (var row in rows)
                {
                    var array = row.Split(',');
                    if (array[0] == requestedId)
                    {
                        int empId = Convert.ToInt32(array[0]);
                        string name = array[1];
                        DateTime dob = DateConverter.ToDateTime(array[2]);
                        emp = new EmployeeNew
                        {
                            Id = empId,
                            Name = name,
                            DateOfBirth = dob
                        };
                        break;
                    }
                }
            }
            return emp;
        }

        public static void Save(EmployeeNew employee, string filePath)
        {
            string line = string.Join(",", employee.Id, employee.Name, DateConverter.ToDateString(employee.DateOfBirth));
            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.WriteLine(line);
            }
        }
    }

    public class DateConverter
    {
        private const string dateFormat = "yyyy-MM-dd";
        public static DateTime ToDateTime(string date)
        {
            return DateTime.ParseExact(date, dateFormat, null);
        }

        public static string ToDateString(DateTime date)
        {
            return date.ToString(dateFormat);
        }
    }
}
