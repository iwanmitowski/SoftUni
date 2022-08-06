namespace Footballers.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Footballers.Data.Models;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ImportDto;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            var dtos = XmlDeserializer<ImportCoachDto[]>(xmlString, "Coaches"); // Dto
            var sb = new StringBuilder();
            var result = new List<Coach>(); // Model

            foreach (var dto in dtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var coach = new Coach()
                {
                    Name = dto.Name,
                    Nationality = dto.Nationality,
                    Footballers = new HashSet<Footballer>(),
                };

                foreach (var footballerDto in dto.Footballers)
                {
                    if (!IsValid(footballerDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isDefinedEnumPos = Enum.TryParse(footballerDto.PositionType, out PositionType positionType);
                    bool isDefinedEnumSkill = Enum.TryParse(footballerDto.BestSkillType, out BestSkillType bestSkill);

                    if (!isDefinedEnumPos ||
                        !isDefinedEnumSkill)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var isValidDateS = DateTime
                                        .TryParseExact(
                                            footballerDto.ContractStartDate,
                                            "dd/MM/yyyy",
                                            CultureInfo.InvariantCulture,
                                            DateTimeStyles.None,
                                            out DateTime startDate);
                    var isValidDateE = DateTime
                                        .TryParseExact(
                                            footballerDto.ContractEndDate,
                                            "dd/MM/yyyy",
                                            CultureInfo.InvariantCulture,
                                            DateTimeStyles.None,
                                            out DateTime endDate);

                    if (!isValidDateE ||
                        !isValidDateS ||
                        startDate > endDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    coach.Footballers.Add(new Footballer
                    {
                        Name = footballerDto.Name,
                        ContractStartDate = startDate,
                        ContractEndDate = endDate,
                        BestSkillType = bestSkill,
                        PositionType = positionType
                    });
                }

                result.Add(coach);

                sb.AppendLine(string.Format(SuccessfullyImportedCoach, coach.Name, coach.Footballers.Count));
            }

            context.AddRange(result);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            var dtos = JsonConvert.DeserializeObject<ImportTeamDto[]>(jsonString);
            var sb = new StringBuilder();
            var result = new List<Team>();

            var footabllers = context.Footballers.Select(f => f.Id).ToArray();

            foreach (var dto in dtos)
            {
                if (!IsValid(dto) || dto.Trophies <= 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var team = new Team()
                {
                    Name = dto.Name,
                    Nationality = dto.Nationality,
                    Trophies = dto.Trophies,
                };
                
                foreach (var footballerDto in dto.Footballers.Distinct())
                {
                    if (!footabllers.Contains(footballerDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var teamFootabller = new TeamFootballer()
                    {
                        Team = team,
                        FootballerId = footballerDto,
                    };

                    team.TeamsFootballers.Add(teamFootabller);
                }

                result.Add(team);
                sb.AppendLine(string.Format(SuccessfullyImportedTeam, team.Name, team.TeamsFootballers.Count));
            }

            context.AddRange(result);
            context.SaveChanges();

            return sb.ToString();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
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
