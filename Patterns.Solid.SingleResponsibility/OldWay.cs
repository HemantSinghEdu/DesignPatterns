using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Solid.SingleResponsibility
{
    public class EmployeeOld
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }

        private const string dateFormat = "yyyy-MM-dd";

        public EmployeeOld Load(int id, string filePath)
        {
            EmployeeOld emp = null;
            var requestedId = id.ToString();
            if (File.Exists(filePath))
            {
                List<string> rows = File.ReadLines(filePath).ToList();
                foreach (var row in rows)
                {
                    var array = row.Split(',');
                    if (array[0] == requestedId)
                    {
                        int empId = Convert.ToInt32(array[0]);
                        string name = array[1];
                        DateTime dob = ToDateTime(array[2]);
                        emp = new EmployeeOld
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

        public void Save(EmployeeOld employee, string filePath)
        {
            string line = string.Join(",", employee.Id, employee.Name, ToDateString(employee.DateOfBirth));
            using(StreamWriter sw = File.AppendText(filePath))
            {
                sw.WriteLine(line);
            }
        }

        public DateTime ToDateTime(string date)
        {
            return DateTime.ParseExact(date, dateFormat, null);
        }

        public string ToDateString(DateTime date)
        {
            return date.ToString(dateFormat);
        }
    }
}
