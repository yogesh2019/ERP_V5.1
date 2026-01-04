using ERP_V5_Application.Common.Interfaces;
using ERP_V5_Application.Inventory.Categories.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ERP_V5_Application.Inventory.Products.Validators
{
    public sealed class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {

        public CreateCategoryCommandValidator(ICategoryRepository categoryRepository)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(100)
                .MustAsync(async (name, ct) =>
                    !await categoryRepository.ExistsByNameAsyc(name))
                .WithMessage("Category name already exists.");
        }
    }
}
