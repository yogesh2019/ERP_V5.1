using AutoMapper;
using ERP_V5_Application.Common.Interfaces;
using ERP_V5_Application.Common.Models;
using ERP_V5_Application.Inventory.Categories.DTOs;
using ERP_V5_Application.Inventory.Products.DTOs;
using ERP_V5_Domain.Inventory.Common;
using ERP_V5_Domain.Inventory.Products;
using MediatR;

namespace ERP_V5_Application.Inventory.Products.Commands.CreateProduct;

public sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Result<ProductDto>>
{
    private readonly IProductRepository _products;
    private readonly ICategoryRepository _categories;
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public CreateProductCommandHandler(
        IProductRepository products,
        ICategoryRepository categories,
        IUnitOfWork uow,
        IMapper mapper
        )
    {
        _products = products;
        _categories = categories;
        _mapper = mapper;
        _uow = uow;
    }
    public async Task<Result<ProductDto>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {

        var categoryExists = await _categories.GetByIdAsync(request.CategoryId, cancellationToken);
        if (categoryExists is null)
        {
            return Result<ProductDto>.Failure("Catogory Not Found");
        }
        var product = Product.Create(request.Name,
            request.StockQty,
            request.Price,
            request.CategoryId);

        await _uow.BeginTransactionAsync(cancellationToken);

        try
        {
            await _products.AddAsync(product, cancellationToken);
            await _uow.CommitTransactionAsync(cancellationToken);
        }
        catch
        {
            await _uow.RollbackTransactionAsync(cancellationToken);
            throw;
        }
        var dto = _mapper.Map<ProductDto>(product);
        return Result<ProductDto>.Success(dto);
    }
}
