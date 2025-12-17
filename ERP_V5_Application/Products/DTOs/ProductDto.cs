// ERP_V5_Application/Products/DTOs/ProductDto.cs
namespace ERP_V5_Application.Products.DTOs;

public sealed record ProductDto(
    Guid Id,
    string Name,
    int StockQty,
    decimal Price
);
