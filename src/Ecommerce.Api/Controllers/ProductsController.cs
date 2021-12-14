using AutoMapper;
using Eccomerce.Domain.Entities;
using Eccomerce.Domain.Repositories;
using Eccomerce.Domain.UnitOfWork;
using Ecommerce.Api.Dto;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : Controller
    {

        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly IValidator<Product> _validator;

        public ProductsController(
        IProductRepository productRepository,
        IMapper mapper, IUnitOfWork uow,
        IValidator<Product> validator)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _uow = uow;
            _validator = validator;
        }


 



    }
}
