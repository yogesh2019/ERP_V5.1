using ERP_V5_Application.Common.Interfaces;
using ERP_V5_Domain.Products;
using MediatR;

namespace ERP_V5_Application.Products.Commands.CreateProduct;

public sealed class CreateProductCommandHandler(IProductRepository _productRepository, IUnitOfWork _unitOfWork) : IRequestHandler<CreateProductCommand, CreateProductResult>
{

    public async Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {

        var exists = await _productRepository.ExistsByNameAsync(request.Name, cancellationToken);

        if (exists)
        {
            throw new InvalidOperationException("A product with the same name already exits");
        }
        var product = Product.Create(request.Name, request.StockQty, request.Price);

        await _productRepository.AddAsync(product, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return new CreateProductResult(product.Id);
    }
}
