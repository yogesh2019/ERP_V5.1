using ERP_V5_Api.Contracts.Products;
using ERP_V5_Application.Inventory.Products.Commands.AdjustStock;
using ERP_V5_Application.Inventory.Products.Commands.CreateProduct;
using ERP_V5_Application.Inventory.Products.Commands.UpdateProduct;
using ERP_V5_Application.Inventory.Products.Queries.GetProductById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace ERP_V5_Api.Controllers;

[ApiController]
[Route("api/v1/inventory/products")]
[Authorize]
public sealed class ProductsController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<IActionResult>> Create(
        [FromBody] CreateProductCommand command,
        CancellationToken ct)
    {
        var result = await _mediator.Send(
            command
            , ct);
        return Ok(result);
    }

    [HttpPut("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(
        Guid id,
        [FromBody] UpdateProductCommand command,
        CancellationToken ct
        )
    {
        var updated = command with { ProductId = id };
        var result = await _mediator.Send(updated, ct);
        return Ok(result);

    }

    [HttpPost("{id:guid}/adjust-stock")]
    [Authorize(Roles = "Warehouse")]
    public async Task<IActionResult> AdjustStock(
        Guid id,
        [FromBody] AdjustStockCommand command,
        CancellationToken ct
        )
    {
        var adjusted = command with { ProductId = id };
        var result = await _mediator.Send(adjusted, ct);
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(
        Guid id,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(
            new GetProductByIdQuery(id), cancellationToken);
        if (result is null)
            return NotFound();

        return Ok(result);
    }
}