using Eccomerce.Domain.Entities;
using Eccomerce.Domain.Repositories;
using Ecommerce.Api.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Validations
{
    public class CategoryValidation : AbstractValidator<Category>
    {
        private readonly ICategoryRepository _repository;

        public CategoryValidation(ICategoryRepository categoryRepository)
        {

            _repository = categoryRepository;


            RuleFor(x => x.Name)
                .NotNull().WithMessage("Nome não pode ser nulo")
                .NotEmpty().WithMessage("Nome não pode ser vazio")
                .GreaterThan("3").WithMessage("Nome deve ter pelo menos 3 caracteres");


            RuleFor(x => x).Custom((category, context) => {

                var categoryDatabase = _repository.GetByName(category.Name);

                if (category.Name == categoryDatabase?.Name && category.Id != categoryDatabase?.Id)
                {
                    context.AddFailure("Nome já existe");
                }
            });


        }
    }
}
