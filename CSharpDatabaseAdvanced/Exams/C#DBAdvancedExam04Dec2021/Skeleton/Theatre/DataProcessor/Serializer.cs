namespace Theatre.DataProcessor
{
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var result = context.Theatres
                    .Include(t => t.Tickets)
                    .ToArray()
                    .Where(t => t.Tickets.Count >= 20)
                    .Select(t => new
                    {
                        t.Name,
                        Halls = t.NumberOfHalls,
                        TotalIncome = t.Tickets.Where(tc => tc.RowNumber >= 1 && tc.RowNumber <= 5).Sum(tc => tc.Price),
                        Tickets = t.Tickets
                            .Where(tc => tc.RowNumber >= 1 && tc.RowNumber <= 5)
                            .Select(tc => new
                            {
                                tc.Price,
                                tc.RowNumber,
                            })
                            .OrderByDescending(tc => tc.Price)
                            .ToArray(),
                    })
                    .OrderByDescending(t => t.Halls)
                    .ThenBy(t => t.Name)
                    .ToArray();

            return JsonConvert.SerializeObject(result, Formatting.Indented);
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            var plays = context.Plays
                .Include(p => p.Casts)
                .Where(p => p.Rating <= rating)
                .ToArray()
                .Select(p => new ExportPlayDto()
                {
                    Duration = p.Duration.ToString("c"),
                    Genre = p.Genre,
                    Rating = p.Rating == 0 ? "Premier" : p.Rating.ToString(),
                    Title = p.Title,
                    Actors = p.Casts
                        .Where(a => a.IsMainCharacter)
                        .Select(a => new ExportActorDto()
                        {
                            FullName = a.FullName,
                            MainCharacter = $"Plays main character in '{p.Title}'.",
                        })
                        .OrderByDescending(a => a.FullName)
                        .ToArray()
                })
                .OrderBy(p => p.Title)
                .ThenByDescending(p => p.Genre)
                .ToArray();

            return SerializerHelper<ExportPlayDto[]>(plays, "Plays");
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
