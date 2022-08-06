namespace Footballers.DataProcessor
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Footballers.DataProcessor.ExportDto;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportCoachesWithTheirFootballers(FootballersContext context)
        {
            var result = context.Coaches
                    .Include(c => c.Footballers)
                    .Where(c => c.Footballers.Any())
                    .ToArray()
                    .Select(c => new ExportCoachDto()
                    {
                        CoachName = c.Name,
                        Footballers = c.Footballers.Select(f => new ExportFootballersDto()
                        {
                            Name = f.Name,
                            Position = f.PositionType.ToString()
                        })
                        .OrderBy(f => f.Name)
                        .ToArray(),
                        FootballersCount = c.Footballers.Count
                    })
                    .OrderByDescending(c => c.FootballersCount)
                    .ThenBy(c => c.CoachName)
                    .ToArray();

            return SerializerHelper(result, "Coaches");
        }

        public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
        {
            var teams = context.Teams
                .Include(t => t.TeamsFootballers)
                .ThenInclude(t => t.Footballer)
                .ToArray()
                .Where(t => t.TeamsFootballers.Any(tf => tf.Footballer.ContractStartDate >= date))
                .Select(t => new
                {
                    Name = t.Name,
                    Footballers = t.TeamsFootballers
                    .Where(tf => tf.Footballer.ContractStartDate >= date)
                    .OrderByDescending(tf => tf.Footballer.ContractEndDate)
                    .ThenBy(tf => tf.Footballer.Name)
                    .Select(tf => new
                    {
                        FootballerName = tf.Footballer.Name,
                        ContractStartDate = tf.Footballer.ContractStartDate.ToString("MM/dd/yyyy"),
                        ContractEndDate = tf.Footballer.ContractEndDate.ToString("MM/dd/yyyy"),
                        BestSkillType = tf.Footballer.BestSkillType.ToString(),
                        PositionType = tf.Footballer.PositionType.ToString(),
                    })
                    .ToArray(),
                })
                .OrderByDescending(t => t.Footballers.Count())
                .ThenBy(t => t.Name)
                .Take(5)
                .ToArray();

            var result = JsonConvert.SerializeObject(teams, Formatting.Indented);

            return result;
        }

        private static string SerializerHelper<T>(T dto, string rootName)
        {
            var sb = new StringBuilder();

            var xmlRoot = new XmlRootAttribute(rootName);
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            var serializer = new XmlSerializer(typeof(T), xmlRoot);

            using var writer = new StringWriter(sb);
            serializer.Serialize(writer, dto, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}
