using System;
using System.Collections.Generic;

namespace Adapter
{
    class EmployeeClient
    {
        static void Main()
        {
            IEmployeeTarget target = new EmployeeAdapter();
            List<string> employees = target.GetEmployees();
            foreach (string employee in employees)
            {
                Console.WriteLine(employee);
            }

            Console.Read();
        }
    }

    public class ThirdPartyEmployeeAdaptee
    {
        public List<string> GetEmployeesList()
        {
            List<string> employeesList = new List<string>()
            {
                "Adam", "Bill", "Chris", "David"
            };

            return employeesList;
        }
    }

    interface IEmployeeTarget
    {
        List<string> GetEmployees();
    }

    class EmployeeAdapter : ThirdPartyEmployeeAdaptee,IEmployeeTarget
    {
        public List<string> GetEmployees()
        {
            return GetEmployeesList();
        }
    }


}
