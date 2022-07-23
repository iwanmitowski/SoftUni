using CarDealer.Data;
using CarDealer.Dtos.Export;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var suppliersXml = File.ReadAllText("../../../Datasets/suppliers.xml");
            var partsXml = File.ReadAllText("../../../Datasets/parts.xml");
            var carsXml = File.ReadAllText("../../../Datasets/cars.xml");
            var customersXml = File.ReadAllText("../../../Datasets/customers.xml");
            var salesXml = File.ReadAllText("../../../Datasets/sales.xml");

            var context = new CarDealerContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //ImportSuppliers(context, suppliersXml);
            //ImportParts(context, partsXml);
            //ImportCars(context, carsXml);
            //ImportCustomers(context, customersXml);
            //var result = ImportSales(context, salesXml);
            var result = GetSalesWithAppliedDiscount(context);
            Console.WriteLine(result);
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            // Broken test in Judge
            var sales = context.Sales
                .Select(x => new SalesWithDiscount
                {
                    Car = new CarSaleDto
                    {
                        Make = x.Car.Make,
                        Model = x.Car.Model,
                        TravelledDistance = x.Car.TravelledDistance
                    },
                    Discount = x.Discount,
                    CustomerName = x.Customer.Name,
                    Price = x.Car.PartCars.Sum(x => x.Part.Price),
                    PriceWithDiscount = (x.Car.PartCars.Sum(p => p.Part.Price) - x.Car.PartCars.Sum(p => p.Part.Price) * x.Discount / 100).ToString("0.#####")
                })
                .ToArray();

            var result = Serializer(sales, "sales");

            return result;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                    .Where(c => c.Sales.Any())
                    .Select(c => new TotalSaleByCustomerDto()
                    {
                        FullName = c.Name,
                        BoughtCars = c.Sales.Count(),
                        SpentMoney = c.Sales.SelectMany(s => s.Car.PartCars).Sum(p => p.Part.Price)
                    })
                    .OrderByDescending(c => c.SpentMoney)
                    .ToArray();

            var result = Serializer(customers, "customers");

            return result;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new CarWithTheirListOfPartsDto()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.PartCars.Select(cp => new ListOfPartDto()
                    {
                        Name = cp.Part.Name,
                        Price = cp.Part.Price,
                    })
                    .OrderByDescending(p => p.Price)
                    .ToArray(),
                })
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ToArray();

            var result = Serializer(cars, "cars");

            return result;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                    .Where(s => !s.IsImporter)
                    .Select(s => new LocalSupplierDto()
                    {
                        Id = s.Id,
                        Name = s.Name,
                        PartsCount = s.Parts.Count(),
                    })
                    .ToArray();

            var result = Serializer(suppliers, "suppliers");

            return result;
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var cars = context.Cars
                    .Where(c => c.Make == "BMW")
                    .Select(c => new BmwCarDto()
                    {
                        Id = c.Id,
                        Model = c.Model,
                        TravelledDistance = c.TravelledDistance,
                    })
                    .OrderBy(c => c.Model)
                    .ThenByDescending(c => c.TravelledDistance)
                    .ToArray();

            var result = Serializer(cars, "cars");

            return result;
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.TravelledDistance > 2_000_000)
                .Select(c => new CarWithDistanceDto()
                {
                    TravelledDistance = c.TravelledDistance,
                    Make = c.Make,
                    Model = c.Model,
                }).OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ToArray();

            var result = Serializer(cars, "cars");

            return result;
        }

        //public static string ImportSales(CarDealerContext context, string inputXml)
        //{
        //    var carIds = context.Cars.Select(c => c.Id);

        //    var dtos = Deserializer<SaleImportDto[]>(inputXml, "Sales");
        //    dtos = dtos.Where(d => carIds.Any(cid => cid == d.CarId)).ToArray();

        //    var sales = dtos.Select(d => new Sale()
        //    {
        //        Discount = d.Discount,
        //        CarId = d.CarId,
        //        CustomerId = d.CustomerId
        //    }).ToArray();

        //    context.Sales.AddRange(sales);
        //    context.SaveChanges();

        //    return $"Successfully imported {sales.Count()}";
        //}

        //public static string ImportCustomers(CarDealerContext context, string inputXml)
        //{
        //    var dtos = Deserializer<CustomerImportDto[]>(inputXml, "Customers");

        //    var customers = dtos.Select(d => new Customer()
        //    {
        //        Name = d.Name,
        //        BirthDate = d.BirthDate,
        //        IsYoungDriver = d.IsYoungDriver,
        //    }).ToArray();

        //    context.Customers.AddRange(customers);
        //    context.SaveChanges();

        //    return $"Successfully imported {customers.Count()}";
        //}

        //public static string ImportCars(CarDealerContext context, string inputXml)
        //{
        //    var dtos = Deserializer<CarImportDto[]>(inputXml, "Cars");
        //    var cars = new List<Car>();

        //    foreach (var carDto in dtos)
        //    {
        //        var car = new Car
        //        {
        //            Make = carDto.Make,
        //            Model = carDto.Model,
        //            TravelledDistance = carDto.TravelledDistance
        //        };

        //        var currCarParts = new List<PartCar>();
        //        foreach (var partId in carDto.Parts.Select(p => p.Id).Distinct())
        //        {
        //            if (!context.Parts.Any(p => p.Id == partId))
        //            {
        //                continue;
        //            }

        //            var partCar = new PartCar
        //            {
        //                Car = car,
        //                PartId = partId
        //            };

        //            currCarParts.Add(partCar);
        //        }

        //        car.PartCars = currCarParts;
        //        cars.Add(car);
        //    }

        //    context.Cars.AddRange(cars);
        //    context.SaveChanges();

        //    return $"Successfully imported {dtos.Count()}";
        //}


        //public static string ImportParts(CarDealerContext context, string inputXml)
        //{
        //    var supplierIds = context.Suppliers.Select(s => s.Id);

        //    var dtos = Deserializer<PartImportDto[]>(inputXml, "Parts");

        //    dtos = dtos.Where(s => supplierIds.Any(sid => sid == s.SupplierId)).ToArray();

        //    var parts = dtos.Select(d => new Part()
        //    {
        //        Name = d.Name,
        //        Price = d.Price,
        //        Quantity = d.Quantity,
        //        SupplierId = d.SupplierId,
        //    });

        //    context.AddRange(parts);
        //    context.SaveChanges();

        //    return $"Successfully imported {parts.Count()}";
        //}

        //public static string ImportSuppliers(CarDealerContext context, string inputXml)
        //{
        //    var dtos = Deserializer<SupplierImportDto[]>(inputXml, "Suppliers");

        //    var suppliers = dtos.Select(d => new Supplier()
        //    {
        //        Name = d.Name,
        //        IsImporter = d.IsImporter,
        //    });

        //    context.AddRange(suppliers);
        //    context.SaveChanges();

        //    return $"Successfully imported {suppliers.Count()}";
        //}

        private static T Deserializer<T>(string inputXml, string rootName)
        {
            var xmlRoot = new XmlRootAttribute(rootName);
            var serializer = new XmlSerializer(typeof(T), xmlRoot);

            using StringReader reader = new StringReader(inputXml);

            T dtos = (T)serializer.Deserialize(reader);

            return dtos;
        }

        private static string Serializer<T>(T dto, string rootName)
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