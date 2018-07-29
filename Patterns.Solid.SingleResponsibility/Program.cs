using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Solid.SingleResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = "Employee.txt";

            //OLD WAY: using employee class to store employee info as well as perform read/write and date conversion operations
            EmployeeOld empOld = new EmployeeOld
            {
                Id = 1001,
                Name = "John",
                DateOfBirth = new DateTime(1985, 7, 22)
            };
            empOld.Save(empOld, filePath);
            EmployeeOld recordOld = empOld.Load(1001, filePath);



            //BETTER WAY: with Single Responsibility (delegating read/write and date conversion to separate classes)
            EmployeeNew empNew = new EmployeeNew
            {
                Id = 1002,
                Name = "Becky",
                DateOfBirth = new DateTime(1987, 2, 27)
            };
            Persistence.Save(empNew, filePath);
            EmployeeNew recordNew = Persistence.Load(1002, filePath);

            Console.ReadKey();
        }
    }
}
