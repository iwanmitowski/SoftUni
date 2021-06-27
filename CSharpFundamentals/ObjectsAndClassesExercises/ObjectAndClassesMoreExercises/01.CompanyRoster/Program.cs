using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CompanyRoster
{
    class Employee
    {
        public Employee(string name, decimal salary, string department)
        {
            Name = name;
            Salary = salary;
            Department = department;
        }

        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string Department { get; set; }

        public override string ToString()
        {
            return $"{Name} {Salary:f2}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Employee> employees = new List<Employee>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                employees.Add(new Employee(tokens[0], decimal.Parse(tokens[1]), tokens[2]));
            }

            var department = employees
                .GroupBy(e => e.Department)
                .Select(group =>
                         new
                         {
                             Department = group.Key,
                             Salary = group.Select(x => x.Salary).Average()
                         })
                 .OrderByDescending(x => x.Salary)
                 .First().Department;

            Console.WriteLine($"Highest Average Salary: {department}");
            foreach (var employee in employees.Where(x=>x.Department==department).OrderByDescending(e=>e.Salary).ThenByDescending(e=>e.Name))
            {
                Console.WriteLine(employee);
            }
        }
    }
}
