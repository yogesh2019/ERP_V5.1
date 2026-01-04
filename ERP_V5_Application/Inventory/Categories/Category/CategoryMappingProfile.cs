using AutoMapper;
using ERP_V5_Application.Inventory.Categories.DTOs;
using ERP_V5_Domain.Inventory.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_V5_Application.Inventory.Categories.Category
{
    public sealed class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<ERP_V5_Domain.Inventory.Categories.Category, CategoryDto>();
        }
    }
}
