namespace ERP_V5_Api.Contracts.Products;
public sealed record CreateProductRequest(string Name, int StockQty, decimal Price);
