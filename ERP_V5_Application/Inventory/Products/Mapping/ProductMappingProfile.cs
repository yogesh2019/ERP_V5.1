using AutoMapper;
using ERP_V5_Application.Inventory.Products.DTOs;
using ERP_V5_Domain.Inventory.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_V5_Application.Inventory.Products.Mapping
{
    public sealed class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, ProductDto>();
        }
    }
}
