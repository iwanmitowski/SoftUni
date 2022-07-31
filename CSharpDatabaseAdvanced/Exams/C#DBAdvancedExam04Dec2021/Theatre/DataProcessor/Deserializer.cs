namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            var dtos = XmlDeserializer<ImportPlayDto[]>(xmlString, "Plays");
            var sb = new StringBuilder();
            var result = new List<Play>();

            foreach (var dto in dtos)
            {
                var isDurationValid = TimeSpan
                    .TryParseExact(
                        dto.Duration, "c",
                        CultureInfo.InvariantCulture,
                        out TimeSpan duration);
                bool isDefinedEnum = Enum.IsDefined(typeof(Genre), dto.Genre);

                if (!IsValid(dto) ||
                    !isDefinedEnum ||
                    !(isDurationValid && duration.TotalHours > 1))
                {
                    sb.AppendLine(ErrorMessage);
                }
                else
                {
                    result.Add(new Play()
                    {
                        Title = dto.Title,
                        Duration = duration,
                        Rating = dto.Rating,
                        Genre = Enum.Parse<Genre>(dto.Genre),
                        Description = dto.Description,
                        Screenwriter = dto.Screenwriter,
                    });

                    sb.AppendLine(string.Format(SuccessfulImportPlay, dto.Title, dto.Genre, dto.Rating));
                }
            }

            context.AddRange(result);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            var dtos = XmlDeserializer<ImportCastDto[]>(xmlString, "Casts");
            var sb = new StringBuilder();
            var result = new List<Cast>();

            foreach (var dto in dtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                }
                else
                {
                    result.Add(new Cast()
                    {
                        FullName = dto.FullName,
                        IsMainCharacter = dto.IsMainCharacter,
                        PhoneNumber = dto.PhoneNumber,
                        PlayId = dto.PlayId,
                    });

                    sb.AppendLine(string.Format(SuccessfulImportActor, dto.FullName, dto.IsMainCharacter ? "main" : "lesser"));
                }
            }

            context.AddRange(result);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            var dtos = JsonConvert.DeserializeObject<ImportTheaterDto[]>(jsonString);
            var sb = new StringBuilder();
            var result = new List<Theatre>();

            foreach (var dto in dtos)
            {
                var theatre = new Theatre();

                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                }
                else
                {
                    theatre.Name = dto.Name;
                    theatre.NumberOfHalls = dto.NumberOfHalls;
                    theatre.Director = dto.Director;

                    foreach (var ticketDto in dto.Tickets)
                    {
                        if (!IsValid(ticketDto))
                        {
                            sb.AppendLine(ErrorMessage);
                        }
                        else
                        {
                            theatre.Tickets.Add(new Ticket()
                            {
                                Price = ticketDto.Price,
                                RowNumber = ticketDto.RowNumber,
                                PlayId = ticketDto.PlayId,
                            });
                        }
                    }

                    result.Add(theatre);
                    sb.AppendLine(string.Format(SuccessfulImportTheatre, theatre.Name, theatre.Tickets.Count()));
                }
            }

            context.AddRange(result);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }

        private static T XmlDeserializer<T>(string inputXml, string rootName)
        {
            var xmlRoot = new XmlRootAttribute(rootName);
            var serializer = new XmlSerializer(typeof(T), xmlRoot);

            using StringReader reader = new StringReader(inputXml);

            T dtos = (T)serializer.Deserialize(reader);

            return dtos;
        }

    }
}
