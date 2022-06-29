using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var context = new SoftUniContext();

            Console.WriteLine(GetEmployeesInPeriod(context));
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.EmployeesProjects
                    .Where(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003)
                    .Distinct()
                    .Select(ep => new
                    {
                        ep.Employee.FirstName,
                        ep.Employee.LastName,
                        ManagerFirstName = ep.Employee.Manager.FirstName,
                        ManagerLastName = ep.Employee.Manager.LastName,
                        EmployeeProjects = ep.Employee.EmployeesProjects.Select(e => e.Project).ToArray(),
                    })
                    .Take(10)
                    .ToList();

            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");
            }

            foreach (var employee in employees)
            {
                var currentProjects = employee.EmployeeProjects
                         .Select(p => new
                         {
                             ProjectName = p.Name,
                             StartDate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt"),
                             EndDate = p.EndDate != null ? p.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt") : "not finished",
                         })
                         .ToList();

                foreach (var currentProject in currentProjects)
                {
                    sb.AppendLine($"-- {currentProject.ProjectName} - {currentProject.StartDate} - {currentProject.EndDate}");
                }
            }


            return sb.ToString().TrimEnd();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var address = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4,
            };

            var currentEmp = context.Employees.FirstOrDefault(x => x.LastName == "Nakov");
            currentEmp.Address = address;
            context.SaveChanges();

            var sb = new StringBuilder();

            var filtered = context.Employees
                .Select(x => new
                {
                    x.Address.AddressText,
                    x.AddressId,
                })
                .OrderByDescending(x => x.AddressId)
                .Take(10)
                .ToList();


            foreach (var employee in filtered)
            {
                sb.AppendLine(employee.AddressText);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Employees
                    .Where(e => e.Department.Name == "Research and Development")
                    .Select(e => new
                    {
                        e.FirstName,
                        e.LastName,
                        e.Salary,
                        DepartmentName = e.Department.Name
                    })
                    .OrderBy(e => e.Salary)
                    .ThenByDescending(e => e.FirstName);

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.DepartmentName} - ${employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Employees
                    .Where(e => e.Salary > 50000)
                    .Select(e => new
                    {
                        e.FirstName,
                        e.Salary,
                    })
                    .OrderBy(e => e.FirstName);

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Employees
                .Select(e => new
                {
                    e.EmployeeId,
                    e.FirstName,
                    e.MiddleName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary,
                })
                .OrderBy(e => e.EmployeeId);

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
