using ERP_V5_Api.Contracts.Products;
using ERP_V5_Application.Inventory.Products.Commands.CreateProduct;
using ERP_V5_Application.Products.Queries.GetProductById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ERP_V5_Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class ProductsController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;
    [HttpPost]
    public async Task<ActionResult<CreateProductResult>> Create(
        [FromBody] CreateProductRequest request,
        CancellationToken ct)
    {
        var result = await _mediator.Send(
            new CreateProductCommand(request.Name, request.StockQty, request.Price)
            , ct);
        return CreatedAtAction(nameof(GetById), new { id = result.ProductId }, result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
    {
        var product = await _mediator.Send(new GetProductByIdQuery(id), ct);


        return product is null ? NotFound() : Ok(product);
    }

}
