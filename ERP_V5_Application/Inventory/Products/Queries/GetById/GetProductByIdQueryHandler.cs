using AutoMapper;
using ERP_V5_Application.Common.Interfaces;
using ERP_V5_Application.Inventory.Products.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ERP_V5_Application.Inventory.Products.Queries.GetProductById
{
    public sealed class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto?>
    {
        private readonly IProductRepository _productRepo;
        private readonly IMapper _mapper;
        public GetProductByIdQueryHandler(IProductRepository productRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }
        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepo.GetByIdAsync(request.id, cancellationToken);
            var productDto = _mapper.Map<ProductDto>(product);
            return product is null ? null : productDto;
        }
    }
}
