using System;

namespace _11.RefactorPyramidVolume
{
    class Program
    {
        static void Main(string[] args)
        {
            double dul, sh, vis, V;
            Console.Write("Length: ");
            dul = double.Parse(Console.ReadLine());
            Console.Write("Width: ");
            sh = double.Parse(Console.ReadLine());
            Console.Write("Height: ");
            vis = double.Parse(Console.ReadLine());
            V = (dul * sh * vis) / 3;
            Console.Write($"Pyramid Volume: { V:f2}");
        }
    }
}
