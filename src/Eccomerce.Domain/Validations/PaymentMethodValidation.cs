using Eccomerce.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eccomerce.Domain.Validations
{
    public class PaymentMethodValidation : AbstractValidator<PaymentMethod>
    {

        public PaymentMethodValidation()
        {
            RuleFor(x => x.Description)
             .NotNull().WithMessage("Descrição não pode ser nulo")
             .NotEmpty().WithMessage("Descrição não pode ser vazio")
             .GreaterThan("3").WithMessage("Descrição deve ter pelo menos 3 caracteres");
        }
    }
}
