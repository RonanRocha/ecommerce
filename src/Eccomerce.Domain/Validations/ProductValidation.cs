using Eccomerce.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eccomerce.Domain.Validations
{
    public class ProductValidation : AbstractValidator<Product>
    {

        public ProductValidation()
        {
            RuleFor(x => x.Description)
             .NotNull().WithMessage("Descrição não pode ser nulo")
             .NotEmpty().WithMessage("Descrição não pode ser vazio")
             .GreaterThan("3").WithMessage("Descrição deve ter pelo menos 3 caracteres");

            RuleFor(x => x.CategoryId)
               .NotNull().WithMessage("Categoria não pode ser nulo")
               .NotEmpty().WithMessage("Categoria não pode ser vazio");

            RuleFor(x => x.Price)
               .NotNull().WithMessage("Preço não pode ser nulo")
               .NotEmpty().WithMessage("Preço não pode ser vazio");

            RuleFor(x => x.Barcode)
             .NotNull().WithMessage("Código de barras não pode ser nulo")
             .NotEmpty().WithMessage("Código de barras não pode ser vazio");






        }
    }
}
