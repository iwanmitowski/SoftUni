namespace Artillery.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Artillery.Data;
    using Artillery.Data.Models;
    using Artillery.Data.Models.Enums;
    using Artillery.DataProcessor.ImportDto;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage =
                "Invalid data.";
        private const string SuccessfulImportCountry =
            "Successfully import {0} with {1} army personnel.";
        private const string SuccessfulImportManufacturer =
            "Successfully import manufacturer {0} founded in {1}.";
        private const string SuccessfulImportShell =
            "Successfully import shell caliber #{0} weight {1} kg.";
        private const string SuccessfulImportGun =
            "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";

        public static string ImportCountries(ArtilleryContext context, string xmlString)
        {
            var dtos = XmlDeserializer<ImportCountryDto[]>(xmlString, "Countries");
            var sb = new StringBuilder();
            var result = new List<Country>();

            foreach (var dto in dtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                }
                else
                {
                    result.Add(new Country()
                    {
                        ArmySize = dto.ArmySize,
                        CountryName = dto.CountryName,
                    });

                    sb.AppendLine(string.Format(SuccessfulImportCountry, dto.CountryName, dto.ArmySize));
                }
            }

            context.AddRange(result);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
            var dtos = XmlDeserializer<ImportManufacturerDto[]>(xmlString, "Manufacturers");
            var sb = new StringBuilder();
            var result = new List<Manufacturer>();

            foreach (var dto in dtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                }
                else
                {
                    if (!result.Any(r => r.ManufacturerName == dto.ManufacturerName))
                    {
                        result.Add(new Manufacturer()
                        {
                            ManufacturerName = dto.ManufacturerName,
                            Founded = dto.Founded,
                        });

                        var validTowns = dto.Founded.Split(", ");

                        var resultTown = $"{validTowns[validTowns.Length - 2]}, {validTowns[validTowns.Length - 1]}";

                        sb.AppendLine(string.Format(SuccessfulImportManufacturer, dto.ManufacturerName, resultTown));
                    }
                    else
                    {
                        sb.AppendLine(ErrorMessage);
                    }
                }
            }

            context.AddRange(result);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportShells(ArtilleryContext context, string xmlString)
        {
            var dtos = XmlDeserializer<ImportShellsDto[]>(xmlString, "Shells"); // Dto
            var sb = new StringBuilder();
            var result = new List<Shell>(); // Model

            foreach (var dto in dtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                }
                else
                {
                    result.Add(new Shell() // Model
                    {
                        Caliber = dto.Caliber,
                        ShellWeight = dto.ShellWeight,
                    });

                    sb.AppendLine(string.Format(SuccessfulImportShell, dto.Caliber, dto.ShellWeight));
                }
            }

            context.AddRange(result);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportGuns(ArtilleryContext context, string jsonString)
        {
            var dtos = JsonConvert.DeserializeObject<ImportGunDto[]>(jsonString);
            var sb = new StringBuilder();
            var result = new List<Gun>();

            foreach (var dto in dtos)
            {
                bool isDefinedEnum = Enum.TryParse(dto.GunType, out GunType gunType);

                if (!IsValid(dto) ||
                    !isDefinedEnum)
                {
                    sb.AppendLine(ErrorMessage);
                }
                else
                {
                    var gun = new Gun();
                    gun.BarrelLength = dto.BarrelLength;
                    gun.ManufacturerId = dto.ManufacturerId;
                    gun.NumberBuild = dto.NumberBuild;
                    gun.CountriesGuns = new HashSet<CountryGun>();
                    gun.ShellId = dto.ShellId;
                    gun.GunType = gunType;
                    gun.Range = dto.Range;
                    gun.GunWeight = dto.GunWeight;

                    foreach (var countryDto in dto.Countries)
                    {
                        var countryGun = new CountryGun()
                        {
                            Gun = gun,
                            CountryId = countryDto.Id,
                        };

                        gun.CountriesGuns.Add(countryGun);
                    }

                    sb.AppendLine(string.Format(SuccessfulImportGun, gun.GunType, gun.GunWeight, gun.BarrelLength));
                    result.Add(gun);
                }
            }
            var cg = result.Sum(co => co.CountriesGuns.Count);
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
