using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var suppliersJson = File.ReadAllText("../../../Datasets/suppliers.json");
            var partsJson = File.ReadAllText("../../../Datasets/parts.json");
            var carsJson = File.ReadAllText("../../../Datasets/cars.json");
            var customersJson = File.ReadAllText("../../../Datasets/customers.json");
            var salesJson = File.ReadAllText("../../../Datasets/sales.json");

            using var context = new CarDealerContext();

            var result = GetOrderedCustomers(context);
            Console.WriteLine(result);
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                    .Where(c => c.Sales.Any(s => s.Car != null))
                    .Select(c => new
                    {
                        fullName = c.Name,
                        boughtCars = c.Sales.Count(),
                        spentMoney = c.Sales
                                      .SelectMany(s => s.Car.PartCars)
                                      .Sum(pc => pc.Part.Price)
                    })
                    .OrderByDescending(c => c.spentMoney)
                    .ThenByDescending(c => c.boughtCars);

            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(s => new
                {
                    car = new
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    customerName = s.Customer.Name,
                    Discount = $"{s.Discount:F2}",
                    price = $"{s.Car.PartCars.Sum(p => p.Part.Price):F2}",
                    priceWithDiscount = $@"{s.Car.PartCars.Sum(p => p.Part.Price)
                        - s.Car.PartCars.Sum(p => p.Part.Price) * s.Discount / 100:F2}"
                })
                .Take(10);

            return JsonConvert.SerializeObject(sales, Formatting.Indented);
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new
                {
                    car = new
                    {
                        c.Make,
                        c.Model,
                        c.TravelledDistance,
                    },
                    parts = c.PartCars.Select(pc => new
                    {
                        pc.Part.Name,
                        Price = pc.Part.Price.ToString("F2"),
                    })
                }) 
                .ToList();

            return JsonConvert.SerializeObject(cars, Formatting.Indented);
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                    .Where(s => !s.IsImporter)
                    .Select(s => new
                    {
                        s.Id,
                        s.Name,
                        PartsCount = s.Parts.Count
                    });

            return JsonConvert.SerializeObject(suppliers, Formatting.Indented);
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                    .Where(c => c.Make == "Toyota")
                     .Select(c => new
                     {
                         c.Id,
                         c.Make,
                         c.Model,
                         c.TravelledDistance
                     })
                    .OrderBy(c => c.Model)
                    .ThenByDescending(c => c.TravelledDistance);

            return JsonConvert.SerializeObject(cars, Formatting.Indented);
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                    .OrderBy(c => c.BirthDate)
                    .ThenBy(c => c.IsYoungDriver)
                    .Select(c => new
                    {
                        c.Name,
                        BirthDate = c.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                        c.IsYoungDriver
                    })
                    .ToList();

            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<Sale[]>(inputJson);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<Customer[]>(inputJson);

            context.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var minSupplierId = context.Suppliers.Min(s => s.Id);
            var maxSupplierId = context.Suppliers.Max(s => s.Id);

            var parts = JsonConvert.DeserializeObject<Part[]>(inputJson)
                    .Where(p => p.SupplierId >= minSupplierId && p.SupplierId <= maxSupplierId);

            context.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carDtos = JsonConvert.DeserializeObject<ImportCarDto[]>(inputJson);

            foreach (var carDto in carDtos)
            {
                var car = new Car
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance
                };

                context.Cars.Add(car);
                context.SaveChanges();

                var carId = context.Cars.ToList().Last().Id;

                foreach (var partId in carDto.PartsId)
                {
                    var partCar = new PartCar
                    {
                        CarId = carId,
                        PartId = partId
                    };

                    if (car.PartCars.FirstOrDefault(pc => pc.PartId == partId) == null)
                    {
                        context.PartCars.Add(partCar);
                    }
                }
            }

            context.SaveChanges();

            return $"Successfully imported {carDtos.Count()}.";
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<Supplier[]>(inputJson);

            context.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}.";
        }
    }
}