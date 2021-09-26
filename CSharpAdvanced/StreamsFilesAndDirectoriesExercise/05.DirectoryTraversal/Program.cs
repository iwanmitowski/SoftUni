using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _05.DirectoryTraversal
{
    class CurrentFile
    {
        public CurrentFile(string name, double length)
        {
            Name = name;
            Length = length;
        }

        public string Name { get; set; }
        public double Length { get; set; }

        public override string ToString()
        {
            return $"--{Name} - {Length / 1024.0:f3}kb";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string path = ".";

            var files = Directory.GetFiles(path);

            var extensionsFiles = new Dictionary<string, List<CurrentFile>>();

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);

                var extension = fileInfo.Extension;


                if (!extensionsFiles.ContainsKey(extension))
                {
                    extensionsFiles.Add(extension, new List<CurrentFile>());
                }

                var fileName = fileInfo.Name;
                var fileLength = fileInfo.Length;
                var currentFile = new CurrentFile(fileName, fileLength);

                extensionsFiles[extension].Add(currentFile);
            }

            var sb = new StringBuilder();

            foreach ((string extension, List<CurrentFile> filez) in extensionsFiles.OrderByDescending(x => x.Value.Count()).ThenBy(x => x.Key))
            {
                sb.AppendLine(extension);
                foreach (var file in filez.OrderBy(x => x.Length))
                {
                    sb.AppendLine(file.ToString());
                }
            }

            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string dest = Path.Combine(desktop, "report.txt");

            File.WriteAllText(dest, sb.ToString());
        }
    }
}
