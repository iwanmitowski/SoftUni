using System;
using System.Text;

namespace _05.HTML
{
    class Program
    {
        static void Main(string[] args)
        {
            string title = Console.ReadLine();
            string article = Console.ReadLine();
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<h1>");
            sb.AppendLine($"    {title}");
            sb.AppendLine("</h1>");
            sb.AppendLine("<article>");
            sb.AppendLine($"    {article}");
            sb.AppendLine("</article>");

            string comments = Console.ReadLine();
            while (comments != "end of comments")
            {
                sb.AppendLine("<div>");
                sb.AppendLine($"    {comments}");
                sb.AppendLine("</div>");
                comments = Console.ReadLine();
            }

            Console.WriteLine(sb.ToString());
        }
    }
}