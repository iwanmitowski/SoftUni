namespace VaporStore.DataProcessor
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
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
    {
        private const string ErrorMessage =
               "Invalid Data";

        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            var dtos = JsonConvert.DeserializeObject<ImportGameDto[]>(jsonString);
            var sb = new StringBuilder();

            var games = new List<Game>();
            var devs = new List<Developer>();
            var genres = new List<Genre>();
            var tags = new List<Tag>();

            foreach (var dto in dtos)
            {
                if (!IsValid(dto) ||
                    !dto.Tags.Any())
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isValidDate = DateTime.TryParseExact(dto.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime releaseDate);

                if (!isValidDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                var game = new Game()
                {
                    Name = dto.Name,
                    Price = dto.Price,
                    ReleaseDate = releaseDate,
                };

                if (!devs.Any(d => d.Name == dto.Developer))
                {
                    devs.Add(new Developer()
                    {
                        Name = dto.Developer
                    });
                }

                if (!genres.Any(g => g.Name == dto.Genre))
                {
                    genres.Add(new Genre()
                    {
                        Name = dto.Genre
                    });
                }

                game.Developer = devs.FirstOrDefault(d => d.Name == dto.Developer);
                game.Genre = genres.FirstOrDefault(g => g.Name == dto.Genre);

                foreach (var tagDto in dto.Tags)
                {
                    if (!tags.Any(t => t.Name == tagDto))
                    {
                        tags.Add(new Tag
                        {
                            Name = tagDto
                        });
                    }

                    game.GameTags.Add(new GameTag()
                    {
                        Game = game,
                        Tag = tags.FirstOrDefault(t => t.Name == tagDto)
                    });
                }

                games.Add(game);
                sb.AppendLine($"Added {dto.Name} ({dto.Genre}) with {dto.Tags.Length} tags");
            }

            context.AddRange(games);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            var dtos = JsonConvert.DeserializeObject<ImportUserDto[]>(jsonString);
            var sb = new StringBuilder();

            var result = new List<User>();

            foreach (var dto in dtos)
            {
                if (!IsValid(dto) ||
                    !dto.Cards.Any() ||
                    dto.Cards.Any(c => !IsValid(c)))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isValid = true;

                var cards = new List<Card>();

                foreach (var card in dto.Cards)
                {
                    bool isDefinedEnum = Enum.TryParse(card.Type, out CardType cardType);

                    if (!isDefinedEnum)
                    {
                        isValid = false;
                        break;
                    }
                    else
                    {
                        cards.Add(new Card()
                        {
                            Number = card.Number,
                            Cvc = card.Cvc,
                            Type = cardType,
                        });
                    }
                }

                if (!isValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                result.Add(new User()
                {
                    FullName = dto.FullName,
                    Username = dto.Username,
                    Email = dto.Email,
                    Age = dto.Age,
                    Cards = cards,
                });

                sb.AppendLine($"Imported {dto.Username} with {cards.Count} cards");
            }

            context.AddRange(result);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            var dtos = XmlDeserializer<ImportPurchaseDto[]>(xmlString, "Purchases");
            var sb = new StringBuilder();

            var cards = context.Cards.ToList();
            var games = context.Games.ToList();
            var result = new List<Purchase>();

            foreach (var dto in dtos)
            {
                bool isDefinedEnum = Enum.TryParse(dto.Type, out PurchaseType purchaseType);

                if (!IsValid(dto) ||
                    !isDefinedEnum)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isValidDate = DateTime.TryParseExact(dto.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date);

                if (!isValidDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var game = games.FirstOrDefault(g => g.Name == dto.Title);
                var card = cards.FirstOrDefault(c => c.Number == dto.Card);

                var purchase = new Purchase()
                {
                    Game = game,
                    Card = card,
                    Date = date,
                    Type = purchaseType,
                    ProductKey = dto.Key,
                };
                
                result.Add(purchase);

                sb.AppendLine($"Imported {dto.Title} for {card.User.Username}");
            }

            context.AddRange(result);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
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