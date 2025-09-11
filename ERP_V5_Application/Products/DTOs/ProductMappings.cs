using ERP_V5_Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ERP_V5_Application.Products.DTOs
{
    public static class ProductMappings
    {
        public static ProductDto ToDto(this Product p)
        {
            return new(p.Id, p.Name, p.StockQty, p.Price);
        }
        public static IQueryable<ProductDto> ProjectToDto(this IQueryable<Product> query)
        {
            return query.Select(p => new ProductDto(p.Id, p.Name, p.StockQty, p.Price));
        }
    }
}
