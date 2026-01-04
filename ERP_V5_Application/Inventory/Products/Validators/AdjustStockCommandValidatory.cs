using ERP_V5_Application.Inventory.Products.Commands.AdjustStock;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_V5_Application.Inventory.Products.Validators
{
    public sealed class AdjustStockCommandValidator
    : AbstractValidator<AdjustStockCommand>
    {
        public AdjustStockCommandValidator()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty();

            RuleFor(x => x.Delta)
                .NotEqual(0)
                .WithMessage("Stock adjustment delta cannot be zero.");

            RuleFor(x => x.Reason)
                .NotEmpty()
                .MaximumLength(250);
        }
    }
}
