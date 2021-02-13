using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace BakeryOpenning
{
    public class Bakery
    {
        private List<Employee> Data;

        public Bakery(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Data = new List<Employee>(capacity);
        }


        public string Name { get; set; }
        public int Capacity { get; set; }

        public void Add(Employee employee)
        {
            if (Data.Count < Capacity)
            {
                Data.Add(employee);
            }
        }

        public bool Remove(string name)
        {
            foreach (var currEmployee in Data)
            {
                if (currEmployee.Name == name)
                {
                    Data.Remove(currEmployee);
                    return true;
                }
            }

            return false;
        }

        public Employee GetOldestEmployee()
        {
            int oldestEmployee = int.MinValue;

            foreach (var currEmployee in Data)
            {
                if (currEmployee.Age > oldestEmployee)
                {
                    oldestEmployee = currEmployee.Age;
                }
            }

            foreach (var currEmployee in Data)
            {
                if (currEmployee.Age == oldestEmployee)
                {
                    return currEmployee;
                }
            }

            return null;
        }

        public Employee GetEmployee(string name)
        {
            foreach (var currEmployee in Data)
            {
                if (currEmployee.Name == name)
                {
                    return currEmployee;
                }
            }

            return null;
        }

        public int Count()
        {
            return Data.Count;
        }

        public string Report()
        {
            string output = $"Employees working at Bakery {Name}:\n{string.Join(Environment.NewLine, Data)}";
            return output;
        }
    }
}