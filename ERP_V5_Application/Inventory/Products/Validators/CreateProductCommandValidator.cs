using ERP_V5_Application.Common.Interfaces;
using ERP_V5_Application.Inventory.Products.Commands.CreateProduct;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_V5_Application.Inventory.Products.Validators
{
    public sealed class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator(ICategoryRepository catRepo)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(x => x.Price).GreaterThanOrEqualTo(0);

            RuleFor(x => x.StockQty).GreaterThanOrEqualTo(0);

            RuleFor(x => x.CategoryId)
                .MustAsync(async (id, ct) => await catRepo.GetByIdAsync(id) != null)
                .WithMessage("Category does not exist");
        }
    }
}
