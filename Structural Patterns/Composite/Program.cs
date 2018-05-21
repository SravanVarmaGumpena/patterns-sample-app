using System;
using System.Collections.Generic;

namespace Composite
{
    class Program
    {
        static void Main()
        {
            Employee employee1 = new Employee()
            {
                EmployeeId = 1,
                EmployeeName = "Adam",
                Rating = 4
            };

            Employee employee2 = new Employee()
            {
                EmployeeId = 1,
                EmployeeName = "Bill",
                Rating = 5
            };

            Employee employee3 = new Employee()
            {
                EmployeeId = 1,
                EmployeeName = "David",
                Rating = 5
            };

            Supervisor supervisor1 = new Supervisor()
            {
                EmployeeId = 3,
                EmployeeName = "Chris",
                Rating = 3
            };

            Supervisor supervisor2 = new Supervisor()
            {
                EmployeeId = 4,
                EmployeeName = "Elan",
                Rating = 5
            };

            supervisor1.AddSubordinates(employee1);
            supervisor1.AddSubordinates(employee2);
            supervisor2.AddSubordinates(employee3);

            List<Supervisor> supervisors = new List<Supervisor>();
            supervisors.Add(supervisor1);
            supervisors.Add(supervisor2);

            foreach (Supervisor supervisor in supervisors)
            {
                Console.WriteLine("Performance Summary of Supervisor");
                supervisor.PerformanceReview();

                Console.WriteLine($"{Environment.NewLine}Performance Summary of Employees");
                foreach (Employee employee in supervisor.employees)
                {
                    employee.PerformanceReview();
                }
                Console.WriteLine();
            }

            Console.Read();
        }
    }

    public interface IEmployee
    {
        int EmployeeId { get; set; }
        string EmployeeName { get; set; }
        int Rating { get; set; }
        void PerformanceReview();
    }

    //Leaf
    public class Employee : IEmployee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int Rating { get; set; }
        public void PerformanceReview()
        {
            Console.WriteLine($"Performance of {EmployeeName} is {Rating} of 5");
        }
    }

    //Composite
    public class Supervisor : IEmployee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int Rating { get; set; }

        public List<Employee> employees = new List<Employee>();
        public void PerformanceReview()
        {
            Console.WriteLine($"Performance of {EmployeeName} is {Rating} of 5");
        }

        public void AddSubordinates(Employee employee)
        {
            employees.Add(employee);
        }
    }
}
