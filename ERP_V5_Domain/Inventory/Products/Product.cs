using ERP_V5_Domain.Inventory.Categories;
using ERP_V5_Domain.Inventory.Common;

namespace ERP_V5_Domain.Inventory.Products;

public sealed class Product : BaseEntity
{
    private Product() { } // EF Core

    private Product(
        Guid id,
        string name,
        int stockQty,
        decimal price,
        Guid categoryId)
    {
        Id = id;
        SetName(name);
        SetStock(stockQty);
        SetPrice(price);
        CategoryId = categoryId;
        IsActive = true;
    }

    public string Name { get; private set; } = null!;
    public int StockQty { get; private set; }
    public decimal Price { get; private set; }

    public Guid CategoryId { get; private set; }
    public bool IsActive { get; private set; }

    public Category Category { get; private set; } = null!;
    public static Product Create(
        string name,
        int stockQty,
        decimal price,
        Guid categoryId)
    {
        return new Product(Guid.NewGuid(), name, stockQty, price, categoryId);
    }

    private void SetPrice(decimal price)
    {
        if (price < 0)
            throw new ArgumentOutOfRangeException(nameof(price));

        Price = price;
        MarkUpdated();
    }

    private void SetStock(int stockQty)
    {
        if (stockQty < 0)
            throw new ArgumentOutOfRangeException(nameof(stockQty));

        StockQty = stockQty;
        MarkUpdated();
    }

    private void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Product name is required");

        if (name.Length > 200)
            throw new ArgumentException("Product name is too long");

        Name = name.Trim();
        MarkUpdated();
    }

    public void AdjustStock(int delta)
    {
        var newQty = StockQty + delta;
        if (newQty < 0)
            throw new InvalidOperationException("Stock cannot go below zero.");

        StockQty = newQty;
        MarkUpdated();
    }

    public void Deactivate()
    {
        IsActive = false;
        MarkUpdated();
    }
}
