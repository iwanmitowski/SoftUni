using System;
using System.IO;

namespace _05.SliceFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.Combine("..", "..", "..", "sliceMe.txt");
            using var fileStream = new FileStream(path, FileMode.Open);
            int slice = (int)Math.Ceiling(fileStream.Length / 4.0);

            for (int i = 1; i <= 4; i++)
            {
                var buffer = new byte[slice];
                fileStream.Read(buffer);

                string dest = Path.Combine("..", "..", "..", $"Part-{i}.txt");
                using var fileWriter = new FileStream(dest, FileMode.OpenOrCreate);
                fileWriter.Write(buffer);
            }

        }
    }
}
