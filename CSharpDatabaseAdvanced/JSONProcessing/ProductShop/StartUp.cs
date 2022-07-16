using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.DTOs;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var usersJson = File.ReadAllText("../../../Datasets/users.json");
            var productsJson = File.ReadAllText("../../../Datasets/products.json");
            var categoriesJson = File.ReadAllText("../../../Datasets/categories.json");
            var categoriesProductJson = File.ReadAllText("../../../Datasets/categories-products.json");

            using var context = new ProductShopContext();

            var result = GetUsersWithProducts(context);

            Console.WriteLine(result);
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var exportRoot = new ExportUsersRootDTO();

            var users = context.Users
                    .Include(x => x.ProductsSold)
                    .ToList()
                    .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                    .Select(u => new UserDTO()
                    {
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Age = u.Age,
                        SoldProducts = new SoldProductExportRootDTO()
                        {
                            Count = u.ProductsSold.Count(ps => ps.Buyer != null),
                            Products = u.ProductsSold
                                .Where(ps => ps.Buyer != null)
                                .Select(ps => new SoldProductExportDTO()
                                {
                                    Name = ps.Name,
                                    Price = ps.Price,
                                })
                        }
                    })
                    .OrderByDescending(u => u.SoldProducts.Count)
                    .ToList();

            exportRoot.UsersCount = users.Count;
            exportRoot.Users = users;

            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            string json = JsonConvert.SerializeObject(exportRoot, new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            });

            return json;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                    .Select(c => new CategoriesWithAvgPriceDTO()
                    {
                        Category = c.Name,
                        ProductsCount = c.CategoryProducts.Count(),
                        AveragePrice = c.CategoryProducts.Average(p => p.Product.Price).ToString("F2"),
                        TotalRevenue = c.CategoryProducts.Sum(p => p.Product.Price).ToString("F2"),
                    })
                    .OrderByDescending(c => c.ProductsCount)
                    .ToList();

            return JsonConvert.SerializeObject(categories, Formatting.Indented);
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                     .Where(u => u.ProductsSold.Any() && u.ProductsSold.Any(p => p.Buyer != null))
                     .Select(u => new UserWithSoldProductsDTO()
                     {
                         FirstName = u.FirstName,
                         LastName = u.LastName,
                         SoldProducts = u.ProductsSold.Select(p => new SoldProductDTO()
                         {
                             Name = p.Name,
                             Price = p.Price,
                             BuyerFirstName = p.Buyer.FirstName,
                             BuyerLastName = p.Buyer.LastName,
                         })
                     })
                     .OrderBy(u => u.LastName)
                     .ThenBy(u => u.FirstName)
                     .ToList();

            return JsonConvert.SerializeObject(users, Formatting.Indented);
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                    .Where(p => p.Price >= 500 && p.Price <= 1000)
                    .Select(p => new GetProductsInRangeDTO()
                    {
                        Name = p.Name,
                        Price = p.Price,
                        Seller = $"{p.Seller.FirstName} {p.Seller.LastName}",
                    })
                    .OrderBy(p => p.Price)
                    .ToList();

            return JsonConvert.SerializeObject(products, Formatting.Indented);
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoryProducts = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson);

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count()}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert
                    .DeserializeObject<Category[]>(inputJson)
                    .Where(c => c.Name != null);

            context.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count()}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<Product[]>(inputJson);

            context.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count()}";
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<User[]>(inputJson);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }
    }
}