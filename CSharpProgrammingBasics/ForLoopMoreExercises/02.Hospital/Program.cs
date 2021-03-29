using System;

namespace _02.Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            int period = int.Parse(Console.ReadLine());

            int medics = 7;

            int treated = 0;
            int unTreated = 0;

            for (int i = 1; i <= period; i++)
            {
                int currentPatients = int.Parse(Console.ReadLine());
                if (i % 3 == 0)
                {
                    if (unTreated > treated)
                    {
                        medics++;
                    }
                }

                if (medics>=currentPatients)
                {
                    treated += currentPatients;
                    
                }
                else
                {
                    int leftPatients = currentPatients - medics;
                    unTreated += leftPatients;
                    treated += medics;
                }

            }

            Console.WriteLine($"Treated patients: {treated}.");
            Console.WriteLine($"Untreated patients: {unTreated}.");
        }
    }
}
