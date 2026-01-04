// ERP_V5_Application/Products/DTOs/ProductDto.cs
namespace ERP_V5_Application.Inventory.Products.DTOs;

public sealed class ProductDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = null!;
    public int StockQty { get; init; }
    public decimal Price { get; init; }
    public Guid CategoryId { get; init; }
    public bool IsActive { get; set; }
}
