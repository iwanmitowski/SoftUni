using System;

namespace _07.ProjectsCreation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int numProjects = int.Parse(Console.ReadLine());

            Console.WriteLine($"The architect {name} will need {numProjects*3} hours to complete {numProjects} project/s.");
        }
    }
}
