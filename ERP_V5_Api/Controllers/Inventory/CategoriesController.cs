using ERP_V5_Application.Inventory.Categories.Commands;
using ERP_V5_Application.Inventory.Categories.Queries.List;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ERP_V5_Api.Controllers.Inventory
{
    [ApiController]
    [Route("api/v1/inventory/categories")]
    [Authorize]
    public sealed class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(
            [FromBody] CreateCategoryCommand command,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> List(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new ListCategoriesQuery(), cancellationToken);
            return Ok(result);
        }
    }
}
