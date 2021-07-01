using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ShootForTheWin
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine().Split().Select(int.Parse).ToList();

            int shotTargets = 0;

            string input = Console.ReadLine();

            while (input != "End")
            {
                int index = int.Parse(input);

                if (index >= 0 && index < targets.Count && targets[index] != -1)
                {
                    int currentTargetPoints = targets[index];
                    targets[index] = -1;
                    targets = targets.Select(x => (x <= currentTargetPoints && x != -1 ? x += currentTargetPoints : x -= currentTargetPoints)).Select(x => x < 0 ? -1 : x).ToList();
                    shotTargets++;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Shot targets: {shotTargets} -> {string.Join(" ", targets)}");
        }
    }
}
