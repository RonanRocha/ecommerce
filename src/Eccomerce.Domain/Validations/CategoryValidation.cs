using Eccomerce.Domain.Entities;
using Eccomerce.Domain.Repositories;
using FluentValidation;


namespace Eccomerce.Domain.Validations
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

            RuleFor(x => x.Slug)
               .NotNull().WithMessage("Slug não pode ser nulo")
               .NotEmpty().WithMessage("Slug não pode ser vazio")
               .GreaterThan("3").WithMessage("Slug deve ter pelo menos 3 caracteres");


            RuleFor(x => x).Custom((category, context) => {

                var categoryDatabase = _repository.GetByName(category.Name);

             
                if(!string.IsNullOrEmpty(category.Name))
                {
                    if (category.Name == categoryDatabase?.Name && category.Id != categoryDatabase?.Id)
                    {
                        context.AddFailure("Nome já existe");
                    }
                }
             


                if (!string.IsNullOrEmpty(category.Slug))
                {
                    if (category.Slug == categoryDatabase?.Slug && category.Id != categoryDatabase?.Id)
                    {
                        context.AddFailure("Slug já existe");
                    }
                }

            });


        }
    }
}
