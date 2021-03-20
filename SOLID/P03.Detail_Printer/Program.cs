using System;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            List<string> documents = new List<string>() {"TOP SECRET", "NOT SO TOP SECRET"  };
            Employee manager = new Manager("Pesho Menijara", documents);
            Employee employee = new Employee("Sashko");
            List<Employee> employees = new List<Employee>();
            employees.Add(manager);
            employees.Add(employee);
            new DetailsPrinter(employees).PrintDetails();
        }
    }
}
