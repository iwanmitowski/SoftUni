using AutoMapper;
using ProductShop.Dtos.Export;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            // Import
            //this.CreateMap<ImportUserDto, User>();
            //this.CreateMap<ImportProductDto, Product>();
            //this.CreateMap<ImportCategoryDto, Category>();
            //this.CreateMap<ImportCategoryProductDto, CategoryProduct>();

            // Export
            this.CreateMap<Product, ProductInRangeDto>();
        }
    }
}
