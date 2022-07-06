namespace MusicHub
{
    using System;
    using System.Linq;
    using System.Text;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context = 
                new MusicHubDbContext();

            //DbInitializer.ResetDatabase(context);

            //Test your solutions here
            Console.WriteLine(ExportSongsAboveDuration(context, 4));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context.Albums
                    .Where(a => a.ProducerId == producerId)
                    .Include(a => a.Songs)
                    .ThenInclude(s => s.Writer)
                    .Select(a => new
                    {
                        a.Name,
                        ReleaseDate = a.ReleaseDate,
                        ProducerName = a.Producer.Name,
                        a.Price,
                        Songs = a.Songs
                    })
                    .ToList()
                    .OrderByDescending(a => a.Price);

            var bobTheBuilder = new StringBuilder();

            foreach (var album in albums)
            {
                bobTheBuilder.AppendLine($"-AlbumName: {album.Name}");
                bobTheBuilder.AppendLine($"-ReleaseDate: {album.ReleaseDate.ToString("MM/dd/yyyy")}");
                bobTheBuilder.AppendLine($"-ProducerName: {album.ProducerName}");
                int counter = 1;

                bobTheBuilder.AppendLine("-Songs:");
                foreach (var song in 
                             album.Songs
                                  .Select(s => new
                                  {
                                      s.Name,
                                      Price = $"{s.Price:F2}",
                                      SongWriterName = s.Writer.Name,
                                  })
                                  .OrderByDescending(s=>s.Name)
                                  .ThenBy(s => s.SongWriterName))
                {
                    bobTheBuilder.AppendLine($"---#{counter++}");
                    bobTheBuilder.AppendLine($"---SongName: {song.Name}");
                    bobTheBuilder.AppendLine($"---Price: {song.Price}");
                    bobTheBuilder.AppendLine($"---Writer: {song.SongWriterName}");
                }
                bobTheBuilder.AppendLine($"-AlbumPrice: {album.Price:F2}");
            }

            return bobTheBuilder.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var durationSpan = TimeSpan.FromSeconds(duration);

            var songs = context.Songs
                    .Where(s => s.Duration > durationSpan)
                    .Select(s => new
                    {
                        s.Name,
                        Performer = s.SongPerformers
                                                .Select(sp => sp.Performer.FirstName + " " + sp.Performer.LastName)
                                                .FirstOrDefault(),
                        Writer = s.Writer.Name,
                        AlbumProducer = s.Album.Producer.Name,
                        s.Duration,
                    })
                    .OrderBy(x => x.Name)
                    .ThenBy(x => x.Writer)
                    .ThenBy(x => x.Performer)
                    .ToList();

            int counter = 1;
            var sb = new StringBuilder();

            foreach (var song in songs)
            {
                sb.AppendLine($"-Song #{counter++}");
                sb.AppendLine($"---SongName: {song.Name}");
                sb.AppendLine($"---Writer: {song.Writer}");
                sb.AppendLine($"---Performer: {song.Performer:F2}");
                sb.AppendLine($"---AlbumProducer: {song.AlbumProducer:F2}");
                sb.AppendLine($"---Duration: {song.Duration:c}");
            }

            return sb.ToString().Trim();
        }
    }
}
