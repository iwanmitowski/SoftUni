using System;
using System.IO;
using System.IO.Compression;

namespace _06.ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = Path.Combine("..", "..", "..", "copyMe.png");
            string zipPath = Path.Combine("..", "..", "..", "archive.zip");

            using (ZipArchive zip = ZipFile.Open(zipPath, ZipArchiveMode.Create))
            {
                zip.CreateEntryFromFile(filePath, "copyMe.png");
            };

            string extractPath = Path.Combine("..", "..", "..", "extracted");
            ZipFile.ExtractToDirectory(zipPath, extractPath);
        }
    }
}
