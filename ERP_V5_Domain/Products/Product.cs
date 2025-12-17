namespace ERP_V5_Domain.Products;
public sealed class Product
{
    public Product()
    {

    }
    public Product(Guid id, string name, int stockQty, decimal price)
    {
        Id = id;
        SetName(name);
        SetStock(stockQty);
        SetPrice(price);
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; } = null!;
    public int StockQty { get; private set; }
    public decimal Price { get; private set; }

    public static Product Create(string name, int stockQty, decimal price) =>
        new Product(Guid.NewGuid(), name, stockQty, price);


    private void SetPrice(decimal price)
    {
        if (price < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(price), "Price cannot be negative");
        }
        Price = price;
    }

    private void SetStock(int stockQty)
    {
        if (stockQty < 0)
            throw new ArgumentOutOfRangeException(nameof(stockQty), "Stock cannot be negative");
        StockQty = stockQty;
    }

    private void SetName(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException("Product name is required", nameof(name));

        if (name.Length > 200)
            throw new ArgumentException("Product name is too long(max 200)", nameof(name));
        Name = name.Trim();
    }
    public void AdjustStock(int delta)
    {
        var newQty = StockQty + delta;
        if (newQty < 0)
            throw new InvalidOperationException("Stock cannot go below zero.");
        StockQty = newQty;
    }

}