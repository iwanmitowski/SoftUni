using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static IMapper mapper;
        public static IConfigurationProvider config;

        public static void Main(string[] args)
        {
            Mapper.Initialize(config =>
            {
                config.AddProfile<ProductShopProfile>();
            });

            var usersXml = File.ReadAllText("../../../Datasets/users.xml");
            var productsXml = File.ReadAllText("../../../Datasets/products.xml");
            var categoriesXml = File.ReadAllText("../../../Datasets/categories.xml");
            var categoriesProductsXml = File.ReadAllText("../../../Datasets/categories-products.xml");

            var context = new ProductShopContext();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //ImportUsers(context, usersXml);
            //ImportProducts(context, productsXml);
            //ImportCategories(context, categoriesXml);
            //ImportCategoryProducts(context, categoriesProductsXml);
            var result = GetUsersWithProducts(context);
            Console.WriteLine(result);
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Include(u => u.ProductsSold)
                .ToList()
                .Where(x => x.ProductsSold.Count > 0)
                .Select(x => new ExportUserDto
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                    SoldProducts = new SoldProductsExprotDto()
                    {
                        Count = x.ProductsSold.Count(),
                        Products = x.ProductsSold.Select(ps => new ProductExportDto()
                        {
                            Name = ps.Name,
                            Price = ps.Price,
                        })
                        .OrderByDescending(ps => ps.Price)
                        .ToArray()
                    }
                })
                .OrderByDescending(x => x.SoldProducts.Count);

            var root = new ExportUsersAndProductsDto()
            {
                Count = users.Count(),
                Users = users.Take(10).ToArray(),
            };

            var sb = new StringBuilder();
            var serializer = new XmlSerializer(typeof(ExportUsersAndProductsDto), new XmlRootAttribute("Users"));
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using var writer = new StringWriter(sb);
            serializer.Serialize(writer, root, namespaces);

            return sb.ToString().TrimEnd();
        }

        //public static string GetCategoriesByProductsCount(ProductShopContext context)
        //{
        //    var test = context.Categories.ToList();
        //    var categories = context.Categories
        //            .Select(c => new CategoryByProductsCountDto()
        //            {
        //                Name = c.Name,
        //                Count = c.CategoryProducts.Select(x => x.Product).Count(),
        //                AveragePrice = c.CategoryProducts.Select(x => x.Product.Price).Average(),
        //                TotalRevenue = c.CategoryProducts.Select(x => x.Product.Price).Sum(),
        //            })
        //            .OrderByDescending(c => c.Count)
        //            .ThenBy(c => c.TotalRevenue)
        //            .ToArray();

        //    var sb = new StringBuilder();
        //    var serializer = new XmlSerializer(typeof(CategoryByProductsCountDto[]), new XmlRootAttribute("Categories"));
        //    var namespaces = new XmlSerializerNamespaces();
        //    namespaces.Add(string.Empty, string.Empty);

        //    using var writer = new StringWriter(sb);
        //    serializer.Serialize(writer, categories, namespaces);

        //    return sb.ToString().TrimEnd();
        //}

        //public static string GetSoldProducts(ProductShopContext context)
        //{
        //    var users = context.Users
        //            .Where(u => u.ProductsSold.Count >= 1)
        //            .Select(u => new GetSoldProductsDto()
        //            {
        //                FirstName = u.FirstName,
        //                LastName = u.LastName,
        //                SoldProducts = u.ProductsSold.Select(ps => new GetSoldProductProductDto()
        //                {
        //                    Name = ps.Name,
        //                    Price = ps.Price,
        //                }).ToArray()
        //            })
        //            .OrderBy(u => u.LastName)
        //            .ThenBy(u => u.FirstName)
        //            .Take(5)
        //            .ToArray();

        //    var sb = new StringBuilder();
        //    var serializer = new XmlSerializer(typeof(GetSoldProductsDto[]), new XmlRootAttribute("Users"));
        //    var namespaces = new XmlSerializerNamespaces();
        //    namespaces.Add(string.Empty, string.Empty);

        //    using var writer = new StringWriter(sb);
        //    serializer.Serialize(writer, users, namespaces);

        //    return sb.ToString().TrimEnd();
        //}

        //public static string GetProductsInRange(ProductShopContext context)
        //{
        //    var products = context.Products
        //            .Where(p => p.Price >= 500 && p.Price <= 1000)
        //            .OrderBy(p => p.Price)
        //            .Select(p => new ProductInRangeDto()
        //            {
        //                Name = p.Name,
        //                Price = p.Price,
        //                Buyer = $"{p.Buyer.FirstName} {p.Buyer.LastName}"
        //            })
        //            .Take(10)
        //            .ToArray();

        //    var sb = new StringBuilder();
        //    var serializer = new XmlSerializer(typeof(ProductInRangeDto[]), new XmlRootAttribute("Products"));
        //    var namespaces = new XmlSerializerNamespaces();
        //    namespaces.Add(string.Empty, string.Empty);

        //    using var writer = new StringWriter(sb);
        //    serializer.Serialize(writer, products, namespaces);

        //    return sb.ToString().TrimEnd();
        //}

        //public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        //{
        //    var reader = new StringReader(inputXml);
        //    var xmlSerializer = new XmlSerializer(typeof(ImportCategoryProductDto[]), new XmlRootAttribute("CategoryProducts"));
        //    var deserialized = (ImportCategoryProductDto[])xmlSerializer.Deserialize(reader);

        //    var productsIds = context.Products.Select(p => p.Id).ToList();
        //    var categoriesIds = context.Categories.Select(c => c.Id).ToList();

        //    deserialized = deserialized
        //            .Where(cp => productsIds.Any(p => p == cp.ProductId) &&
        //                         categoriesIds.Any(c => c == cp.CategoryId))
        //            .ToArray();

        //    var categoriesProducts = Mapper.Map<CategoryProduct[]>(deserialized);
        //    context.AddRange(categoriesProducts);
        //    context.SaveChanges();

        //    return $"Successfully imported {categoriesProducts.Count()}";
        //}

        //public static string ImportCategories(ProductShopContext context, string inputXml)
        //{
        //    var reader = new StringReader(inputXml);
        //    var xmlSerializer = new XmlSerializer(typeof(ImportCategoryDto[]), new XmlRootAttribute("Categories"));
        //    var deserialized = (ImportCategoryDto[])xmlSerializer.Deserialize(reader);

        //    var categories = Mapper.Map<Category[]>(deserialized.Where(c => c.Name != null));
        //    context.AddRange(categories);
        //    context.SaveChanges();

        //    return $"Successfully imported {categories.Count()}";
        //}

        //public static string ImportProducts(ProductShopContext context, string inputXml)
        //{
        //    var reader = new StringReader(inputXml);
        //    var xmlSerializer = new XmlSerializer(typeof(ImportProductDto[]), new XmlRootAttribute("Products"));
        //    var deserialized = (ImportProductDto[])xmlSerializer.Deserialize(reader);

        //    var products = Mapper.Map<Product[]>(deserialized);
        //    context.AddRange(products);
        //    context.SaveChanges();

        //    return $"Successfully imported {products.Count()}";
        //}

        //public static string ImportUsers(ProductShopContext context, string inputXml)
        //{
        //    using var reader = new StringReader(inputXml);
        //    var xmlSerializer = new XmlSerializer(typeof(ImportUserDto[]), new XmlRootAttribute("Users"));
        //    var deserialized = (ImportUserDto[])xmlSerializer.Deserialize(reader);

        //    var users = Mapper.Map<User[]>(deserialized);
        //    context.AddRange(users);
        //    context.SaveChanges();

        //    return $"Successfully imported {users.Count()}";
        //}
    }
}