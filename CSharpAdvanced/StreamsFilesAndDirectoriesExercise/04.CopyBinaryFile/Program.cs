using System;
using System.IO;

namespace _04.CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.Combine("..", "..", "..", "copyMe.png");
            var fr = new FileStream(path, FileMode.Open);

            string dest = Path.Combine("..", "..", "..", "result.png");
            var fw = new FileStream(dest, FileMode.Create);

            var buffer = new byte[4096];

            for (int i = 0; i < fr.Length / 4096 + 1; i++)
            {
                fr.Read(buffer);

                fw.Write(buffer);
            }
        }
    }
}
