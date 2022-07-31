
namespace Artillery.DataProcessor
{
    using Artillery.Data;
    using Artillery.DataProcessor.ExportDto;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportShells(ArtilleryContext context, double shellWeight)
        {
            var result = context.Shells
                .Where(s => s.ShellWeight > shellWeight)
                .Select(s => new
                {
                    s.ShellWeight,
                    s.Caliber,
                    Guns = s.Guns
                    .Where(g => g.GunType == Data.Models.Enums.GunType.AntiAircraftGun)
                    .Select(g => new
                    {
                        GunType = g.GunType.ToString(),
                        g.GunWeight,
                        g.BarrelLength,
                        Range = g.Range > 3000 ? "Long-range" : "Regular range"
                    })
                    .OrderByDescending(g => g.GunWeight)
                    .ToArray()
                })
                .OrderBy(s => s.ShellWeight)
                .ToArray();

            return JsonConvert.SerializeObject(result, Formatting.Indented);
        }

        public static string ExportGuns(ArtilleryContext context, string manufacturer)
        {
            var test = context.Guns.ToArray();

            var guns = context.Guns
                    .Include(g => g.CountriesGuns)
                    .ToArray()
                    .Where(g => g.Manufacturer.ManufacturerName.ToLower().Contains(manufacturer.ToLower()))
                    .Select(g => new ExportGunDto()
                    {
                        BarrelLength = g.BarrelLength,
                        GunType = g.GunType.ToString(),
                        GunWeight = g.GunWeight,
                        Manufacturer = g.Manufacturer.ManufacturerName,
                        Range = g.Range,
                        Countries = g.CountriesGuns
                            .Where(cg => cg.Country.ArmySize > 4500000)
                            .Select(c => new ExportCountryDto()
                            {
                                Country = c.Country.CountryName,
                                ArmySize = c.Country.ArmySize,
                            })
                            .OrderBy(c => c.ArmySize)
                            .ToArray()
                    })
                    .OrderBy(g => g.BarrelLength)
                    .ToArray();

            return SerializerHelper(guns, "Guns");
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
