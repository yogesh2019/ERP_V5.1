using ERP_V5_Application.Inventory.Products.Commands.CreateProduct;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_V5_Application.Validators
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(p => p.Price).GreaterThanOrEqualTo(0).WithMessage("Price must be non-negative");
        }
    }

}
