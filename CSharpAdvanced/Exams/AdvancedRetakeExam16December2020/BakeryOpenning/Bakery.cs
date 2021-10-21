using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private readonly List<Employee> employees;

        public Bakery(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            this.employees = new List<Employee>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => this.employees.Count;

        public void Add(Employee employee)
        {
            if (this.Capacity == this.Count)
            {
                throw new InvalidOperationException();
            }

            this.employees.Add(employee);
        }

        public bool Remove(string name)
        {
            var employee = GetEmployee(name);

            if (employee == null)
            {
                return false;
            }

            this.employees.Remove(employee);

            return true;
        }

        public Employee GetOldestEmployee()
        {
            return this.employees.OrderByDescending(x => x.Age).FirstOrDefault();
        }

        public Employee GetEmployee(string name)
        {
            return this.employees.FirstOrDefault(x => x.Name == name);
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Employees working at Bakery {this.Name}:");
            foreach (var employee in employees)
            {
                sb.AppendLine(employee.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
